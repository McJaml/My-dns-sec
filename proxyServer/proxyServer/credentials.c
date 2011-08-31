
#include "proxy_server.h"

int main(void) {
	char *lenstr;
	unsigned char buffer1[MyDNSSEC_MAX_CREDS_BUFFER_LEN];
	unsigned char buffer2[MyDNSSEC_MAX_CREDS_BUFFER_LEN];
	size_t len, buffer1Len, buffer2Len, datalen;
	unsigned char clientIdB64[MyDNSSEC_CLIENT_ID_64_LEN + 1];
	unsigned char clientID[MyDNSSEC_CLIENT_ID_LEN];
	unsigned char aesKey[MyDNSSEC_AES_KEY_LEN], aesCbcIv[MyDNSSEC_AES_KEY_LEN];
	unsigned char *data;
	bool retstatus = false;

	printf( "%s%c%c", "Content-Type:text/plain;charset=US-ASCII\n", 13, 10 );
	lenstr = getenv("CONTENT_LENGTH");
	if( lenstr == NULL || sscanf(lenstr, "%ld", &len) !=1 || len > MyDNSSEC_MAX_CREDS_BUFFER_LEN )
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

	// Check the request received
	if ( strcmp( data, MyDNSSEC_NEW_CREDS_MSG ) != 0 )
	{
		printf( "<P>Error in request received:%s:\n", data );
		return -1;
	}

	// Generate credentials
	if ( RAND_bytes( aesCbcIv, MyDNSSEC_AES_KEY_LEN ) == 0 )
	{
		printf( "<P>Error at generating AES CBC IV.\n" );
		return -1;
	}
	if ( RAND_bytes( aesKey, MyDNSSEC_AES_KEY_LEN ) == 0 )
	{
		printf( "<P>Error at generating AES Key.\n" );
		return -1;
	}
	RAND_bytes( clientID, MyDNSSEC_CLIENT_ID_LEN );
	do {
	  if ( RAND_bytes( clientID, MyDNSSEC_CLIENT_ID_LEN ) == 0 )
	  {
		printf( "<P>Error at generating clientID.\n" );
		return -1;
	  }
	  base64_encode( clientID, MyDNSSEC_CLIENT_ID_LEN, clientIdB64, sizeof(clientIdB64) );
	} while ( !isClientIdUnique( clientIdB64 ) );
	RAND_bytes( buffer1, MyDNSSEC_CLIENT_ID_LEN );

	// Build message in buffer1
	buffer1Len = MyDNSSEC_CLIENT_ID_LEN + 2 * MyDNSSEC_AES_KEY_LEN;
	memcpy( buffer1, clientID, MyDNSSEC_CLIENT_ID_LEN );
	memcpy( &buffer1[MyDNSSEC_CLIENT_ID_LEN], aesKey, MyDNSSEC_AES_KEY_LEN );
	memcpy( &buffer1[MyDNSSEC_CLIENT_ID_LEN + MyDNSSEC_AES_KEY_LEN], aesCbcIv, MyDNSSEC_AES_KEY_LEN );

	// Encode message in base 64 in buffer2
	buffer2Len = sizeof(buffer2);
	base64_encode( buffer1, buffer1Len, buffer2, buffer2Len );
	buffer2Len = strlen(buffer2);
	if ( buffer2Len != BASE64_LENGTH(buffer1Len) ) {
		printf("<P>Error in base64_encode().\n");
		return -1;
	}

	// Store credentials
	memcpy( clientIdB64, buffer2, MyDNSSEC_CLIENT_ID_64_LEN );
	clientIdB64[MyDNSSEC_CLIENT_ID_64_LEN] = '\0';
	retstatus = storeCredentials( clientIdB64, aesKey, aesCbcIv );
	if ( !retstatus )
	{
		printf( "<P>Error at storeCredentials().\n" );
		return -1;
	}

	// Send back the encoded response in buffer2
	printf( "%s%s%s", MyDNSSEC_RESP_START_TAG, buffer2, MyDNSSEC_RESP_END_TAG );

	return 0;
}
