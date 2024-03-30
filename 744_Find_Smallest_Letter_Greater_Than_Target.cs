https://leetcode.com/problems/find-smallest-letter-greater-than-target/
public class Solution {
    public int recursiveSearch(char[] letters, char target, int answer, int low, int high) {
        
        int middle = (low+high)/2;
        if (low >= high) {
            if (letters[middle].CompareTo(letters[answer]) < 0 && letters[middle].CompareTo(target) > 0){
                if (letters[middle].CompareTo(target) != 0){
                    answer = middle;
                }
            }
            return answer;
        }
        
        if(letters[middle].CompareTo(target) <= 0) {
            //the current middle letter is LTE to the target, pivot right
            low = middle + 1 == letters.Length ? middle : middle + 1;
        } else {
            //the current middle letter is GT the target -> Valid choices to be made!
            high = middle - 1 < 0 ? 0 : middle - 1;        
            if (letters[middle].CompareTo(letters[answer]) < 0 ){
                if (letters[middle].CompareTo(target) != 0){
                    answer = middle;
                }
            }
        }
   
        return recursiveSearch(letters, target, answer, low, high);
    }
    public char NextGreatestLetter(char[] letters, char target) {
        int idx = recursiveSearch(letters, target, letters.Length-1, 0, letters.Length-1);
        if (letters[idx].CompareTo(target) <= 0){
            return letters[0];
        } else {
            return letters[idx];
        }
    }
}
