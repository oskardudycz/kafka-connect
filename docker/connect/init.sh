while !(ping -c 1 http://localhost:8083/connectors/ &> /dev/null)
do
   sleep 3
   echo "waiting for connect ..."
done
echo "starting the main script"