# Project 2 Report

Read the [project 2
specification](https://github.com/feit-comp30019/project-2-specification) for
details on what needs to be covered here. You may modify this template as you
see fit, but please keep the same general structure and headings.

Remember that you should maintain the Game Design Document (GDD) in the
`README.md` file (as discussed in the specification). We've provided a
placeholder for it [here](README.md).

## Table of Contents

- [Evaluation Plan](#evaluation-plan)
- [Evaluation Report](#evaluation-report)
- [Shaders and Special Effects](#shaders-and-special-effects)
- [Summary of Contributions](#summary-of-contributions)
- [References and External Resources](#references-and-external-resources)

## Evaluation Plan

### 1. Goals

The main goal of this evaluation is to identify how players experience _Garden of Love_ in terms of **usability**, **clarity of controls**, and **emotional engagement**.  
We aim to answer:

- Do players understand how to control Elara and navigate the environment?
- Are the objectives clear and achievable without explicit guidance?
- Does the environment and story evoke curiosity, empathy, or immersion?
- Are there any frustrating design elements (camera angles, movement, lighting)?

### 2. Evaluation Techniques

We will use **one observational** and **one querying** method, following COMP30019 requirements.

| Technique Type    | Method                                    | Description                                                                                                                                                                                                   | Participants |
| ----------------- | ----------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------ |
| **Observational** | _Think-Aloud Playtesting_                 | Players will play through the first level while narrating their thoughts (“I think I need to jump here…”, “I’m not sure what to do next”). Observers will take notes on confusion, hesitation, and reactions. | 5            |
| **Querying**      | _Post-Play Google Form + Short Interview_ | After playing, participants will complete a short online questionnaire (using a Google Form) and optionally engage in a 5–10 minute follow-up discussion about their experience.                              | 5            |

**Why these methods:**  
They provide both quantitative and qualitative feedback “Think-Aloud” reveals where players struggle in real time, and post-play questionnaires help capture overall impressions and satisfaction.

### 3. Participant Recruitment

| Criteria                 | Description                                                                                   |
| ------------------------ | --------------------------------------------------------------------------------------------- |
| **Target Audience**      | Casual gamers, students aged 18–25 familiar with adventure or puzzle games.                   |
| **Recruitment Strategy** | Post a short call for participants in class Discord/Group Chat, or invite friends/classmates. |
| **Inclusion Criteria**   | Must have basic familiarity with 3D movement controls and play for at least 10 minutes.       |
| **Diversity Goal**       | Aim for varied gaming experience and gender balance.                                          |

### 4. Tasks for Participants

1. Play through the tutorial or first level of _Garden of Love_ (~5–10 mins).
2. Try to reach the garden gate while avoiding obstacles (cat, ants, etc.).
3. Speak aloud while playing (for think-aloud test).
4. After completing the level:
   - Fill out the **Google Form questionnaire** (usability, enjoyment, difficulty ratings).
   - Participate in a short **informal conversation/interview** about what they liked/disliked.

**Google Form Example Sections:**

- “How enjoyable was the game?” (1–7 scale)
- “Did you clearly understand your objective?” (Yes/No + optional comment)
- “What did you find confusing?” (short text)
- “Would you play again?” (Yes/No)
- Optional: open-ended “Any suggestions for improvement?”

### 5. Data Collection

| Data Type                     | Collection Method                                                     | Tools                                |
| ----------------------------- | --------------------------------------------------------------------- | ------------------------------------ |
| **Player observations**       | Notes during think-aloud sessions (hesitations, confusion, comments). | Pen & paper / Google Docs            |
| **Screen or audio recording** | Optional for recall and post-task review.                             | OBS Studio / phone camera            |
| **Questionnaire data**        | Ratings and text responses from Google Form.                          | Google Forms (auto export to Sheets) |
| **Interview feedback**        | Short transcriptions of post-play conversations.                      | Voice memo or manual notes           |

### 6. Data Analysis

| Data Source             | Analysis Method                                                        | Metrics                                             |
| ----------------------- | ---------------------------------------------------------------------- | --------------------------------------------------- |
| **Observational notes** | Identify recurring issues (e.g., repeated confusion at same obstacle). | Frequency of confusion, duration to complete level. |
| **Questionnaire**       | Compute average satisfaction/usability ratings.                        | SUS-style score or custom mean ratings.             |
| **Interviews**          | Group responses into themes (controls, visuals, difficulty, story).    | Frequency of comments by theme.                     |

**Key Success Indicators:**

- ≥ 70% of players find controls intuitive.
- ≥ 80% complete the first level successfully.
- Average enjoyment score ≥ 5/7.

### 7. Timeline

| Week    | Task                                                                     |
| ------- | ------------------------------------------------------------------------ |
| Week 9  | Prepare Google Form, consent form, and observation checklist.            |
| Week 10 | Recruit participants.                                                    |
| Week 11 | Conduct think-aloud tests + collect Google Form responses.               |
| Week 12 | Analyse feedback, implement design improvements before final submission. |

### 8. Responsibilities

| Team Member | Task                                                |
| ----------- | --------------------------------------------------- |
| Elisa       | Participant recruitment and scheduling              |
| Glen        | Observation + note-taking during tests              |
| Elisa       | Conduct post-play interviews                        |
| Abraham     | Analyse questionnaire results                       |
| All         | Discuss feedback and apply improvements to the game |

---

## Evaluation Report

### 1. Overview

We conducted user testing with **10 participants** using both **observational think-aloud playtesting** (5 players) and **post-play Google Form feedback** (5 players).  
The purpose was to identify usability issues, gameplay clarity, and player engagement in _Garden of Love_.  
The testing focused on the first level where Elara encounters ants, collects a stone, and clears the path to progress.

---

### 2. Participant Demographics

| Metric                   | Range / Notes                                       |
| ------------------------ | --------------------------------------------------- |
| **Age Range**            | 20–25 years                                         |
| **Gender Balance**       | 4 Male, 1 Female in form responses; mix in total 10 |
| **Gaming Experience**    | Mostly casual or occasional players                 |
| **Playtime per session** | ~10–15 minutes                                      |

---

### 3. Methodology

- **Think-Aloud Testing (5 participants):**  
  Each player was observed while narrating their thoughts aloud during gameplay. Observers noted moments of hesitation, confusion, and satisfaction.  
  See [`interview_notes.txt`](Assets/Data/interview_notes.txt) for full transcripts.

- **Google Form Questionnaire (5 participants):**  
  A short form collected quantitative and qualitative feedback on enjoyment, difficulty, and clarity.

- **Follow-up Conversations:**  
  After each session, brief chats were held to clarify what players found confusing or enjoyable.

---

### 4. Results Summary

| Category                 | Key Findings                                                                                                                          |
| ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------- |
| **Controls & Gameplay**  | Average ease-of-control rating: **5.6/7** — players generally found controls intuitive, though some mentioned movement felt “floaty.” |
| **Challenge Level**      | Average difficulty rating: **3.6/7** — slightly easy overall; some wanted more challenge.                                             |
| **Enjoyment**            | Average enjoyment rating: **5.2/7** — players liked the visuals and tiny-world atmosphere.                                            |
| **Objective Clarity**    | Average clarity rating: **5.6/7** — most players understood they needed to eliminate the red ant to progress.                         |
| **Visuals & Atmosphere** | Average immersion rating: **5.6/7** — players described the lighting and garden as “cozy” and “immersive.”                            |
| **Confusion Points**     | 4/5 form respondents and 3/5 observational participants couldn’t find the stone easily; some wandered off-map or hit invisible edges. |
| **Story Connection**     | 4/5 said “Yes” to feeling connected to Elara’s journey; 1 said “Somewhat.”                                                            |

**Common Comments (from Forms + Think-Aloud):**

- “Finding the rock was the hardest part.”
- “Loved the atmosphere — felt tiny in a huge world.”
- “Would like clearer borders or camera hints.”
- “Red ant battle was satisfying.”

---

### 5. Interpretation

From both observational and questionnaire data, we found that:

- The **core gameplay loop** (collect → throw → clear path) was understood and satisfying.
- The **largest usability issue** was locating the stone and understanding world boundaries.
- Players responded positively to the **scale and art direction**, indicating strong emotional engagement.

These insights support our design goal of creating a whimsical yet slightly challenging experience.

---

### 6. Changes Implemented

Based on player feedback, the following improvements were made:

- **Boundary guidance:** Added invisible walls to prevent players from leaving terrain.
- **Rock visibility:** Increased stone size and added a subtle glow outline to highlight interactable items.
- **Camera tuning:** Smoothed vertical rotation to reduce floaty feel.
- **Feedback cues:** Added a small particle burst and sound when hitting the red ant.
- **Objective clarity:** Updated pop-up message to appear earlier and remain longer on screen.

---

### 7. Reflection

The evaluation demonstrated the value of combining observational and survey-based techniques:

- Observations revealed moment-to-moment struggles (e.g., finding the rock).
- The Google Form quantified enjoyment and usability trends.

If repeated, we would:

- Include video capture for more detailed behavioral analysis.
- Expand testing to additional levels for pacing and story evaluation.

Overall, the evaluation confirmed that the game’s mechanics are intuitive and enjoyable, with clear areas for polish before final release.

---

### 8. Supporting Files

- [`Assets/Data/GardenofLovePlaytestFeedback(Responses).csv`](<Assets/Data/GardenofLovePlaytestFeedback(Responses).csv>)
- [`Assets/Data/interview_notes.txt`](Assets/Data/interview_notegit s.txt)

## Shaders and Special Effects

Shader 1. Water Flow
[`Assets\Shaders\riverFlow.shader`](Assets\Shaders\riverFlow.shader)

[`Assets\Images\water_ripple.png`](Assets\Images\water_ripple.png)
[`Assets\Images\water_ripple(2).png`](<Assets\Images\water_ripple(2).png>)
The first shader is used to simulate the movement of a small stream flowing though the garden. The main effects it is responsible for:

- river flowing with direction of current
- ondulating water movement to add volume to the river flow
- water transparency and reflection at the surface, as well as other ambient and diffuse lighting
- ondulated surface texture with noise to appear more irregular/ less flat
- ripple effect as the character moves through the water.

The "River Flow (Procedural - Lit Final)" shader file follows a pipeline from Vertex Displacement, mainly responsible for calculating the vertex displacement for the ripple effect, to a Fragment Shading to add a more natural appearance to the water.

A. Vertex Shader: Geometry and Interaction
The Vertex Shader (vert) works with the geometric manipulation, through vertiex dispacement, and data perparation for the Fragment Shader.

Context: Vertex Displacement and Normals
The shader achieves the physical water movement through World-Space Vertex Displacement.

Displacement:
Here is an outline of the process creating the visible water ripples caused by the character and the ambient flow. The function GetRippleDisplacement(float3 worldPos) calculates a vertical offset for each vertex. It is then combined with the continuous sin wave (existingWave) and added to the vertex's Y-coordinate (worldPos.y += totalOffset;).

Recalculated Normals: Next, we adjust the original mesh for lighting, since the vertices have physically been moved. The vert function calculates a new worldNormal by sampling the displacement function at slightly offset points (epsilon). This numerically derived normal rerepresentsflects the slope of the displaced surface and is crucial for accurate lighting in the next stage.

C# Script-to-Shader Communication
File used: [`Assets\StarterAssets\ThirdPersonController\Scripts\WaterDetector.cs`](Assets\StarterAssets\ThirdPersonController\Scripts\WaterDetector.cs)

The centre of the ripple is derived from the character's position in the world (\_CharacterWorldPos) as a Uniform Parameter. This ensures a direct link between the game state and shader's geometric calculation. For example, to calculate the radius of the ripples (float rippleDistance = distance(charXZ, waterXZ);), the WaterDetector.cs extracts character's position from the shader and passes it on to the material.

B. Fragment Shader: Color and Lighting
The Fragment Shader (frag) runs once for every pixel covered by the water mesh annd is responsible for determining the final color (SV_Target), incorporating texture, color, lighting, and transparency.

Context: Lighting Model and Color
This shader uses a simplified Phong lighting model, combining ambient lighting, diffuse fighting and specular highlight (finalSpecular). The latter uses the viewDir and surface normal to calculate a bright reflection based on \_Glossiness and \_SpecularColor.

It is good to mention all the uniform parameters used in the fragment shader: \_Color, \_Opacity, \_SpecularColor, \_Glossiness, \_RippleRadius, \_RippleStrength, \_RippleFrequency, \_RippleSpeed, , \_NormalMap, \_NormalMap_ST, \_NormalStrength.

These can all be adjusted in the game, to generate the bes settings for a realistic effect of the water.

Context: Transparency and Rendering Queue
The transparency of the water is a render state controlled outside the fragment function:

Render Queue: The tag Tags { "Queue" = "Transparent" } ensures the water is rendered after all opaque objects (e.g., the riverbed). This is essential for transparency to work, as the objects behind the water must be drawn first.

ZWrite and Blending: Setting ZWrite Off prevents the water from writing its depth to the depth buffer, which would otherwise incorrectly hide submerged geometry. The Blend SrcAlpha OneMinusSrcAlpha mixes the water's color, scaled by its alpha (albedo.a = \_Opacity;) with the background color to create the visual blending effect.

Accompanying effects:
Buoyancy and Current Force.

There are two forces applied to Elara as she enters the water. The first is buoyancy, to accound for the water density. The second is the current's force, that forces Elara to the other side of the terrain, if she doesn't swim across fast enough. In the WaterDeetctor C# Script, we calculate the magnitude and direction of these forces to be applied, based on elara's current position. We then call function defined in the character's controller script to apply the calcculated forces on the character.

Shader 2.
[`Assets\Shaders\grassWind.shader`](Assets\Shaders\grassWind.shader)
This shader is used to simulate the wind effect on grass. It adds an exponential bending effect to the grass, to add some fluid motion to the scene.

[`Assets\Images\grass_result.png`](Assets\Images\grass_result.png)

VERTEX SHADER
The vertex shader adds the sinusoidal motion to the grass in the following line (float windStrength = sin(\_Time.y _ \_WindSpeed) _ \_WindMagnitude;). The motion depends on the wind magnitude, wind speed and the time that has elapsed. This ensures a constant oscillating movement over time.

Next, we ensure that the bending of the grass is expoinential(ie the tip of the grass gets bend further than it's roots), which appear more natural as opposed to the grass bending flat like a straight line.

float curveFactor = pow(heightFactor, \_BendCurvePower);
float2 horizontalDisplacement = windDirection _ windStrength _ curveFactor;

In the above lines, we ensure the horizonatal movement of the grass does not only depend on the wind (strength and magitude) but also a curve factor, which adds the exponential factor.

FRAGMENT SHADER
In this shader, not many visual effects were needed, since the wind usually does not impact the texture, opacity or reflections on the grass. Instead, this shader is used for rendering the texture and clipping. Since the texture is rendered from an image, it is important its edges are clipped and its bacground is transparent.

---

## Character Animation System

The game features a comprehensive animation system for the protagonist Elara, integrating seamlessly with Unity's Animator Controller and triggered dynamically through C# scripts. All animations use humanoid rigs sourced from Mixamo and configured to work with Unity's Third Person Controller.

### Animation Implementation Overview

Elara's animations are managed through Unity's Animator Controller using a combination of trigger parameters and boolean states. The animations are triggered by player input and game events, creating responsive and immersive gameplay.

### 1. Attack Animation

**Trigger Parameter:** `Attack`
**Script:** [`Assets/Scripts/PlayerMeleeAttack.cs`](Assets/Scripts/PlayerMeleeAttack.cs)
**Activation:** F key or left mouse button

The attack animation plays when Elara engages in melee combat with enemies (spiders). Key features:

- Triggered every time the player presses F or clicks
- Animation plays instantly with no exit time from locomotion states
- Damage is only applied on every 2nd attack to balance gameplay difficulty
- Returns to idle/walk/run blend state after completion
- Integrated with sphere overlap and raycast detection for hit registration

**Implementation Details:**

```csharp
// Line 59 in PlayerMeleeAttack.cs
animator.SetTrigger("Attack");
```

The attack uses a punch animation configured with:

- No loop time (single execution)
- Fast transition duration (0.1-0.15s) for responsive combat
- Automatic return to locomotion state after animation completes

---

### 2. Swimming Animation

**Boolean Parameter:** `IsSwimming`
**Script:** [`Assets/StarterAssets/ThirdPersonController/Scripts/ThirdPersonController.cs`](Assets/StarterAssets/ThirdPersonController/Scripts/ThirdPersonController.cs)
**Activation:** Automatic when entering water triggers

The swimming animation activates when Elara enters water bodies, creating a seamless transition from land-based movement.

**Implementation Details:**

```csharp
// Line 216 in ThirdPersonController.cs
_animator.SetBool(_animIDIsSwimming, InWater);
```

Water detection is handled by [`WaterDetector.cs`](Assets/StarterAssets/ThirdPersonController/Scripts/WaterDetector.cs), which:

- Sets `InWater = true` when player enters water trigger zones
- Applies buoyancy forces for realistic floating
- Creates ripple effects in the water shader at the character's position
- Applies current forces to push the player downstream

Swimming animation features:

- Looped animation for continuous swimming motion
- Synchronized with water physics (buoyancy and currents)
- Smooth blending with locomotion states when entering/exiting water
- Integrated with the procedural water shader for visual feedback (ripples)

---

### 3. Pick Up Animation

**Trigger Parameter:** `PickUp`
**Script:** [`Assets/Scripts/StonePickupController.cs`](Assets/Scripts/StonePickupController.cs)
**Activation:** E key when near a stone

The pickup animation plays when Elara collects stones from the environment, which are used as projectiles to defeat enemies.

**Implementation Details:**

```csharp
// Line 194-196 in StonePickupController.cs
if (animator != null)
{
    animator.SetTrigger("PickUp");
}
```

Pickup system features:

- Raycast detection to identify nearby stones within pickup range
- Visual UI prompts indicating when stones are available for pickup
- Bend-down animation (e.g., "Crouch to Stand") for realistic collection
- Stone becomes parented to camera view after pickup, visible in player's hand
- No loop time; returns to locomotion after completion

---

### 4. Throw Animation

**Trigger Parameter:** `Throw`
**Script:** [`Assets/Scripts/StonePickupController.cs`](Assets/Scripts/StonePickupController.cs)
**Activation:** E key while holding a stone

The throw animation plays when Elara throws a collected stone at enemies or obstacles.

**Implementation Details:**

```csharp
// Line 226-228 in StonePickupController.cs
if (animator != null)
{
    animator.SetTrigger("Throw");
}
```

Throwing mechanics:

- Overhand throw animation (e.g., "Baseball Pitch" or "Overhand Throw")
- Physics-based projectile with calculated throw direction based on camera forward vector
- Slight upward arc added for natural projectile trajectory
- Stone applies damage to enemies on collision
- Animation completes and returns to locomotion state
- Stone respawns at designated spawn points after being thrown

---

### 5. Death Animation

**Trigger Parameter:** `Death`
**Script:** [`Assets/Scripts/PlayerHealth.cs`](Assets/Scripts/PlayerHealth.cs)
**Activation:** Automatic when health reaches 0

The death animation plays when Elara's health is depleted by enemy attacks, creating a dramatic game-over sequence.

**Implementation Details:**

```csharp
// Line 96 in PlayerHealth.cs
animator.SetTrigger("Death");
```

Death sequence features:

- Triggers when current health reaches 0
- Third Person Controller is disabled to prevent movement during death
- Animation plays for configurable delay (default 2 seconds)
- Game Over menu appears after animation completes
- No return transition (player remains in death state until scene restart)
- Prevents multiple death calls with boolean flag check

Health system integration:

- Visual health bar with color gradient (green → red)
- Sound effects play on damage received
- Death is irreversible until scene restart via checkpoint system

---

### Animation Configuration

All animations follow a consistent configuration pattern:

1. **Rig Setup:** Humanoid avatar with "Create From This Model"
2. **Animation Import:** Bake Into Pose enabled for all root transform components
3. **Loop Settings:** Disabled for one-shot animations (attack, pickup, throw, death); enabled for swimming
4. **Transitions:** Fast transitions (0.1-0.2s) for responsive gameplay
5. **Exit Time:** Disabled for instant triggers (attack, pickup, throw, swimming); enabled for completion-based returns

### Integration with Game Systems

The animation system is tightly integrated with:

- **Combat System:** Attack animations synchronized with damage application
- **Water Physics:** Swimming animations coupled with buoyancy and current forces
- **Object Interaction:** Pickup/throw animations linked to stone spawning and physics
- **Health System:** Death animation triggers game state changes
- **Checkpoint System:** Scene restart resets all animation states

This comprehensive animation system creates responsive, immersive character interactions that enhance the player's experience in the miniature garden world.

---

## Enemy Behavior and Animation System

The game features three distinct enemy types, each with unique behaviors and animations that create varied gameplay challenges. All enemies use custom AI scripts and animation systems to create believable, interactive obstacles throughout Elara's journey.

### Ants

**Script:** [`Assets/Scripts/AntManager.cs`](Assets/Scripts/AntManager.cs)
**Behavior Type:** Patrol with Leader-Based Elimination

The ants exhibit consistent crawling behavior, moving in a straight line as a unified group. They represent a collective obstacle rather than individual threats, creating the illusion of a busy ant trail that adds environmental depth to each level.

**Key Behavioral Features:**

- **Unified Movement:** The entire ant colony moves together in a straight line, following a predetermined path
- **Non-Reactive:** Ants do not react to the player's presence during normal gameplay, maintaining their patrol pattern
- **Leader-Based Mechanics:** The colony is controlled by a leader ant that determines the group's movement
- **Elimination Mechanic:** When the leader ant is struck by a thrown stone, the entire army of ants disappears simultaneously
- **Strategic Gameplay:** This creates a clear path for the player to proceed, encouraging strategic stone usage

**Animation States:**

- Continuous crawling animation synchronized across all ants in the colony
- Coordinated movement that maintains formation consistency
- Instant disappearance effect when the leader is eliminated

The ant colony design emphasizes environmental storytelling and strategic decision-making, requiring players to identify and target the leader to progress.

---

### Spider

**Script:** [`Assets/Enemies/Animal/Chicken/Scripts/SpiderAI.cs`](Assets/Enemies/Animal/Chicken/Scripts/SpiderAI.cs)
**Behavior Type:** Territorial Defender with Detection and Attack States

The spider serves as a territorial enemy that idles within its designated area until the player enters its detection range. This creates tense encounters where players must either defeat the spider or carefully avoid its territory.

**Key Behavioral Features:**

- **Idle State:** The spider remains stationary or moves minimally within its territory, occasionally shifting position to simulate alertness
- **Detection System:** Uses sphere overlap or trigger zones to detect when the player enters its territorial range
- **Chase Behavior:** Upon detection, the spider transitions into an aggressive state and actively pursues the player
- **Attack Pattern:** Performs fast, lunging movements representing defensive strikes to protect its territory
- **Combat Mechanics:** The spider can damage the player upon successful attacks
- **Death Sequence:** When defeated by the player (via melee or thrown stones), a death animation is triggered, and the spider collapses and is removed from the environment

**Animation States:**

- **Idle Animation:** Subtle movements like leg adjustments and body shifts to convey alertness
- **Chase Animation:** Aggressive scuttling motion with increased speed
- **Attack Animation:** Fast lunge toward the player with strike motion
- **Death Animation:** Collapse sequence with gradual fade-out or disappearance

The spider's territorial nature reinforces combat-based gameplay mechanics, requiring players to master both melee combat and stone-throwing strategies to progress safely through infested areas.

---

### Chicken

**Script:** [`Assets/Scripts/ChickenManager.cs`](Assets/Scripts/ChickenManager.cs)
**Behavior Type:** Ambient to Hostile with Jump Attack Pattern

The chicken adds liveliness to the environment through ambient animations while transforming into an aggressive threat when the player approaches. This dual-nature creates unpredictable encounters that keep players alert.

**Key Behavioral Features:**

- **Idle Behavior:** Performs ambient animations such as walking, looking around, and pecking at the ground when the player is not nearby
- **Environmental Presence:** Creates a sense of a lived-in garden environment through natural chicken behaviors
- **Player Detection:** Monitors distance to the player and transitions to hostile state when within detection range
- **Chase Mechanics:** Actively pursues the player once hostile state is triggered
- **Jump Attack Pattern:** The chicken's primary attack involves repeatedly jumping toward the player as a form of offense
- **Persistent Aggression:** Once aggro'd, the chicken maintains hostile behavior until defeated or player escapes its pursuit range

**Animation States:**

- **Walk Animation:** Slow walking cycle with head-bobbing motion
- **Peck Animation:** Ground pecking idle animation for environmental realism
- **Look Around Animation:** Head turning and alert scanning behaviors
- **Chase Animation:** Faster running cycle with aggressive posturing
- **Jump Attack Animation:** Leaping motion toward the player with attack intent
- **Death Animation:** Collapse and removal from environment upon defeat

The chicken's transformation from peaceful ambient creature to aggressive attacker creates dynamic encounters that reward player awareness and quick reactions, adding variety to the combat experience beyond the more predictable spider encounters.

---

### Enemy System Integration

All three enemy types are integrated with the game's core systems:

- **Combat System:** Enemies can be defeated through melee attacks or thrown stones
- **Animation System:** Smooth state transitions between idle, chase, attack, and death animations
- **Detection System:** Sphere overlap, raycast, or trigger-based player detection
- **Health System:** Enemies deal damage to the player's health upon successful attacks
- **Stone Mechanics:** Strategic use of thrown stones is required for the ant colony leader

This diverse enemy roster creates varied gameplay challenges that require different strategies: strategic thinking for ants, combat proficiency for spiders, and situational awareness for chickens. Together, they provide a balanced progression of difficulty throughout Elara's journey through the garden.

---

## Summary of Contributions

### Abraham

**Role:** Player Systems & Narrative Design

Abraham was responsible for all aspects of the main protagonist Elara, including movement, gameplay mechanics, and narrative elements.

**Key Contributions:**

- **Character Movement & Animation System:**

  - Implemented and configured Unity's Third Person Controller for Elara
  - Integrated all character animations (attack, swimming, pickup, throw, death) with Mixamo
  - Configured Animator Controller with trigger parameters and state transitions
  - Implemented smooth camera controls and player input handling

- **Combat & Interaction Systems:**

  - Developed melee attack system with sphere overlap and raycast detection ([`PlayerMeleeAttack.cs`](Assets/Scripts/PlayerMeleeAttack.cs))
  - Implemented balanced damage system (every 2nd attack deals damage)
  - Created stone pickup and throwing mechanics ([`StonePickupController.cs`](Assets/Scripts/StonePickupController.cs))
  - Integrated object interaction with UI prompts

- **Player Health & Game Over System:**

  - Implemented player health system with visual health bar ([`PlayerHealth.cs`](Assets/Scripts/PlayerHealth.cs))
  - Created death sequence with animation integration
  - Developed Game Over menu and checkpoint restart system ([`gameOverMenu.cs`](Assets/Scripts/gameOverMenu.cs))
  - Implemented scene management for checkpoint-based progression

- **Water Interaction:**

  - Added swimming animation support to Third Person Controller ([`ThirdPersonController.cs`](Assets/StarterAssets/ThirdPersonController/Scripts/ThirdPersonController.cs))
  - Integrated character movement with water physics and shader effects

- **Narrative Design:**
  - Created and designed the opening backstory scene introducing Elara's journey
  - Developed the ending story scene providing narrative closure
  - Wrote dialogue and story elements connecting gameplay to narrative

**Files Created/Modified:**

- `Assets/Scripts/PlayerMeleeAttack.cs`
- `Assets/Scripts/PlayerHealth.cs`
- `Assets/Scripts/StonePickupController.cs`
- `Assets/Scripts/gameOverMenu.cs`
- `Assets/Scripts/Stone.cs`
- `Assets/Scripts/StoneSpawner.cs`
- `Assets/StarterAssets/ThirdPersonController/Scripts/ThirdPersonController.cs`
- Backstory Scene (Scene 0)
- End Story Scene (Scene 5)

---

### Glen

**Role:** Enemy AI & Combat Systems

Glen was responsible for designing and implementing all enemy types and their behaviors, creating challenging encounters throughout the game.

**Key Contributions:**

- **Spider Enemy System:**

  - Developed spider AI with patrol and chase behaviors ([`SpiderAI.cs`](Assets/Enemies/Animal/Chicken/Scripts/SpiderAI.cs))
  - Implemented spider health system and damage reception
  - Created attack patterns and player detection mechanics
  - Designed visual feedback for spider states (patrol/chase/attack)

- **Ant Enemy System:**

  - Created ant AI with swarm behavior and path following ([`LeaderAnt.cs`](Assets/Enemies/Animal/Chicken/Scripts/LeaderAnt.cs))
  - Implemented leader-follower formation for ant colonies
  - Designed ant attack patterns that damage the player on contact
  - Created ant spawn points and patrol routes

- **Chicken Enemy System:**

  - Developed chicken AI with wandering and flee behaviors
  - Implemented chicken animations (idle, walk, run)
  - Created non-hostile AI patterns for environmental variety

- **Enemy-Player Interaction:**

  - Integrated enemies with player health system for damage dealing
  - Implemented collision detection and attack triggers
  - Balanced enemy damage values and attack frequencies
  - Created visual and audio feedback for enemy encounters

- **Combat Balancing:**
  - Tuned enemy health pools and damage values
  - Adjusted AI detection ranges and chase speeds
  - Designed enemy placement throughout game levels for progressive difficulty

**Files Created/Modified:**

- `Assets/Enemies/Animal/Spider/Scripts/SpiderAI.cs`
- `Assets/Enemies/Animal/Spider/Scripts/SpiderHealth.cs`
- `Assets/Enemies/Animal/Chicken/Scripts/LeaderAnt.cs`
- `Assets/Enemies/Animal/Chicken/Scripts/` (various chicken scripts)
- Enemy prefabs and configurations for all three checkpoints

---

### Elisa

**Role:** Environment Design & Shader Programming

Elisa was responsible for all visual environments, scene design, and shader effects that bring the miniature garden world to life.

**Key Contributions:**

- **Shader Development:**

  - **Water Flow Shader** ([`Assets/Shaders/riverFlow.shader`](Assets/Shaders/riverFlow.shader)):

    - Procedural river flow with directional current
    - Ondulating water movement with volume
    - Water transparency and surface reflections
    - Character-triggered ripple effects using vertex displacement
    - Integration with C# scripts for dynamic ripple positioning
    - Phong lighting model with ambient, diffuse, and specular components

  - **Grass Wind Shader** ([`Assets/Shaders/grassWind.shader`](Assets/Shaders/grassWind.shader)):
    - Sinusoidal wind motion with configurable speed and magnitude
    - Exponential bending curve for natural grass movement
    - Time-based animation for continuous wind effect
    - Texture rendering with edge clipping and transparency

- **Scene Design & Environment:**

  - Designed all three checkpoint levels (Checkpoint 1, 2, 3)
  - Created immersive garden environments with varied terrain
  - Placed environmental objects, vegetation, and obstacles
  - Designed lighting setups for atmospheric garden ambiance
  - Implemented terrain sculpting and texturing

- **Water Physics Integration:**

  - Worked with Abraham to integrate water shader with character physics
  - Implemented buoyancy and current force calculations ([`WaterDetector.cs`](Assets/StarterAssets/ThirdPersonController/Scripts/WaterDetector.cs))
  - Created water trigger zones for swimming mechanics
  - Designed river paths and water body placements

- **Visual Effects:**

  - Created particle effects for environmental interactions
  - Designed visual feedback for combat (hit effects, damage indicators)
  - Implemented stone glow outlines for improved visibility
  - Added boundary guidance with invisible walls

- **Art Direction:**
  - Established the "tiny human in a giant garden" aesthetic
  - Selected and integrated environmental assets
  - Maintained consistent visual style across all scenes
  - Created atmospheric lighting and color palettes

**Files Created/Modified:**

- `Assets/Shaders/riverFlow.shader`
- `Assets/Shaders/grassWind.shader`
- `Assets/StarterAssets/ThirdPersonController/Scripts/WaterDetector.cs`
- `Assets/Scripts/waterController.cs`
- `Assets/Scripts/RiverCurrentForce.cs`
- `Assets/Scripts/RippleEffectSetter.cs`
- All scene files (Checkpoint 1, 2, 3)
- Terrain assets and environment configurations

---

### Collaborative Work

The team worked together on several integrated systems:

- **User Testing & Evaluation:**

  - All three members participated in conducting think-aloud playtesting sessions
  - Elisa: Participant recruitment and scheduling
  - Glen: Observation and note-taking during tests
  - Elisa: Conducted post-play interviews
  - Abraham: Analyzed questionnaire results and compiled evaluation report
  - All: Discussed feedback and implemented improvements

- **Gameplay Balancing:**

  - Iterative testing and adjustment of enemy difficulty (Glen)
  - Player movement and control tuning (Abraham)
  - Environmental obstacle placement and pacing (Elisa)

- **Integration Testing:**

  - Ensured character animations work with enemy AI
  - Verified water shader effects integrate with player movement
  - Tested stone throwing mechanics against enemy behaviors

- **Documentation:**
  - Abraham: Character animation system documentation
  - Elisa: Shader technical documentation
  - Glen: Enemy AI behavior documentation
  - All: Evaluation plan and report contributions

---

### Summary

Each team member brought specialized skills that complemented the others:

- **Abraham** created responsive, engaging player mechanics and narrative structure
- **Glen** designed challenging, varied enemy encounters that drive gameplay
- **Elisa** crafted the visual identity and technical shader effects that immerse players in the miniature world

Together, these contributions resulted in a cohesive gameplay experience where movement, combat, and environment seamlessly integrate to tell the story of Elara's journey through the Garden of Love.

## References and External Resources

### Animation Resources

**Mixamo**

- **URL:** https://www.mixamo.com
- **Purpose:** Character animations for Elara
- **Usage:** All protagonist animations including:
  - Attack/Punch animations for melee combat
  - Swimming animations for water interaction
  - Pickup/Crouch animations for stone collection
  - Throwing animations for projectile mechanics
  - Death animations for game over sequence
- **License:** Free for use in games and interactive media
- **Configuration:** All animations imported as FBX files with humanoid rigs, configured with "Create From This Model" avatar setup

---

### Audio Resources

**ElevenLabs**

- **URL:** https://elevenlabs.io
- **Purpose:** AI-generated voice narration
- **Usage:**
  - Backstory scene narration (Scene 0) - introducing Elara's journey and the Garden of Love
  - Final scene narration (Scene 5) - concluding the story and providing closure
- **Implementation:** Audio files integrated with Unity's AudioSource components, synchronized with scene transitions
- **License:** Used in accordance with ElevenLabs terms of service

---

### AI Image Generation

**Google Gemini (Imagen 3)**

- **Model:** Gemini Nano "Banana" variant
- **Purpose:** Black and white artistic illustrations
- **Usage:**
  - Visual storytelling images for backstory scene
  - Narrative illustrations for final scene
  - Artistic style: Black and white sketches to match the storybook aesthetic
- **Implementation:** Generated images imported as textures and displayed as UI elements during narrative scenes
- **License:** Used in accordance with Google's Gemini API terms

---

### Unity Assets and Packages

**Unity Starter Assets - Third Person Controller**

- **Source:** Unity Asset Store / Unity Technologies
- **Version:** Third Person Character Controller package
- **Usage:** Foundation for Elara's movement system, camera controls, and input handling
- **Modified Files:**
  - `ThirdPersonController.cs` - Added swimming animation support and water physics integration
  - Character controller prefab adapted for project-specific needs

**Unity Standard Assets**

- **Source:** Unity Technologies
- **Usage:** Base terrain textures, standard shaders, and environmental effects

---

### Development Tools

**Unity Engine**

- **Version:** 2022.3 LTS (or specify your version)
- **License:** Personal/Student license
- **Usage:** Primary game engine for development

**Visual Studio / Rider**

- **Purpose:** C# scripting and code development
- **Usage:** All gameplay scripts and shader development

**Git / GitHub**

- **Repository:** https://github.com/feit-comp30019/2025s2-project-2-gamify
- **Purpose:** Version control and team collaboration

**Claude Code (Anthropic)**

- **URL:** https://claude.com/claude-code
- **Purpose:** AI-assisted grammar correction and documentation formatting
- **Usage:**
  - Grammar correction and proofreading for technical documentation
  - Formatting improvements for report structure and clarity
- **Note:** All technical content and implementation decisions were made by the development team

---

### External Assets and Resources

**Shader References**

- Catlike Coding - Shader tutorials for understanding vertex displacement
- Unity shader documentation for implementing Phong lighting model
- Real-time water rendering techniques adapted from various graphics programming resources

**3D Models and Environment Assets**

_Enemy Models:_

- **Fantasy Spider**

  - Source: Unity Asset Store
  - URL: https://assetstore.unity.com/packages/3d/characters/animals/insects/fantasy-spider-236418
  - Usage: Spider enemy character model with animations
  - License: Unity Asset Store Standard EULA

- **Animals Free Pack**

  - Source: IT Happy Studios
  - URL: https://ithappystudios.com/free/animals-free/
  - Usage: Chicken character models and animations
  - License: Free for commercial and non-commercial use

- **Ant 3D Model**
  - Source: TurboSquid
  - URL: https://www.turbosquid.com/3d-models/ant-2225056
  - Usage: Ant enemy character model
  - License: TurboSquid Royalty Free License

_Environment Assets:_

- Unity Asset Store free packages for garden environment
- Terrain tools for landscape sculpting
- Vegetation and prop assets from Unity Asset Store

**Sound Effects**

- Unity's built-in audio system for playback and mixing
- Audio effects for gameplay sounds (footsteps, hits, environmental sounds)

---

### Learning Resources and References

**Unity Documentation**

- Unity Animator Controller documentation
- Unity Physics and Collision detection guides
- Unity Shader Graph and HLSL/Cg programming documentation

**Graphics Programming**

- "Real-Time Rendering" concepts for water shader implementation
- Phong lighting model implementation references
- Vertex displacement and normal recalculation techniques

**Game Design**

- Player feedback from think-aloud testing sessions (documented in evaluation)
- Iterative design based on playtesting results

---

### Attribution

All external resources have been used in accordance with their respective licenses and terms of service. Mixamo animations, ElevenLabs audio, and Google Gemini images are used under their standard terms for educational and game development purposes.

The team acknowledges the use of these resources while maintaining that all gameplay systems, custom shaders, level design, and integration work represent original contributions by the development team.
