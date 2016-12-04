# CharacterSheet

This is a character sheet in D&D connected to MySQL database.
You can select from the characters that appear in the Load/Save tab by clicking on them and then your character is loaded and you can play.
When you have stopped playing you can open the Load/Save tab and save your character.

The Database is 8 tables
race - the races of D&D 
class - classes of D&D
alignment - alignment of D&D

characters - name, race, class and alignment of the available characters - connects to the race, class, alignment tables
	   this table can't be updated. Each character has a CharacterID
stats - this table contains stats for every character, connected to characters on CharacterID. This table can be updated
abilities - this table contains abilities for every character, connected to characters on CharacterID. This table can be updated

There are also 2 other tables but the spell system is not ready
spell (all avilable spells in D&D)
char_spell (all the spells charactr has)

Author Ólafur Ásdísarson
