# Game Design Document (GDD)

## Table of Contents

- [Game Overview](#game-overview)
- [Story and Narrative](#story-and-narrative)
- [Gameplay and Mechanics](#gameplay-and-mechanics)
- [Levels and World Design](#levels-and-world-design)
- [Art and Audio](#art-and-audio)
- [User Interface (UI)](#user-interface-ui)
- [Technology and Tools](#technology-and-tools)
- [Team Communication, Timelines, and Task Assignment](#team-communication-timelines-and-task-assignment)
- [Possible Challenges](#possible-challenges)

---

## Game Overview

### Core Concept

<!-- Describe the main idea of your game in 2-3 sentences. What is the player’s role? How does the game incorporate the “Miniature” theme (e.g., small-scale world, tiny objects as landmarks)? -->

As major predators, humans sometimes kill smaller creatures, purely because they are afraid/annoyed at their existence. But what if the roles reversed, and you were forced to face insects and animals on their scale? This is what happens to Elara, when her battle with a colony of ants out of boredom, shifts to a battle for survival, when she suddenly shrinks to the size of an ant.  The main message is to be considerate of other forms of life around us: just because it seems insignificant to us it doesn’t mean it’s insignificant in the full scale of things. We learn this by changing our perspective on the world. Would you be able to survive this enlarged world, where your small problems become massive and your big problems seem so tiny? Or will you stick with your mindset always?

### Related Genre(s)

<!-- Specify the genre (e.g., platformer, puzzle, adventure) or cross-genre. List 1-2 similar games (e.g., from the inspiration list like Grounded or Tinykin) and explain how your game is different. -->

- **Genre**: Mainly Survival ( Arrietty is  fighting for her life) and Adventure (the player is forced to come up with creative solutions to the challenges, and exploring the area while always ready to fight). It’s a Platformer, where the environment is the main challeng, similarly to “Little Nightmares”. On a small-scale, it is also a role-Playing Game, since we have embedded concepts such as lives. 
- **Similar Games**: Grounded, It Takes Two, The Legend of Zelda: The Minish Cap.
- **Differences**: 
Grounded (similar concept in the garden, more focused on exploring rather than fighting), 
It Takes Two (heavy focus on collaboration), 
The Legend of Zelda: The Minish Cap (except our version involves an individual, not colony of people, fighting).

### Target Audience

<!-- Define the target audience (e.g., age group, interests). Ensure it’s feasible to recruit 10+ participants for user testing (e.g., students, gamers). How does the “Miniature” theme appeal to them? -->

Mainly young people, after some thrill and an adrenaline rush. People who enjoy action and are afraid of insects.

### Unique Selling Points (USPs)

<!-- List 3-5 key features that make your game stand out, especially related to the “Miniature” theme (e.g., unique mechanics, visual style, or narrative). Use bullet points for clarity. -->
- Visual style: realistic and a mixture between a positive space and a thrill environment.
- Narrative: Unlike other games previously mentioned, our game introduced the concept of Karma and there is the underlying moral message about being more considerate and aware of one’s surroundings. It doesn’t just teach you how to run away from challenges or fight them, rather it faces you with the consequences of your actions.
- Theme: Balance between Survival/trhill and adventure/explorations, while most other games tend to have a heavier focus on one.

_Visual Aid_:

<!-- Include at least one sketch, diagram, or image (e.g., concept art of the game world). Upload to repository (e.g., Assets/Sketches/) and link here using markdown: ![Description](path/to/image.png) -->

![Concept Art](Assets/Sketches/game_concept.png)

---

## Story and Narrative

<!-- If your game has no narrative, state that clearly and focus on the setting or atmosphere. Otherwise, describe the story and characters. -->

### Backstory

<!-- Describe the game’s setting and context in 2-4 sentences. Where does it take place (e.g., a tiny room, a model town)? What is the main conflict or goal? How does the “Miniature” theme shape the setting? -->

A young lady shrinks to the size of an ant and has to navigate across a garden to be able to reach the person of her dreams. The garden is depicted to be both beautiful but hostile. There are elements such as ants, grass, and water features which seems pretty and belonging to the landscape but are actually unforeseen elements of surprise to the lady who will make her journey an interesting one. The game shows off a small yet expressive protagonist against the world.

### Characters

<!-- List key characters (if any), including the player character. Describe their appearance, motivations, and role in the game. If no characters, describe the player’s role or entities in the world. -->

- **Player Character**: Elara. Early teens, first love. Deeply in love → Curious, resourceful but stubborn. Appearance: Big eyes, anime like. Moves quickly.
- **Other Characters (if any)**: Eli. Appearing in Elara’s memory, thought to be gentle, a perfect first love for Elara. Big eyes, anime like. Moves quickly, not too masculine, cuteish like. 


### Environmental Threats

- Ants (CP1)

- Spider (CP2)

- Chicken (CP3)

_Visual Aid_:

<!-- Include a sketch or image of a character or setting (e.g., player character design). Upload to repository and link here. -->

![Character Sketch](Assets/Sketches/character_design.png)
![Ant Sketch 1](Assets/Sketches/ant1.png)
![Ant Sketch 2](Assets/Sketches/ant2.png)
![Spider Sketch 1](Assets/Sketches/spider1.png)
![Spider Sketch 2](Assets/Sketches/spider2.png)
![Spider Sketch 3](Assets/Sketches/spider3.png)
![Chicken Sketch 1](Assets/Sketches/chicken1.png)
![Chicken Sketch 2](Assets/Sketches/chicken2.png)


---

## Gameplay and Mechanics

### Player Perspective

- **Camera Details**: The camera is dynamic and movable it follows the player automatically with smooth panning, but players can manually adjust zoom or angle slightly via mouse for scouting ahead or appreciating scale. In key moments like chases, it zooms out dramatically to show the vast environment. Fixed camera angles are used in puzzle sections for cinematic framing.

- **Player Character Visibility**: The girl is always visible on-screen, rendered as a detailed, expressive character model to build empathy. Her tiny size is contrasted against massive garden elements (e.g., an ant towering over her like a dinosaur), making every interaction feel epic and immersive.

- **How It Enhances the Miniature Theme**: This perspective emphasizes scale and vulnerability by framing the world from a low, ground-level view—making grass look like forests, puddles like oceans, and cats like kaiju. The 2.5D style allows for depth illusions (e.g., parallax scrolling where distant objects move slower), heightening the sense of a sprawling, oversized garden. It avoids the disorientation of first-person while letting players see the girl's animations (e.g., struggling to climb a "mountainous" leaf), reinforcing her fragility and the theme's whimsy/horror blend. This setup also supports platforming precision without losing the wonder of exploration.

### Controls

<!-- List the control scheme (e.g., WASD for movement, mouse for camera). Explain why it’s intuitive and how it suits the “Miniature” theme (e.g., precise controls for navigating small spaces). -->

- **Movement**: Arrow keys (left/right for horizontal movement, up/down for climbing or swimming in applicable areas). This setup provides fluid, directional control, making it easy to dart through narrow grass blades or evade incoming hazards, enhancing the feeling of being a fragile speck in a gigantic environment.

- **Actions**: Spacebar to jump (with variable height based on hold duration for precise leaps over "chasms" like garden cracks); 'A' key for contextual actions (e.g., picking up tiny objects like pebbles to throw as distractions, or lightly "hitting" enemies to stun them briefly without full combat). These promote resourcefulness, tying into the theme by turning everyday garden items into survival tools.

- **Special Controls**:A pause menu ('Esc') allows inventory checks or quick saves at checkpoints

### Progression

<!-- Describe how the game progresses (e.g., levels, objectives). What challenges does the player face? How does difficulty increase? How can the player lose? Is there a scoring system? Why is it fun? -->

- **Objectives**: Guide the tiny girl across the oversized garden to reunite with her lover at the final edge without getting killed by the garden creatures.

- **Challenges**: The player must navigate three main checkpoints, each introducing unique threats: evading oversized ants blocking paths at the first instance, fighting a spider and then crossing a stream at the second instance, and outrunning a chicken at the third instance. Additional environmental hurdles like climbing garden tools or dodging raindrops as "boulders" add variety.

- **Difficulty**: Checkpoints grow progressively harder by increasing enemy damage to Elara, combining mechanics (e.g., simultaneous chases and terrain navigation)

- **Loss Condition**: The player starts with 100% health bar; losing x% occurs from enemy contact as explained in levels and checkpoints. Depleting health triggers a game over with a retry from the start or last checkpoint (health replenishes to 100% at checkpoints if any remain). Respawns at checkpoints encourage persistence without frustration.

- **Motivation**: The fun lies in the heart-pounding thrill of narrowly escaping insects just shy of a checkpoint, balanced by the emotional drive to reach the lover.

### Gameplay Mechanics

<!-- List core mechanics (e.g., jumping, collecting, puzzle-solving). Explain the rules governing the game world and how mechanics tie to the “Miniature” theme (e.g., interacting with oversized objects). -->

- [Pick Up and Throw Items]: Players can pick up small objects like pebbles, seeds, or leaf fragments using the 'A' key and throw them to distract or briefly stun insects like ants. Throwing follows a simple projectile arc, requiring timing and distance judgment. This mechanic ties to the "Miniature" theme by transforming tiny garden debris into vital survival tools, emphasizing the girl’s resourcefulness in a world where her small size prevents direct combat.

- [Swimming in Puddles]: Players swim in puddles or water droplets, treated as vast lakes due to the girl’s tiny scale. Swimming drains a stamina bar, depleting faster with currents or during chases (e.g., by a spider at checkpoint two). Players must reach floating objects like leaf rafts to rest, or risk drowning. Surface tension and ripples affect movement, demanding careful navigation. This enhances the "Miniature" theme by turning small puddles into oceanic challenges, highlighting the overwhelming scale of the environment.

- [Climbing Garden Tools and Surfaces]: Players can climb oversized garden tools (e.g., a shovel handle as a skyscraper) or surfaces like grass stalks and flower stems, using a grip meter. Climbing consumes stamina, and slippery surfaces (e.g., wet leaves) increase fall risk, with severe falls costing one heart. Players must time movements to avoid wind gusts or enemy disruptions. This mechanic connects to the "Miniature" theme by reimagining everyday objects as towering obstacles, underscoring the girl’s fragility and the epic scale of her journey.

_Visual Aid_:

<!-- Include a diagram or GIF of gameplay (e.g., a mockup of a level or mechanic). Upload to repository and link here. -->

![Gameplay Mockup](Assets/Sketches/gameplay_mockup.gif)

![Particle System](Assets/Sketches/particleSS1.png)

## Levels and World Design

### Game World

<!-- Describe the game world (e.g., a tiny garden, a clockwork town). Is it 2.5D or 3D? Does it scroll or use multiple levels? Is there a map/minimap? How does the “Miniature” theme shape the world? -->

The game takes place in Elara's backyard garden where she she magically shrinks to the size of an ant. She now has to navigate her way through the complex and bug filled garden to find the boy of her dreams. Through this adventure, she will grow stronger and have improved stamina as she clears through checkpoints.

The minature theme aesthetic is an enlargement of the real world garden Elara grew up in. Short grass becomes tall tree like plants, puddles on the ground appears to be like a pond, and the bugs becoming intimidating adversaries that Elara has to conquer while attempting to cross over the garden.

### Objects

<!-- List key objects in the world (e.g., oversized pencils, tiny vehicles). Describe their appearance, role, and interactions with the player or each other. -->
- Grass
- Flowers
- Soil
- Pebbles (sized like rocks)
- Water droplets on leaf
- Plants around the garden
- Shovel? Or other gardening tools

![Grass 1](Assets/Sketches/grass3.png)
![Grass 2](Assets/Sketches/grass4.png)
![Stone Sketch](Assets/Sketches/stone.png)

### Physics

<!-- Describe physics rules (e.g., gravity, collisions). How do objects move or interact? How does physics enhance the “Miniature” feel (e.g., exaggerated weight of small objects)? -->

The physics of the game follows that of real life. That includes the wind, ripples, leaves being blown, grass swaying, and player jump/ going underwater.

### Levels
#### Checkpoint 1
Objective:

- Elara (the character) has to get through the trail of ants. But how is she going to break and get an opening?

Enemy:

- Ants colony walking towards their destination. And the ants are blocking the path that Elara has to take to clear the checkpoint
- Elara picks up rock(s) and throws it at the ant to clear the path.
- When the rock successfully hits an ant (the ant trail disappears for a short period to allow Elara to get through). After x seconds the ant trail reforms.

Transition:

- She clears checkpoint 1 by reaching a specific zone.
- Then cue scene where it explains what Elara’s next challenge is. Then move on to checkpoint 2

Note:

If player does not clear checkpoint 1, player remains in checkpoint 1


#### Checkpoint 2
Objective:

- Elara fights the spider first who is in her path, and once she clears the spider she will be able to cross the stream that is in her path to checkpoint 3.

Enemy:

- The next enemy is the spider, Elara encounters a spider which suddenly emerged from the bush. She now has to face the spider, but the spider is aggressive and is protective of her area because of the water element nearby.
- The spider thinks that Elara wants to invade her space and hence proceeds to attack Elara. Elara has to fight the spider and she throws punches at the spider attacking the spider’s legs one at a time until the health of the spider depletes to 0. At the same time, the spider is also attacking Elara and each hit on Elara reduces her health by x%.
- Set the spider health setting to 1 hit on the leg to reduce 20% health (need to hit 5 times to kill spider)

Transition:

- After Elara clears the spider, she is safe to carry on to proceed to checkpoint 3. She moves to the zone to take her to checkpoint 3 and at the same time also replenishes her health back to 100%
- Cue scene to explain what the challenge for checkpoint 3 is. Then start checkpoint 3

Note:

If player clears checkpoint 1, then player can resume game from checkpoint 2. Do not need to restart from checkpoint 1.

#### Checkpoint 3
Objective:

- Elara has to avoid the chicken to reach her final checkpoint to win the game

Enemy:

- Elara faces her last adversity which is the chicken her mum keeps at home. Because of Elara’s tiny size (ant sized), she is seen as food by the chicken. The chicken chases her around while trying to jump on her. Her final challenge is to escape the chicken and reach the final safe zone where she clears the garden and finishes the game.
- Each hit taken from the chicken costs Elara 5% health.

Transition:

- Cue end credits scene

Note: If player clears checkpoint 3, then player can resume game from checkpoint 3. Do not need to restart from checkpoint 1/2.

_Visual Aid_:

<!-- Include a level map or sketch of the game world. Upload to repository and link here. -->

![Level Design](Assets/Sketches/level_map.png)

---

## Art and Audio

### Art Style

<!-- Describe the visual style (e.g., cartoonish, realistic, hand-crafted). What colors, shapes, and textures are used? How does the style reflect the “Miniature” theme? Reference similar games if applicable. -->

The overall art style is fantasy-realism, with a focus on natural, miniature environments. The overall aesthetic is heavily inspired by nature, specifically from a small, ground-level perspective. The art style should evoke a feeling of wonder, adventure, and calm. It transforms everyday nature into a beautiful, fantastical landscape filled with both small details and grand, immersive settings. The style should feel both realistic in its rendering of natural elements and fantastical in its perspective and use of light.

Subject Matter and Perspective
- Miniature world: Since the scale of the game is down to the scale of ants, most graphical representations appear from a  close-up perspective, since the world is seen from the viewpoint of a very small character.

- Natural World: The primary setting is a lush, natural environment filled with tall grass, lily pads, and dense forests. There is a focus on small creatures like centipedes and spiders, reinforcing the moral message of the game, drawing the auidience's attention to the often-overlooked details of the natural world.

- Characters: The main character is Mira, human. The 'enemies' are the small real creatuers, such as centipedes, spiders and ants.

Color and Lighting
Natural Color Palette: The colors are predominantly earthy and natural, with a strong emphasis on greens and browns. While the green is supposed to reflect the beauty of nature, a  blue tone and colder colors are used to recreate a thrill effect, for the supsense in the game. It also creates a subdued, magical and mysterious atmosphere. The aim is for the audience to admire the beauty and positivity of this miniature perspective on nature, but at the same time recognise the power and survival dynamic on this scale.

Natural and Volumetric Lighting: The lighting is Natural and well-lit. This type of lighting creates a sense of depth and wonder, highlighting specific elements and making the environment feel dynamic and alive. There should not be an excess of lighting, however, to retain the mysterious feel as Mira is fighting creatures and obstacles for her survival.

### Sound and Music

<!-- Describe sound effects (e.g., footsteps, item pickups) and music (e.g., whimsical or ambient). How do they enhance the “Miniature” theme? -->

- **Sound Effects**: [List key sounds and their purpose]
- **Music**: [Describe music style and mood]

### Assets

<!-- List artistic assets (e.g., models, textures, audio). Will you create them or source from the Unity Asset Store (only for art, not code)? Provide URLs or sources for external assets. -->

- [Asset 1]: [Description and source, e.g., Unity Asset Store URL]
- [Asset 2]: [Description and source]

_Visual Aid_:

<!-- Include concept art or a mood board for the art style. Upload to repository and link here. -->
![UI Wireframe](Assets/Sketches/moodbard_art.png)

![Art Style Mood Board](Assets/Sketches/art_moodboard.png)

---

## User Interface (UI)

<!-- Describe the UI elements (e.g., health bar, score display, menus). Explain their functionality and aesthetic. How do they match the “Miniature” theme and overall art style? Include a wireframe or sketch. -->

**Menu Screens:**

- Main Menu: Features a title screen with a lush, oversized garden backdrop. Options include "Start Game" and "Exit." A soft, glowing cursor shaped like a firefly allows selection, with subtle animations (e.g., petals falling) for charm.

- Pause Menu: Accessible via 'Esc,' it overlays a translucent leaf-like texture with options: "Resume," "Restart Checkpoint," and "Quit to Menu." The pause menu fades in/out to maintain immersion.

- Game Over Screen: Appears when all hearts are lost, showing a dramatic scene of the girl caught by an insect. Options are "Retry from Checkpoint" or "Return to Menu," with a motivational message tied to the lover’s reunion to encourage retrying.

**In-Game UI**:

- Health Bar: Three glowing hearts (shaped like tiny flower buds) in the top-left corner. Each heart pulses faintly; a lost heart darkens with a cracked effect.

- Objective Prompt: Text prompts appear briefly at the screen’s center during key moments.

- Checkpoint Indicator: A glowing marker appears at checkpoint entrances, pulsing to draw attention. Upon reaching it, a subtle "Checkpoint Reached" message fades in, accompanied by a soft chime.

**Aesthetic**:

The UI adopts a whimsical, organic art style with hand-drawn, watercolor-like textures to match the game’s 2.5D garden aesthetic. Elements like hearts and stamina bars resemble natural objects (buds, vines, pollen), blending seamlessly with the environment. Colors are soft greens, earthy browns, and vibrant floral hues, with glowing accents for readability. Fonts are elegant and handwritten, evoking a storybook feel that complements the "Miniature" theme’s blend of whimsy and danger.Animations (e.g., hearts pulsing, essence sparkling) mimic natural movements like wind or water, reinforcing the theme of being a small creature in a vast ecosystem.

The "Miniature" theme is enhanced by UI elements that feel like they belong in the girl’s world—e.g., menus styled as leaves or parchment, counters resembling pollen or dew. This creates a cohesive experience where the UI feels like an extension of the garden, not an overlay, immersing players in the tiny perspective.

_Visual Aid_:

<!-- Include a UI wireframe or screenshot. Upload to repository and link here. -->

![UI Wireframe](Assets/Sketches/ui_wireframe.png)

---

## Technology and Tools

<!-- List all tools used to create the game. Unity 6.1.x and GitHub are mandatory; include others (e.g., Blender, Audacity) with version numbers and justification. -->

- **Unity**: Version 6.1.x – Game development engine (required).
- **GitHub**: Version control and collaboration (required).
- [Tool 1]: [e.g., Blender 4.2 – For 3D modeling, used by team member X]
- [Tool 2]: [e.g., Audacity 3.6 – For audio editing, used for sound effects]

---

## Technology and Tools

<!-- List all tools used to create the game. Unity 6.1.x and GitHub are mandatory; include others (e.g., Blender, Audacity) with version numbers and justification. -->

- **Unity**: Version 6.1.x – Game development engine (required).
- **GitHub**: Version control and collaboration (required).

---

## Team Communication, Timelines, and Task Assignment

### Communication

<!-- Describe how the team will communicate (e.g., Discord, weekly meetings). Specify channels and ensure all communication is in English. -->

- **Primary Channel**: Whatsapp
- **Meeting Schedule**: Weekly in person every Thurday @ 10am
- **Language**: All communication in English.

### Task Assignment

<!-- List tasks for Milestone 2 and beyond, assigned to team members. Include roles (e.g., programmer, artist). Use a table for clarity. -->

| Team Member | Role               
| ----------- | ------------------ 
| Abraham    | Lead Developer |  
| Glen    | Developer     
| Elisa    | Lead Designer   


### Task Tracking

<!-- Specify the tool for task management (e.g., Trello, Monday.com). Include a link if applicable. -->

- **Tool**: Jira
- **Usage**: Each milestone in a sprint. Within each milestone are the task each member needs to complete. The to do, in progress and done task are displayed in a kanban board.

---

## Possible Challenges

<!-- List 3-5 potential challenges (e.g., technical, time, team dynamics). For each, describe how the team will address it. Use bullet points or a table. -->

| Challenge     | Description                       | Mitigation Plan                                                |
| ------------- | --------------------------------- | -------------------------------------------------------------- |
| Challenge 1 | Game Assest not interacting properly    |  Test interactions in Unity editor and apply fixes iteratively.
| Challenge 2 | Merge conflicts in GitHub| Pull request required before merging into main and having feature branches          |
| Challenge 3 |   Sticking to design guide        | Consult with team members before implement new elements |


## References

<!-- List any external resources used for inspiration or assets (e.g., Unity Asset Store links, tutorials). Update this as the project progresses. -->

- https://sketchfab.com/















