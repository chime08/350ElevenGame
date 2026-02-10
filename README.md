# 🃏 Eleven Game
Eleven is card game where the player remove cards that eith sums up to 11 or form a card combination of J,Q,K

## Game Rules: 
1. Find a pair (A-10) that sums up to 11.
2. Or find a J, Q, K together.
3. Suits doesnot matter
4. Invalid selections are rejected
5. Wins when all cards are removed from the deck.
6. Loses when no valid set found to remove.

## How to Play
- The game starts with a shuffled deck of 52 cards
- Nine cards are dealt face-up on the table
- Players can select a valid match from the table to remove
- Valid Moves:
  a. A pair from A through 10 that sums up to 11. Example, 8 + 3, Ace + 10
  b. A set of J, Q, K together
- Once user selects the cards, system checks if its valid
- If valid, then the selected cards are removed from the table
- New cards are dealt from the deck o replace removed cads
- Repeat until you win or lose
- **Win**: All cards are removed from deck and table
- **Lose**: No legal moves on the rable

## Classes 
1. Card.cs: Represents a single card with value and suit
2. Deck.cs: Represents and manages the deck of cards with shuffle() and deal() methods
3. Table.cs: Manages the cards displayed on the table with remove() and replaced() methods. Also, displays the table with DisplayTable().
4. GameController.cs: Controls and game logic with StartGame(), submitSelection(), validateSelection() and checkEndState() methods.
5. Program.cs: Main entry point for the console application

## Use of AI 🤖
I primarily used **Claude AI** for AI assistance 
1. **C# syntax**
I had to look up for some C# synatx like _"Main(string[] args)"_

2. **Debugging**
   I was having constant issues with reading inputs.
_string input = Console.ReadLine();_
(Converting null literal or possible null value to non-nullable type.)
I was able to resolve the problem with _string input = Console.ReadLine() ?? "";_
_??_ operator means "if null, use empty string instead."

   
## Output Examples
### Valid Selection
<img width="1512" height="982" alt="Screenshot 2026-02-10 at 12 42 42 AM" src="https://github.com/user-attachments/assets/429f2c9d-b4bb-4f5a-adb6-eb69d7fe5f67" />

## Invalid Selection 
<img width="550" height="580" alt="Screenshot 2026-02-10 at 12 47 07 AM" src="https://github.com/user-attachments/assets/c55b8196-cfef-4239-964c-ae6b5deb64af" />

Submitted By: Chime Lhamo Gurung 

