string aliceQuote = (
    "Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing " +
    "to do: once or twice she had peeped into the book her sister was reading, but it had no pictures " +
    "or conversations in it, ‘and what is the use of a book,’ thought Alice ‘without pictures or " +
    "conversation?’"
);

Console.WriteLine("What word do you wish to find:");
string searchTerm = Console.ReadLine();

string aliceLowerQuote = aliceQuote.ToLowerInvariant();
bool foundTerm = aliceLowerQuote.Contains(searchTerm.ToLowerInvariant());

Console.WriteLine($"It is {foundTerm} that the term {searchTerm} is within the quote.");

// Expanded version of the code below

string aliceQuote = (
    "Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing " +
    "to do: once or twice she had peeped into the book her sister was reading, but it had no pictures " +
    "or conversations in it, 'and what is the use of a book,' thought Alice 'without pictures or " +
    "conversation?'"
);

string prompt = "What word do you wish to find:";
Console.WriteLine(prompt);

string searchTerm = Console.ReadLine();

string aliceLowerQuote = aliceQuote.ToLowerInvariant();
string lowerSearchTerm = searchTerm.ToLowerInvariant();

bool foundTerm = aliceLowerQuote.Contains(lowerSearchTerm);

string resultMessage = $"It is {foundTerm} that the term {searchTerm} is within the quote.";
Console.WriteLine(resultMessage);

//compressed verion of the code below

string aliceQuote = "Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing to do: once or twice she had peeped into the book her sister was reading, but it had no pictures or conversations in it, 'and what is the use of a book,' thought Alice 'without pictures or conversation?'";

Console.WriteLine("What word do you wish to find:");
string searchTerm = Console.ReadLine();

Console.WriteLine($"It is {aliceQuote.ToLowerInvariant().Contains(searchTerm.ToLowerInvariant())} that the term {searchTerm} is within the quote.");

string aliceQuote = (
    "Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing " +
    "to do: once or twice she had peeped into the book her sister was reading, but it had no pictures " +
    "or conversations in it, 'and what is the use of a book,' thought Alice 'without pictures or " +
    "conversation?'"
);

Console.WriteLine("What word do you wish to find:");
string searchTerm = Console.ReadLine();

string aliceLowerQuote = aliceQuote.ToLowerInvariant();
bool foundTerm = aliceLowerQuote.Contains(searchTerm);   // BUG: searchTerm is not lowercased

Console.WriteLine($"It is {foundTerm} that the term {searchTerm} is within the quote.");

/*
DEBUGGING PROCESS

1. Noticed the problem:
   I typed "alice" and the program said True. I typed "Alice" and it said False,
   even though "Alice" clearly appears in the quote.

2. Reproduced it:
   I tested a few more words in both lowercase and capitalized forms ("book" and "Book",
   "sister" and "Sister"). Lowercase always returned True. Any capital letter returned False.
   That pattern pointed to a capitalization problem.

3. Narrowed down the cause:
   I looked at the lines that handle capitalization. The quote is converted to lowercase
   with ToLowerInvariant(), but searchTerm is passed into Contains() exactly as the user
   typed it. So the program was searching a lowercase quote for "Alice" with a capital A,
   which can never match.

4. Fixed it:
   I changed the line to also lowercase the search term:
       bool foundTerm = aliceLowerQuote.Contains(searchTerm.ToLowerInvariant());

5. Tested the fix:
   I re-ran the same words from step 2. "Alice", "alice", "ALICE", "Book", and "book"
   now all return True, and a word that isn't in the quote, like "dragon", still returns False.
*/