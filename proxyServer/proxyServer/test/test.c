#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>

#define MAX_UDP_SIZE 4096
#define MAXLEN (MAX_UDP_SIZE * 8 / 6) + 2 
#define EXTRA 5
/* 4 for field name "data", 1 for "=" */
#define MAXINPUT MAXLEN+EXTRA+2
/* 1 for added line break, 1 for trailing NULL */

int main(void) {
	char *lenstr;
	char input[MAXINPUT];
	unsigned long len, i;

	printf( "%s%c%c", "Content-Type:text/html;charset=iso-8859-1\n", 13, 10 );
	lenstr = getenv("CONTENT_LENGTH");
	if( lenstr == NULL || sscanf(lenstr, "%ld", &len) !=1 || len > MAXLEN )
		printf("<P>Error in invocation.\n");
	else {
		fgets(input, len+1, stdin);
		//printf( ":%s:%d:", input, len );
		printf( "<![CDATA[%s:%d]]>", input, len );
		return 0;
	}

	return 0;
}
