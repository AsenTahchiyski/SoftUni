import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class p04_dragonArmy {
    private static int defaultHealth = 250;
    private static int defaultDamage = 45;
    private static int defaultArmor = 10;

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int totalDragons = Integer.parseInt(scan.nextLine());
        LinkedHashMap<String, TreeMap<String, int[]>> data = new LinkedHashMap<>();
        for (int i = 0; i < totalDragons; i++) {
            String line = scan.nextLine();
            String[] params = line.split(" ");
            String type = params[0];
            String name = params[1];
            String damageStr = params[2];
            int damage;
            if (damageStr.equals("null")) {
                damage = defaultDamage;
            } else {
                damage = Integer.parseInt(damageStr);
            }

            String healthStr = params[3];
            int health;
            if (healthStr.equals("null")) {
                health = defaultHealth;
            } else {
                health = Integer.parseInt(healthStr);
            }

            String armorStr = params[4];
            int armor;
            if (armorStr.equals("null")) {
                armor = defaultArmor;
            } else {
                armor = Integer.parseInt(armorStr);
            }

            int[] stats = {damage, health, armor};
            if (!data.containsKey(type)) {
                data.put(type, new TreeMap<>());
            }

//            if (!data.get(type).containsKey(name)) {
                data.get(type).put(name, stats);
//            }
        }

        for (String type : data.keySet()) {
            int avgDamage = 0;
            int avgHealth = 0;
            int avgArmor = 0;
            int allSuchDragons = 0;
            StringBuilder dragonOutput = new StringBuilder();
            TreeMap<String, int[]> theseDragons = data.get(type);
            for (Map.Entry<String, int[]> dragon : theseDragons.entrySet()) {
                int[] stats = dragon.getValue();
                int damage = stats[0];
                int health = stats[1];
                int armor = stats[2];
                avgDamage += damage;
                avgHealth += health;
                avgArmor += armor;
                allSuchDragons++;
                dragonOutput.append("-" + dragon.getKey() + " -> damage: " + damage +
                        ", health: " + health + ", armor: " + armor + "\n");
            }

            System.out.printf("%s::(%.2f/%.2f/%.2f)", type, (double)avgDamage / allSuchDragons,
                    (double)avgHealth / allSuchDragons, (double)avgArmor / allSuchDragons);
            System.out.println();
            System.out.print(dragonOutput.toString());
        }
    }
}
