
#include "proxy_server.h"

// Connect to the DB
bool connectDB( MYSQL *conn )
{
  char *server = "localhost";
  char *user = "root";
  char *password = "";
  char *database = "mydnssec";

  return mysql_real_connect( conn, server, user, password, database, 0, NULL, 0 );

} // connectDB()

// Get AES key and AES CBC IV for a given client-id
bool getClientData( const unsigned char *clientIdB64, 
		    unsigned char *aesKey, unsigned char *aesCBCIV )
{
  MYSQL *conn;
  MYSQL_RES *res;
  MYSQL_ROW row;
  bool result = false, bResults;
  size_t length;
  char *strptr;
  char aesKeyB64[MyDNSSEC_AES_KEY_B64_LEN + 1];
  char aesCbcIvB64[MyDNSSEC_AES_KEY_B64_LEN + 1];
  char query[MyDNSSEC_SELECT_LEN + 1];

  // Connect to database
  conn = mysql_init(NULL);
  if ( !connectDB(conn) )
  {
    printf( "%s\n", mysql_error(conn) );
    return false;
  }

  // Prepare SQL SELECT query
  memcpy( query, MyDNSSEC_SELECT_START, MyDNSSEC_SELECT_START_LEN );
  strptr = query + MyDNSSEC_SELECT_START_LEN;
  memcpy( strptr, clientIdB64, MyDNSSEC_CLIENT_ID_64_LEN );
  strptr += MyDNSSEC_CLIENT_ID_64_LEN;
  memcpy( strptr, MyDNSSEC_SELECT_END, MyDNSSEC_SELECT_END_LEN );
  strptr += MyDNSSEC_SELECT_END_LEN;
  *strptr++ = '\0';

  // Send SQL SELECT query
  if ( mysql_query( conn, query ) )
  {
    printf( "%s\n", mysql_error(conn) );
    goto EXIT;
  }
  res = mysql_use_result(conn);
  row = mysql_fetch_row(res);
  if ( row == NULL )
    goto EXIT; 		// There was no matching record
 
  // Get data and decode it to binary
  memcpy( aesKeyB64, row[1], MyDNSSEC_AES_KEY_B64_LEN );
  memcpy( aesCbcIvB64, row[2], MyDNSSEC_AES_KEY_B64_LEN );
  length = MyDNSSEC_AES_KEY_LEN;
  bResults = base64_decode( aesKeyB64, MyDNSSEC_AES_KEY_B64_LEN, aesKey, &length );
  if ( !bResults || length != MyDNSSEC_AES_KEY_LEN )
    goto EXIT;
  length = MyDNSSEC_AES_KEY_LEN;
  bResults = base64_decode( aesCbcIvB64, MyDNSSEC_AES_KEY_B64_LEN, aesCBCIV, &length );
  if ( !bResults || length != MyDNSSEC_AES_KEY_LEN )
    goto EXIT;

  // If we get here, everything went well
  result = true;

EXIT:
  // Release memory used to store results and close connection
  mysql_free_result(res);
  mysql_close(conn);

  return result;

} // getClientData()


// Return true if given clientID is unique in the BD or there is an error, false otherwise.
bool isClientIdUnique( const unsigned char *clientIdB64 )
{
  MYSQL *conn;
  MYSQL_RES *res;
  MYSQL_ROW row;
  bool result = true;
  char query[MyDNSSEC_SELECT_LEN + 1] = MyDNSSEC_SELECT_START;

  // Connect to database
  conn = mysql_init(NULL);
  if ( !connectDB(conn) )
  {
    printf( "%s\n", mysql_error(conn) );
    return true;
  }

  // Send SQL query
  memcpy( &query[MyDNSSEC_SELECT_START_LEN], clientIdB64, MyDNSSEC_CLIENT_ID_64_LEN);
  query[MyDNSSEC_SELECT_START_LEN + MyDNSSEC_CLIENT_ID_64_LEN] = '\'';
  query[MyDNSSEC_SELECT_START_LEN + MyDNSSEC_CLIENT_ID_64_LEN + 1] = '\0';
  if ( mysql_query( conn, query ) )
  {
    printf( "%s\n", mysql_error(conn) );
    goto EXIT;
  }

  // Check the results
  res = mysql_use_result(conn);
  row = mysql_fetch_row(res);
  if ( row != NULL )	// There is a collision
    result = false;

EXIT:
  // Release memory used to store results and close connection
  mysql_free_result(res);
  mysql_close(conn);

  return result;
} // isClientIdUnique()


// Store credentials in BD
bool storeCredentials( const unsigned char *clientIdB64, const unsigned char *aesKey,
			const unsigned char *aesCbcIv )
{
  MYSQL *conn;
  bool result = false;
  char query[MyDNSSEC_INSERT_LEN + 1];
  char *strptr;
  char aesKeyB64[MyDNSSEC_AES_KEY_B64_LEN + 1];
  char aesCbcIvB64[MyDNSSEC_AES_KEY_B64_LEN + 1];

  // Connect to database
  conn = mysql_init(NULL);
  if ( !connectDB(conn) )
  {
    printf( "%s\n", mysql_error(conn) );
    return false;
  }

  // Encode AES Key and AES CBC IV
  base64_encode( aesKey, MyDNSSEC_AES_KEY_LEN, aesKeyB64, sizeof(aesKeyB64) );
  base64_encode( aesCbcIv, MyDNSSEC_AES_KEY_LEN, aesCbcIvB64, sizeof(aesCbcIvB64) );
  if ( strlen(aesKeyB64) != MyDNSSEC_AES_KEY_B64_LEN ||
       strlen(aesCbcIvB64) != MyDNSSEC_AES_KEY_B64_LEN )
  {
    printf("Error in base64_encode()\n");
    goto EXIT;
  }

  // Prepare SQL INSERT
  memcpy( query, MyDNSSEC_INSERT_START, MyDNSSEC_INSERT_START_LEN );
  strptr = query + MyDNSSEC_INSERT_START_LEN;
  memcpy( strptr, clientIdB64, MyDNSSEC_CLIENT_ID_64_LEN );
  strptr += MyDNSSEC_CLIENT_ID_64_LEN;
  *strptr++ = '\'';
  *strptr++ = ',';
  *strptr++ = '\'';
  memcpy( strptr, aesKeyB64, MyDNSSEC_AES_KEY_B64_LEN );
  strptr += MyDNSSEC_AES_KEY_B64_LEN;
  *strptr++ = '\'';
  *strptr++ = ',';
  *strptr++ = '\'';
  memcpy( strptr, aesCbcIvB64, MyDNSSEC_AES_KEY_B64_LEN );
  strptr += MyDNSSEC_AES_KEY_B64_LEN;
  memcpy( strptr, MyDNSSEC_INSERT_END, MyDNSSEC_INSERT_END_LEN );
  strptr += MyDNSSEC_INSERT_END_LEN;
  *strptr++ = '\0';

  // Send SQL INSERT
  if ( mysql_real_query( conn, query, MyDNSSEC_INSERT_LEN + 1 ) )
  {
    printf( "%s\n", mysql_error(conn) );
    goto EXIT;
  }
  else
    result = true;

EXIT:
  // Close connection
  mysql_close(conn);
  return result;

} // storeCredentials()
