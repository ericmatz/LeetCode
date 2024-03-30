//https://leetcode.com/problems/binary-search/description/
public class Solution {

    public int recursiveSearch(int low, int middle, int high, int[] nums, int target){

        // target found -> break recursion
        if (target == nums[middle]){
            return middle;
        }

        // no more cells remaining and it is not the target -> Break Recursion
        if (low == high && nums[(low+high) / 2] != target){
            return -1;
        }
        
        // didnt find target -> Adjust new search area
        if (target > nums[middle]){
            low = middle + 1;
        } else if (target < nums[middle]) {
            //enforce 0 as lowest bound possible
            high = middle - 1 < 0 ? 0 : middle - 1;
        }

        return recursiveSearch(low, (low+high) / 2, high, nums, target);

    }

    public int Search(int[] nums, int target) {
        return recursiveSearch(0, (nums.Length-1) / 2, nums.Length-1, nums, target);         
    }
}
