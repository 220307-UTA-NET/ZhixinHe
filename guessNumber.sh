#!/usr/bin/bash
min=1
max=20
magic=4

echo "I have a magic number, which is not more than ${max} and not less than ${min}."
echo -n "Let's try to guess. please input a number($min ... $max):"
read input
while true; do
  if [ ${input} -eq ${magic} ]; then
    echo "Bingo!!! The magic number is ${input}"
    break
  fi
  if [ ${input} -gt ${magic} ]; then
    echo -n "thinking ."                          # mimic thinking
    for ((i=0; i<$(($input-$magic)); i+=1));do    # for $input-$magic seconds
      echo -n '.'                                 # e.x. you input 5 and magic is 2
      sleep 1                                     # it will think for 5-2=3 seconds
    done                                          #
    echo '.'                                      #
    max=$(($input-1))
    echo -n "You almost there, again please input a number($min ... $max):"
    read input
  fi
  if [ ${input} -lt ${magic} ]; then
    echo -n "thinking ."                          # mimic thinking
    for ((i=0; i<$(($magic-$input)); i+=1));do    # for $magic-$input seconds
      echo -n '.'                                 # e.x. you input 3 and magic is 9
      sleep 1                                     # it will think for 9-3=6 seconds
    done                                          #
    echo '.'                                      #
    min=$(($input+1))
    echo -n "You almost there, again please input a number($min ... $max):"
    read input
  fi
done
