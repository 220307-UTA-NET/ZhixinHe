#!usr/bin/bash

echo "Running $0 ..."
filename="./Checkin_$(date +'%Y%m%d').log"
if [[ -e ${filename} ]]; then
	rm -f ${filename}
fi

touch ${filename}

EmployeesCheckin=()

while true; do
	read -p 'To check in, please input your name: ' nameToCheckin
	if [[ $nameToCheckin =~ [Ss][Tt][Oo][Pp] ]]; then
		echo "$nameToCheckin detected, let's stop ..."
		break
	fi
	timestamp=$(date +"%s")

	if [[ -z $nameToCheckin ]]; then
		echo "empty input found, please try again"
		continue
	fi

	echo "$nameToCheckin checked in at $(date --date=@${timestamp} +'%Y%M%d %T')." #>> $filename
	EmployeesCheckin[$timestamp]=$nameToCheckin
	sleep 2
done

#echo ${EmployeeNames[@]} >> ./ClockInOut.txt
for key in ${!EmployeesCheckin[@]}; do
	echo "$key ---> ${EmployeesCheckin[$key]}"
	echo "$(date --date=@${key} +'%Y%M%d %T') ${EmployeesCheckin[$key]} checked in" | tee -a $filename
done


echo "$0 exit gracefully"




