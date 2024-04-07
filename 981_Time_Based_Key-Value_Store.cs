public class TimeMap {
    public Dictionary<string, List<(string, int)>> rows = new();

    /*
        Design a time-based key-value data structure that can 
            * Store multiple values for the same key at different time stamps 
            * retrieve the key's value at a certain timestamp.
    */
    public TimeMap() {

    }
    
    public int BinarySearchLTE(List<(string value, int timestamp)> values, int timestamp){
        /*
            returns the value associated with the largest timestamp_prev <= timestamp
        */
        int low = 0;
        int high = values.Count-1;
        int index = -1;

        while (low <= high){

            int middle = (low + high) / 2;

            if(values[middle].timestamp < timestamp){
                low = middle + 1;
                index = middle;
            } else if (values[middle].timestamp > timestamp){
                high = middle - 1;
            } else {
                return middle;
            }

        }

        return index;
    }

    public void Set(string key, string value, int timestamp) {
        /*
            Stores the key key with the value value at the given time timestamp.
        */
        if(!rows.ContainsKey(key)){
            rows.Add(key, new List<(string value, int timestamp)>()); //Define new key
        }
        rows[key].Add((value,timestamp)); //add values for key
    }
    
    public string Get(string key, int timestamp) {
        /*
            Returns a value such that set was called previously, with timestamp_prev <= timestamp. 
                If there are multiple such values, it returns the value associated with the largest timestamp_prev. 
                If there are no values, it returns "".
        */

        try {        
            if (rows.TryGetValue(key, out List<(string value, int timestamp)>values)){

                int index = BinarySearchLTE(values, timestamp);

                if (index == -1){
                    return "";
                }

                return values[index].value;
            }
        } catch (KeyNotFoundException){
            return "";
        }
        
        return "";
    }
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */
