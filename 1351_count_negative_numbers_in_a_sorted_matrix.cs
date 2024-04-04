public class Solution {
    public int CountNegatives(int[][] grid) {
        int count = 0;
        for (int i = 0; i < grid.Length; i++){   
            if(grid[i][0] < 0) { //First element is negative -> implies entire array is negative.
                count += grid[i].Length;
            } else if(grid[i][grid[i].Length-1] < 0){ //Last element is negative -> locate the index of the highest negative number
                int low = 0;
                int high = grid[i].Length-1;
                int idx = high;                
                while(low <= high){
                    int middle = (low + high)/2;
                    if (grid[i][middle] >= 0){
                        low = middle + 1;
                    } else {
                        if(grid[i][idx] <= grid[i][middle]){ //we have a negative number, and it is smaller than the current index -> take it and pivot left.
                            idx = middle;
                            high = middle - 1;
                        } else {
                            break; //lowest value found -> Stop looking
                        }
                    }
                } 
                count += ((grid[i].Length) - idx);             
            }    
        }
        return count;
    }
}
