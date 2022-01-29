import java.util.*;

public class Program {
    
    public static void makeSCANScheduling(List<Integer> _pendingRequests, int startNumber){
        int totalDistance = 0; 
        int leftEnd = 0;
        List<Integer> processList = new ArrayList<Integer>();
        List<Integer> pendingRequests = new ArrayList<Integer>(_pendingRequests);
        Collections.sort(pendingRequests);
        
        int startIndex = pendingRequests.indexOf(startNumber);
        
        processList.add(startNumber);
        pendingRequests.remove(startIndex);
        
        // go to left-end from startNumber
        while(true){
            startIndex--;
            
            if(startIndex < 0){
                processList.add(leftEnd);
                break;
            }
            
            processList.add(pendingRequests.get(startIndex));
            pendingRequests.remove(startIndex);
        }
        
        //go to right-end from left-end
        while(true){
            processList.add(pendingRequests.get(0));
            pendingRequests.remove(0);
            
            if(pendingRequests.size() == 0){
                break;
            }
            
        }
        
        //calculate distance between each of thw two cylinder numbers and find their sum
        while(true){
            totalDistance += Math.abs(processList.get(0) - processList.get(1));
            processList.remove(0);
            
            if(processList.size() == 1){
                break;
            }
        }
        
        System.out.println("Total distance by SCAN scheduling: " + totalDistance);
    }
    
    public static void makeC_SCANScheduling(List<Integer> _pendingRequests, int startNumber){
        int totalDistance = 0; 
        int leftEnd = 0;
        int rightEnd = 4999;
        List<Integer> processList = new ArrayList<Integer>();
        List<Integer> pendingRequests = new ArrayList<Integer>(_pendingRequests);
        Collections.sort(pendingRequests);
        
        int startIndex = pendingRequests.indexOf(startNumber);
        
        processList.add(startNumber);
        pendingRequests.remove(startIndex);

        // go to left-end via right-end from startNumber
        while(true){
            processList.add(pendingRequests.get(startIndex));
            pendingRequests.remove(startIndex);
            
            if(pendingRequests.size() <= startIndex){
                processList.add(rightEnd);
                processList.add(leftEnd);
                break;
            }
        }
        
        //go to the (previous cylinder number from the startNumber) from left-end
        while(true){
            processList.add(pendingRequests.get(0));
            pendingRequests.remove(0);
            
            if(pendingRequests.size() == 0){
                break;
            }
            
        }
        
        //calculate distance between each of thw two cylinder numbers and find their sum
        while(true){
            totalDistance += Math.abs(processList.get(0) - processList.get(1));
            processList.remove(0);
            
            if(processList.size() == 1){
                break;
            }
        }
        
        System.out.println("Total distance by C-SCAN scheduling : " + totalDistance);
    }
    
    public static void main(String[] args) throws Exception {
        int input[] = {143, 86, 1470, 913, 1774, 948, 1509, 1022, 1750, 130};
        List<Integer> pendingRequests = new ArrayList<Integer>();
        
        for(int i = 0; i < input.length; i++){
            pendingRequests.add(input[i]);
        }
        
        int startNumber = 143;
        
        makeSCANScheduling(pendingRequests, startNumber);
        
        makeC_SCANScheduling(pendingRequests, startNumber);
    }
}
