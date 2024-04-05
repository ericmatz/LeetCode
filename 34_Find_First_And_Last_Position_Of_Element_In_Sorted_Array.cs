public class Solution {
    public int[] SearchRange(int[] nums, int target) {
       
       if (nums.Length == 0){
            return [-1,-1];
       } 

        int low = 0;
        int high = nums.Length-1;

        while(low<=high){
            int middle = (low+high)/2;

            if (nums[middle] < target){
                low = middle + 1;
            } else if(nums[middle] > target){
                high = middle - 1;
            } else {
                //position found -> find lower and upper bounds
                int start = middle;
                int end = middle;

                while(nums[start] == target && start-1 >= nums.GetLowerBound(0)){
                    if(nums[start-1] == target){
                        start--;
                    }else{
                        break;
                    }
                }

                while(nums[end] == target && end+1 <= nums.GetUpperBound(0)){
                    if(nums[end+1] == target){
                        end++;
                    }else{
                        break;
                    }
                }

                return [start,end];
            }
        }

        return [-1,-1];

    }
}
