/*
192 Word Frequency
Runtime: 100 ms, faster than 87.60% of Bash online submissions.
Memory Usage: 3.78 MB, less than 71.25% of Bash online submissions.
*/
tr -s ' ' '\n' < words.txt | sort | uniq -c | sort -nr -k1,1 -k2,2 | awk '{print $2, $1}'
