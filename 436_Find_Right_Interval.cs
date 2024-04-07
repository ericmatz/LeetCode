public class Solution {

    public int BinarySearchGTE(int[] list, int target){
        int low = list.GetLowerBound(0);
        int high = list.Length-1;
        int index = -1;

        while(low <= high){
            int middle = (low + high) / 2;
            if(list[middle] >= target) {
                high = middle - 1;
                index = middle;                
            } else {
                low = middle + 1;
            }
        }

        return index;
    }

    public int getValueIndex(int[] indexes, int value){
        if (value == -1){
            return -1;
        }else{
            return indexes[value];
        }
    }

    public int[] FindRightInterval(int[][] intervals) {

        if(intervals.Length == 0) {
            return [-1];
        }

        int[] answers = new int[intervals.Length];
        int[] indexes = new int[intervals.Length];
        int[] values  = new int[intervals.Length];

        for (int i = 0; i < intervals.Length; i++){
            indexes[i] = i;
            values[i] = intervals[i][0];
        }

        Array.Sort(values, indexes);

        for(int i = 0; i < intervals.Length; i++){
            answers[i] = getValueIndex(indexes,BinarySearchGTE(values, intervals[i][1]));
        }

        return answers;
    }
}
