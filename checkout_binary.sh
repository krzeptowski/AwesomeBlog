# "skrypt" podmienia pliki (lista w binaryfiles.lst) a nastepnie dodaje je do stage
# stworzone w celu automatyzacji rozwiazywania konfliktow :P

if [ -z $1 ]
then
	echo "You dont specify which changes I schould update."
	echo "Usage: checkout_binary.sh --theirs | --ours"
	exit 0
else
	if [ $1 != "--theirs" -a $1 != "--ours" ]
	then
		echo "Bad argument: ${1}"
		echo "Usage: checkout_binary.sh --theirs | --ours"
		exit 0
	fi
fi

for file in `cat binaryfiles.lst | grep -v "^#" | grep -v "^$"`
do
	git checkout $1 $file
	git add $file
done

