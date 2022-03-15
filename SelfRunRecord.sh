#!/usr/bin/bash

logfile="./Date.txt"

if [[ -e ${logfile} ]]; then
	echo "Script run at $(date +'%Y-%m-%d %T')" >> ${logfile}
else
	echo "Starting file for $(date +'%Y-%m-%d') at $(date +'%T')" > ${logfile}
fi

exit 0
