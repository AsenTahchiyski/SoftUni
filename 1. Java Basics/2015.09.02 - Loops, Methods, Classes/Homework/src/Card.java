public class Card {
    private int face;
    private int suit;

    public Card(int face, int suit) {
        this.setFace(face);
        this.setSuit(suit);
    }

    public int getFace() {
        return this.face;
    }

    public void setFace(int setFace) {
        if (setFace < 0 || setFace > 13) {
            throw new IllegalArgumentException("No such face.");
        }
        this.face = setFace;
    }

    public int getSuit() {
        return this.suit;
    }

    public void setSuit(int setSuit) {
        if (setSuit < 0 || setSuit > 3) {
            throw new IllegalArgumentException("No such suit.");
        }
        this.suit = setSuit;
    }

    @Override
    public boolean equals(Object card) {
        boolean areEqual = false;
        if (card != null && card instanceof Card) {
            areEqual = (this.getFace() == ((Card) card).getFace() &&
            this.getSuit() == ((Card) card).getSuit());
        }
        return areEqual;
    }
}
