
#include "proxy_server.h"

// Encrypt the bytes in "message", "length" has the number of bytes to encrypt at entrance and the number of bytes returned at the end.
unsigned char *encryptMessage( const unsigned char *aesKey,
		      const unsigned char *aesCBCIV,
		      const unsigned char *message,
		      unsigned long *length, unsigned char *saltLen )
{
	AES_KEY	aesEncKey;
	unsigned char iv[MyDNSSEC_AES_KEY_LEN];
	unsigned char *toEncrypt;
	unsigned char *encrypted;

	*saltLen = MyDNSSEC_AES_KEY_LEN - (*length % MyDNSSEC_AES_KEY_LEN) + MyDNSSEC_AES_KEY_LEN;
	memcpy( iv, aesCBCIV, MyDNSSEC_AES_KEY_LEN );
	if ( AES_set_encrypt_key( aesKey, MyDNSSEC_AES_KEY_BITS_LEN, &aesEncKey ) != 0 )
		return NULL;

	toEncrypt = (unsigned char *)malloc( *length + *saltLen );
	if ( toEncrypt == NULL )
		return NULL;
	if ( RAND_bytes( toEncrypt, *saltLen ) == 0 )
		goto ERROR1;
	memcpy( &toEncrypt[*saltLen], message, *length );

	*length += *saltLen;
	encrypted = (unsigned char *)malloc( *length );
	if ( encrypted == NULL )
		goto ERROR1;
	AES_cbc_encrypt( toEncrypt, encrypted, *length, &aesEncKey, iv, AES_ENCRYPT );

	free(toEncrypt);
	return encrypted;

ERROR1:
	free(toEncrypt);
	return NULL;
}


// Decrypt the bytes in "encrypted", "length" has the number of bytes to decrypt at entrance and the number of bytes returned at the end.
unsigned char *decryptMessage( const unsigned char *aesKey, 
			const unsigned char *aesCBCIV,
			const unsigned char saltLen,
			const unsigned char *encrypted, unsigned long *length )
{
	AES_KEY	aesDecKey;
	unsigned char iv[MyDNSSEC_AES_KEY_LEN];
	unsigned char *message;
	unsigned char *decrypted;

	if ( AES_set_decrypt_key( aesKey, MyDNSSEC_AES_KEY_BITS_LEN, &aesDecKey ) != 0 )
		return NULL;
	memcpy( iv, aesCBCIV, MyDNSSEC_AES_KEY_LEN );

	decrypted = (unsigned char *)malloc( *length );
	if ( decrypted == NULL )
		return NULL;
	AES_cbc_encrypt( encrypted, decrypted, *length, &aesDecKey, iv, AES_DECRYPT );

	*length -= saltLen;
	message = (unsigned char *)malloc( *length );
	if ( message == NULL )
		goto ERROR1;
	memcpy( message, &decrypted[saltLen], *length );

	free(decrypted);
	return message;

ERROR1:
	free(decrypted);
	return NULL;
}
