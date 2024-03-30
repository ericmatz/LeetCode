//https://leetcode.com/problems/search-insert-position/description/
public class Solution {

    public int recursiveSearch(int low, int high, int[] nums, int target){

        int middle = (low+high)/2;

        // target found -> break recursion
        if (target == nums[middle]){
            return middle;
        }

        // no more cells remaining and it is not the target -> Break Recursion
        if (low >= high){
        
            //target is to the left
            if (nums[middle] > target) {
                return middle;
            }

            //target is to the right
            if (nums[middle] < target) {
                return middle + 1;
            }
        }
        
        // didnt find target -> Adjust new search area
        if (target > nums[middle]){
            //enforce array length as highest bound possible
            low = middle + 1 == nums.Length ?  middle : middle + 1;
        } else if (target < nums[middle]) {
            //enforce 0 as lowest bound possible
            high = middle - 1 < 0 ? 0 : middle - 1;
        }

        return recursiveSearch(low, high, nums, target);

    }

    public int SearchInsert(int[] nums, int target) {
        
        if (nums.Length == 0) {
            return 0;
        }

        return recursiveSearch(0, nums.Length-1, nums, target);         
    }
}
