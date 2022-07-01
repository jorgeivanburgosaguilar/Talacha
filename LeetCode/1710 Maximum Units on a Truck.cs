/*
1710 Maximum Units on a Truck
Runtime: 155 ms, faster than 57.76% of C# online submissions for Maximum Units on a Truck.
Memory Usage: 41.1 MB, less than 38.20% of C# online submissions for Maximum Units on a Truck.
*/
public class BoxType
{
	public int NumberOfBoxes { get; set; }
	public int NumberOfUnitsPerBox { get; set; }
	
	public BoxType(int numberOfBoxes, int numberOfUnitsPerBox)
	{
		this.NumberOfBoxes = numberOfBoxes;
		this.NumberOfUnitsPerBox = numberOfUnitsPerBox;
	}
}

public class Solution
{
    public static List<BoxType> ConvertBoxTypeArrayToList(int[][] boxTypes)
    {
        var boxTypeList = new List<BoxType>();
        for (var i = 0; i < boxTypes.Length; i++)
        {
            boxTypeList.Add(new BoxType(boxTypes[i][0], boxTypes[i][1]));
        }
        
        return boxTypeList;
    }
    
    public int MaximumUnits(int[][] boxTypes, int truckSize)
    {
        var sortedListBoxTypes = ConvertBoxTypeArrayToList(boxTypes).OrderByDescending(boxType => boxType.NumberOfUnitsPerBox);
        var currentNumberOfBoxesInTruck = 0;
        var currentNumberOfUnitsInTruck = 0;
        var lastTypeBoxUnit = 0;
        
        foreach (var boxType in sortedListBoxTypes)
        {
            if (currentNumberOfBoxesInTruck > truckSize)           
                break;
            
            currentNumberOfBoxesInTruck += boxType.NumberOfBoxes;
            currentNumberOfUnitsInTruck += boxType.NumberOfBoxes * boxType.NumberOfUnitsPerBox;
            lastTypeBoxUnit = boxType.NumberOfUnitsPerBox;
        }
        
        var excess = currentNumberOfBoxesInTruck - truckSize;
        while (excess > 0)
        {
            currentNumberOfUnitsInTruck -= lastTypeBoxUnit;
            excess--;
        }
        
        return currentNumberOfUnitsInTruck;
    }
}