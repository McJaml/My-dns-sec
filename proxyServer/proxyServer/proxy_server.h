
#ifndef __PROXY_SERVER_H__
#define __PROXY_SERVER_H__

#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <string.h>
#include <stdbool.h>
#include <memory.h>
#include <mysql/mysql.h>
#include <openssl/aes.h>
#include <openssl/rand.h>
#include "base64.h"

#define MyDNSSEC_VERSION "0.2.0"

#define MyDNSSEC_DATA_TAG "data="
#define MyDNSSEC_DATA_TAG_LEN (sizeof(MyDNSSEC_DATA_TAG) - 1)
#define MyDNSSEC_RESP_START_TAG "<![CDATA["
#define MyDNSSEC_RESP_END_TAG "]]>"

#define MyDNSSEC_AES_KEY_LEN 16L
#define MyDNSSEC_AES_KEY_BITS_LEN ( MyDNSSEC_AES_KEY_LEN * 8 )
#define MyDNSSEC_AES_KEY_B64_LEN BASE64_LENGTH(MyDNSSEC_AES_KEY_LEN)
#define MyDNSSEC_CLIENT_ID_LEN 15
#define MyDNSSEC_CLIENT_ID_64_LEN BASE64_LENGTH(MyDNSSEC_CLIENT_ID_LEN)
#define MyDNSSEC_SALT_LEN 1

#define MyDNSSEC_SELECT_START "SELECT * FROM clients WHERE client = '"
#define MyDNSSEC_SELECT_START_LEN ( sizeof(MyDNSSEC_SELECT_START) - 1 )
#define MyDNSSEC_SELECT_END "' and expire > current_timestamp"
#define MyDNSSEC_SELECT_END_LEN ( sizeof(MyDNSSEC_SELECT_END) - 1 )
#define MyDNSSEC_SELECT_LEN (MyDNSSEC_SELECT_START_LEN + MyDNSSEC_CLIENT_ID_64_LEN + MyDNSSEC_SELECT_END_LEN)

#define MyDNSSEC_INSERT_START "INSERT INTO clients VALUES ( '"
#define MyDNSSEC_INSERT_START_LEN ( sizeof(MyDNSSEC_INSERT_START) -1 )
#define MyDNSSEC_INSERT_END "', timestampadd(hour, 12, current_timestamp) )"
#define MyDNSSEC_INSERT_END_LEN ( sizeof(MyDNSSEC_INSERT_END) -1 )
#define MyDNSSEC_INSERT_LEN ( MyDNSSEC_INSERT_START_LEN + MyDNSSEC_CLIENT_ID_64_LEN + 3 + MyDNSSEC_AES_KEY_B64_LEN + 3 + MyDNSSEC_AES_KEY_B64_LEN + MyDNSSEC_INSERT_END_LEN )

#define MyDNSSEC_NEW_CREDS_MSG "<Give_me_new_credentials>"
#define MyDNSSEC_NEW_CREDS_MSG_LEN (sizeof(MyDNSSEC_NEW_CREDS_MSG) - 1)
#define MyDNSSEC_MAX_CREDS_BUFFER_LEN ( MyDNSSEC_NEW_CREDS_MSG_LEN + MyDNSSEC_DATA_TAG_LEN + MyDNSSEC_CLIENT_ID_64_LEN + 2 * MyDNSSEC_AES_KEY_B64_LEN )

#define MyDNSSEC_MAX_UDP_SIZE 65535
#define MyDNSSEC_MAX_UDP_B64_SIZE ( BASE64_LENGTH( MyDNSSEC_MAX_UDP_SIZE + 2 * MyDNSSEC_AES_KEY_LEN + MyDNSSEC_CLIENT_ID_LEN + MyDNSSEC_SALT_LEN ) + 2 )
#define MyDNSSEC_MAXINPUT ( MyDNSSEC_MAX_UDP_B64_SIZE + MyDNSSEC_DATA_TAG_LEN + 2 )	//1 for added line break, 1 for trailing NULL

bool do_dns_query( char *query, unsigned long qlen,
                   char *response, size_t *reslen );

bool getClientData( const unsigned char *clientID, 
		    unsigned char *aesKey, unsigned char *aesCBCIV );

unsigned char *encryptMessage( const unsigned char *aesKey,
		      const unsigned char *aesCBCIV,
		      const unsigned char *message,
		      unsigned long *length, unsigned char *saltLen );

unsigned char *decryptMessage( const unsigned char *aesKey, 
			const unsigned char *aesCBCIV,
			const unsigned char saltLen,
			const unsigned char *encrypted, unsigned long *length );

bool isClientIdUnique( const unsigned char *clientID );

bool storeCredentials( const unsigned char *clientIdB64, const unsigned char *aesKey,
			const unsigned char *aesCbcIv );


#endif //__PROXY_SERVER_H__