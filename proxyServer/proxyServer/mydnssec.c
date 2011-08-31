
#include "proxy_server.h"

int main(void) {
	char *lenstr;
	char buffer1[MyDNSSEC_MAXINPUT], buffer2[MyDNSSEC_MAXINPUT];
	char clientID[MyDNSSEC_CLIENT_ID_64_LEN + 1];
	size_t len, buffer1Len, buffer2Len, datalen;
	bool retstatus = false;
	uint8_t saltLen;
	unsigned char aesKey[MyDNSSEC_AES_KEY_LEN], aesCbcIv[MyDNSSEC_AES_KEY_LEN];
	unsigned char *data, *decrypted, *encrypted;
	unsigned long length;

	printf( "%s%c%c", "Content-Type:text/plain;charset=US-ASCII\n", 13, 10 );
	lenstr = getenv("CONTENT_LENGTH");
	if( lenstr == NULL || sscanf(lenstr, "%ld", &len) !=1 || len > MyDNSSEC_MAX_UDP_B64_SIZE )
	{
		printf("<P>Error in invocation.\n");
		return 0;
	}

	// Get request in buffer1
	fgets(buffer1, len+1, stdin);
	data = strstr( buffer1, MyDNSSEC_DATA_TAG );
	if ( data == NULL ) {
		printf("<P>Error in strstr().\n");
		return -1;
	}
	data += MyDNSSEC_DATA_TAG_LEN;
	memcpy( clientID, data, MyDNSSEC_CLIENT_ID_64_LEN );
	clientID[MyDNSSEC_CLIENT_ID_64_LEN] = '\0';
	data += MyDNSSEC_CLIENT_ID_64_LEN;

	// Decode message to binary in buffer2
	datalen = strlen(data);
	buffer2Len = sizeof(buffer2);
	retstatus = base64_decode_ctx(NULL, data, datalen, buffer2, &buffer2Len);
	if ( !retstatus ) {
		printf("<P>Error in base64_decode().%u\n", buffer2Len);
		return -1;
	}

	// Get AES key and IV for the client
	retstatus = getClientData( clientID, aesKey, aesCbcIv );
	if ( !retstatus ) {
	  printf("<P>Error in getClientData().\n");
	  return -1;
	}

	// Decrypt message in newly allocated buffer
	memcpy( &saltLen, buffer2, MyDNSSEC_SALT_LEN );
	length = buffer2Len - MyDNSSEC_SALT_LEN;
	data = &buffer2[MyDNSSEC_SALT_LEN];
	decrypted = decryptMessage( aesKey, aesCbcIv, saltLen, data, &length);
	if ( decrypted == NULL ) {
	  printf("<P>Error in decryptMessage().\n");
	  return -1;
	}

	// Do DNS query and get response in buffer1
	buffer1Len = sizeof(buffer1);
	retstatus = do_dns_query( decrypted, length, buffer1, &buffer1Len );
	free(decrypted);
	if ( !retstatus ) {
		printf("<P>Error in do_dns_query().\n");
		return -1;
	}

	// Encrypt response in newly allocated buffer
	length = buffer1Len;
	encrypted = encryptMessage( aesKey, aesCbcIv, buffer1, &length, &saltLen );
	if ( encrypted == NULL ) {
	  printf("<P>Error in encryptMessage().\n");
	  return -1;
	}

	// Build message in newly allocated buffer
	datalen = MyDNSSEC_SALT_LEN + length;
	data = (char *)malloc( datalen );
	if ( data == NULL ) {
	  printf("<P>Error in building response message.\n");
	  free(encrypted);
	  return -1;
	}
	memcpy( data, &saltLen, MyDNSSEC_SALT_LEN );
	memcpy( &data[MyDNSSEC_SALT_LEN], encrypted, length );
	free(encrypted);

	// Encode message in base 64 in buffer1
	buffer1Len = sizeof(buffer1);
	base64_encode(data, datalen, buffer1, buffer1Len);
	free(data);
	buffer1Len = strlen(buffer1);
	if ( buffer1Len != BASE64_LENGTH(datalen) ) {
		printf("<P>Error in base64_encode().\n");
		return -1;
	}

	// Send back the encoded and encrypted response
	printf( "%s%s%s", MyDNSSEC_RESP_START_TAG, buffer1, MyDNSSEC_RESP_END_TAG );

	return 0;
}
