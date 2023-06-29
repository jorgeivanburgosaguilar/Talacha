/*
195 Tenth Line
Runtime: 68 ms, faster than 6.81% of Bash online submissions for Tenth Line.
Memory Usage: 3.7 MB, less than 30.52% of Bash online submissions for Tenth Line.
*/
test `cat file.txt | wc -l` -ge 10 && cat file.txt | head -n 10 | tail -n 1