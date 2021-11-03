USE [TheBookShop]
GO

INSERT INTO [dbo].[BookShopAssets]
           ([Title]
		   ,[Cost]
		   ,[ImageUrl]
           ,[Author]
		   ,[ISNB]
           ,[Year]
           ,[Language]
           ,[CreateDate]
           ,[LastModifiedDate])
 VALUES
    ('Wilderness Essays', 25.00,'assets/images/wilderness_essays.png', 'John Muir', '1423607120', 2011, 'English', GETDATE(), GETDATE()),
	('The Art of Living: Peace and Freedom in the Here and Now', 25.00,'assets/images/art_of_living.png', 'Thich Nhat Hanh', '0062434667', 2017, 'English', GETDATE(), GETDATE()),
	('The Origin of Consciousness in the Breakdown of the Bicameral Mind', 25.00,'assets/images/origin_of_consciousness.png', 'Julian Jaynes', '', 1976, 'English', GETDATE(), GETDATE()),	
	('Thinking, Fast and Slow', 25.00,'assets/images/thinking_fast_slow.png', 'Daniel Kahneman', '0374533555', 2013, 'English', GETDATE(), GETDATE()),
	('Memories, Dreams, Reflections', 25.00,'assets/images/memories_dreams_reflections.png', 'Carl Jung', '9780679723950', 1989, 'English', GETDATE(), GETDATE()),
	('Fathers and Sons', 25.00,'assets/images/fathers_sons.png', 'Ivan Turgenev', '0553210890', 1862, 'English', GETDATE(), GETDATE()),
	('Classics of Russian Literature', 25.00,'assets/images/classics_russian_lit.png', 'Irwin Weil', '1423607120', 2011, 'English', GETDATE(), GETDATE()),
	('To Build a Fire, and Other Stories (The World''s Best Reading)', 25.00,'assets/images/to_build_a_fire.png', 'Jack London', '0895775832', 1994, 'English', GETDATE(), GETDATE()),
	('Zen and the Art of Motorcycle Maintenance', 25.00,'assets/images/zen_motorcycle.png', 'Robert Pirsig', '0060839872', 1974, 'English', GETDATE(), GETDATE()),
	('Sandworm: A New Era of Cyberwar and the Hunt for the Kremlin''s Most Dangerous Hackers', 25.00,'assets/images/sandworm.png', 'Andy Greenberg', '0525564632', 2019, 'English', GETDATE(), GETDATE()),
	('Dharma Bums', 25.00,'assets/images/dharma_bums.png', 'Jack Kerouac', '0140042520', 1976, 'English', GETDATE(), GETDATE()),
	('Dress Your Family in Corduroy and Denim', 25.00,'assets/images/dress_your_family.png', 'David Sedaris', '9780316143462', 2004, 'English', GETDATE(), GETDATE()),
	('Turing''s Cathedral: The Origins of the Digital Universe', 25.00,'assets/images/turings_cathedrall.png', 'George Dyson', '1400075998', 2012, 'English', GETDATE(), GETDATE()),
	('Thinking in Systems', 25.00,'assets/images/thinking_in_systems.png', 'Donella H. Meadows', '1603580557', 2008, 'English', GETDATE(), GETDATE()),
	('G�del, Escher, Bach: An Eternal Golden Braid', 25.00,'assets/images/geb.png', 'Douglas R Hofstadter', '0465026567', 1979, 'English', GETDATE(), GETDATE()),
	('The Lean Startup: How Today''s Entrepreneurs Use Continuous Innovation to Create Radically Successful Businesses', 25.00,'assets/images/lean_startup.png', 'Eric Ries', '1524762407', 2011, 'English', GETDATE(), GETDATE()),
	('The Seven Storey Mountain', 25.00,'assets/images/seven_storey_mountain.png', 'Thomas Merton', '0156010860', 1948, 'English', GETDATE(), GETDATE()),
	('Rework: Change The Way You Work Forever', 25.00,'assets/images/rework.png', 'Jason Fried and David Heinemeier Hansson', '1400075998', 2010, 'English', GETDATE(), GETDATE()),
	('The Waves', 25.00,'assets/images/waves.png', 'Virginia Woolf', '1789431492', 1931, 'English', GETDATE(), GETDATE()),
	('Collected Fictions', 25.00,'assets/images/collected_ficciones.png', 'Jorge Luis Borges', '0140286802', 1999, 'English', GETDATE(), GETDATE()),
	('Becoming', 25.00,'assets/images/becoming.png', 'Michelle Obama', '1524763136', 2018, 'English', GETDATE(), GETDATE()),
	('My Antonia', 25.00,'assets/images/my_antonia.png', 'Willa Cather', '0008352569', 1918, 'English', GETDATE(), GETDATE()),
	('The Golden Apples', 25.00,'assets/images/the_golden_apples.png', 'Eudora Welty', '015636090X', 1949, 'English', GETDATE(), GETDATE()),
	('Friend of My Youth: Stories', 25.00,'assets/images/friend_of_my_youth.png', 'Alice Munro', '0394584422', 1990, 'English', GETDATE(), GETDATE()),
	('Essays and Poems', 25.00,'assets/images/essays_and_poems_emerson.png', 'Ralph Waldo Emerson', '159308076X', 2012, 'English', GETDATE(), GETDATE()),
	('I Know Why the Caged Bird Sings', 25.00,'assets/images/caged_bird.png', 'Maya Angelou', '9780812980028', 1969, 'English', GETDATE(), GETDATE()),
	('One Man''s Wilderness, 50th Anniversary Edition: An Alaskan Odyssey', 25.00,'assets/images/one_mans_wilderness.png', 'Sam Keith and Richard Louis Proenneke', '1513261649', 1973, 'English', GETDATE(), GETDATE()),
	('Brothers Karamazov', 25.00,'assets/images/brothers_karamazov.png', 'Fyodor Dostoevsky', '0374528373', 1880, 'English', GETDATE(), GETDATE()),
	('Crime and Punishment', 25.00,'assets/images/crime_and_punishment.png', 'Fyodor Dostoevsky', '0679734503', 1866, 'English', GETDATE(), GETDATE()),
	('Song of Solomon', 25.00,'assets/images/song_of_solomon.png', 'Toni Morrison', '140003342X', 1977, 'English', GETDATE(), GETDATE()),
	('War and Peace', 25.00,'assets/images/war_and_peace.png', 'Leo Tolstoy', '1603580557', 1869, 'English', GETDATE(), GETDATE()),
	('Mrs. Dalloway', 25.00,'assets/images/mrs_dalloway.png', 'Virginia Woolf', '1950330745', 1925, 'English', GETDATE(), GETDATE()),
	('Their Eyes Were Watching God', 25.00,'assets/images/their_eyes_were_watching_god.png', 'Zora Neale Hurston', '9780061120060', 1937, 'English', GETDATE(), GETDATE());
GO

UPDATE [dbo].[BookShopAssets] SET
[Description] = 'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.'
GO
