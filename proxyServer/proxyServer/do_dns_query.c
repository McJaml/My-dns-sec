#include <arpa/inet.h>
#include <netinet/in.h>
#include <stdio.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <unistd.h>
#include <stdbool.h>
#include <string.h>

#define DNS_IP "127.0.0.1"
#define DNS_PORT 53
#define MAX_UDP_SIZE 4096

bool do_dns_query( char *query, unsigned long qlen, 
		   char *response, size_t *reslen ) {
	struct sockaddr_in to;
	int s;
	unsigned int retval = 0, tolen = sizeof(to);

	if ( (s = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP)) == -1 )
		return false;

	memset( (char *) &to, 0, tolen );
	to.sin_family = AF_INET;
	to.sin_port = htons(DNS_PORT);
	if ( inet_aton(DNS_IP, &to.sin_addr) == 0 )
		return false;

	if ( sendto(s, query, qlen, 0, (struct sockaddr *) &to, tolen) == -1 )
		return false;

	retval = recvfrom( s, response, *reslen, 0, (struct sockaddr *) &to, &tolen );
	*reslen = retval;

	return true;
}
