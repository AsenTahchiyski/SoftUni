import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Dragon {
    public static int totalDragons = 0;

    public static void main(String[] args) {
        Scanner scan = new Scanner((System.in));
        int startDragonsNumber = Integer.parseInt(scan.nextLine());
        List<Dragon> dragons = new ArrayList<>();
        for (int i = 1; i <= startDragonsNumber; i++) {
            Dragon dragon = new Dragon("Dragon_" + i, 0);
            int eggs = Integer.parseInt(scan.nextLine());
            for (int j = 0; j < eggs; j++) {
                Egg egg = new Egg(0, dragon);
                dragon.lay(egg);
            }

            dragons.add(dragon);
        }

        totalDragons = startDragonsNumber + 1;
        int years = Integer.parseInt(scan.nextLine());
        for (int i = 1; i <= years; i++) {
            String yearType = scan.nextLine();
            YearType yearFactor = YearType.valueOf(yearType);

            for (Dragon dragon : dragons) {
                passAge(dragon, yearFactor);
            }
        }

        for (Dragon dragon : dragons) {
            printAncestry(dragon, 0);
        }
    }

    public static void passAge(Dragon dragon, YearType factor) {
        dragon.age();
        dragon.lay();

        if (dragon.isAlive()) {
            for (Egg egg : dragon.getEggs()) {
                egg.setYearFactor(factor);
                egg.age();
                egg.hatch();
            }
        }

        for (Dragon child : dragon.getChildren()) {
            passAge(child, factor);
        }
    }

    public static void printAncestry(Dragon dragon, int indent) {
        StringBuilder indentString = new StringBuilder();
        for (int i = 0; i < indent; i++) {
            indentString.append(" ");
        }
        if (dragon.isAlive()) {
            System.out.println(indentString + dragon.getName());
        }
        for (Dragon child : dragon.getChildren()) {
            printAncestry(child, indent + 2);
        }
    }

    private final int AGE_DEATH = 6;
    private final int AGE_LAY_START = 3;
    private final int AGE_LAY_END = 4;
    private String name;
    private int age;
    private List<Egg> eggs;
    private List<Dragon> children;
    private boolean isAlive = true;

    public Dragon(String name, int age) {
        this.name = name;
        this.age = age;
        this.eggs = new ArrayList<>();
        this.children = new ArrayList<>();
    }

    public void lay() {
        if (this.age >= AGE_LAY_START && this.age <= AGE_LAY_END) {
            Egg egg = new Egg(-1, this);
            this.eggs.add(egg);
        }
    }

    public void lay(Egg egg) {
        this.eggs.add(egg);
    }

    public void addEggs(Egg egg) {
        this.eggs.add(egg);
    }

    public void age() {
        if (this.isAlive) {
            this.age++;
        }
        if (this.age == AGE_DEATH) {
            this.isAlive = false;
        }
    }

    public String getName() {
        return this.name;
    }

    public Iterable<Egg> getEggs() {
        return this.eggs;
    }

    public boolean isAlive() {
        return this.isAlive;
    }

    public Iterable<Dragon> getChildren() {
        return this.children;
    }

    public void increaseOffspring(Dragon baby) {
        this.children.add(baby);
    }
}

class Egg {
    private final int AGE_HATCH = 2;
    private YearType yearFactor;
    private int age;
    private Dragon parent;

    public Egg(int age, Dragon parent) {
        this.age = age;
        this.parent = parent;
    }

    public void age() {
        this.age++;
    }

    public void hatch() {
        if (this.age == AGE_HATCH) {
            int yearFactor = this.yearFactor.ordinal();
            for (int i = 0; i < yearFactor; i++) {
                Dragon baby = new Dragon(
                        this.parent.getName()
                                + "/"
                                + "Dragon_"
                                + Dragon.totalDragons,
                        -1);
                this.parent.increaseOffspring(baby);
                Dragon.totalDragons++;
            }
        }
    }

    public void setYearFactor(YearType yearFactor) {
        this.yearFactor = yearFactor;
    }
}

enum YearType {
    Bad,
    Normal,
    Good
}