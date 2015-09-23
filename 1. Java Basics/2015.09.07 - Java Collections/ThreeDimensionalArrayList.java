import java.util.ArrayList;

public class ThreeDimensionalArrayList {
    public static void main(String[] args) {
        ArrayList<ArrayList<ArrayList<Integer>>> nums =
                new ArrayList<ArrayList<ArrayList<Integer>>>();

        nums.add(new ArrayList<ArrayList<Integer>>());
        nums.get(0).add(new ArrayList<Integer>());

        nums.get(0).get(0).add(1);
        nums.get(0).get(0).add(2);
        nums.get(0).get(0).add(3);
        nums.get(0).get(0).add(4);
        nums.get(0).get(0).add(5);
        nums.get(0).get(0).add(6);

        nums.get(0).add(new ArrayList<Integer>());
        nums.get(0).get(1).add(1);
        nums.get(0).get(1).add(2);
        nums.get(0).get(1).add(3);

        nums.get(0).add(new ArrayList<Integer>());
        nums.get(0).get(2).add(1);
        nums.get(0).get(2).add(2);
        nums.get(0).get(2).add(3);

        nums.add(new ArrayList<ArrayList<Integer>>());
        nums.get(1).add(new ArrayList<Integer>());

        nums.get(1).get(0).add(1);
        nums.get(1).get(0).add(2);
        nums.get(1).get(0).add(3);
        nums.get(1).get(0).add(4);
        nums.get(1).get(0).add(5);
        nums.get(1).get(0).add(6);

        nums.get(1).add(new ArrayList<Integer>());
        nums.get(1).get(1).add(1);
        nums.get(1).get(1).add(2);
        nums.get(1).get(1).add(3);

        nums.get(1).add(new ArrayList<Integer>());
        nums.get(1).get(2).add(1);
        nums.get(1).get(2).add(2);
        nums.get(1).get(2).add(3);

        addNum(nums);

        System.out.println(nums);
    }

    private static void addNum(ArrayList<ArrayList<ArrayList<Integer>>> numbers) {
        for (int i = 0; i < numbers.size(); i++) {
            for (int j = 0; j < numbers.get(i).size(); j++) {
                for (int k = 0; k < numbers.get(i).get(j).size(); k++) {
                    numbers.get(i).get(j).set(k, numbers.get(i).get(j).get(k) + 1);
                }
            }
        }
    }


}
