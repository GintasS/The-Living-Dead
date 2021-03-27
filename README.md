<div align="center">
  <h2>The Living Dead</h2>
</div>

## Jump to...

  - [Intro](#intro)
  - [Features](#features)
  - [Planned Features](#PlannedFeatures)
  - [Third-Party Assets](#ThirdPartyAssets)
  - [Round System](#RoundSystem)
  - [Economy Overview](#EconomyOverview)
  - [Media](#media)
  - [Changelog](#changelog)

## <a name="Intro"></a>Intro

<p>This is my 3rd game made by Unity. I wanted to remake my 1st game that was based on zombies, but had all sorts of errors, shortcomings and etc.<br>
Your goal is to survive by shooting zombies and buying various items from the in-game shops.<br><br>
For this, you have two weapons:
  <ul>
    <li>a pistol</li>
    <li>an assault rifle with flashlight equipped</li>
  </ul>
</p>

You can download a .zip file from here: <a href="https://drive.google.com/file/d/1bxqf4s6_lIR9OIIaPSuih0fsy3PIWCv7/view?usp=sharing"> url</a>.

## <a name="Features"></a>Features

<ul>
 <li><b>Great graphics:</b> this project was done via HDRP(High Definition Render Pipeline).</li>
  <li><b>Exploration:</b> this is not a small map by any means, so you could take some time to explore it and feel it!</li>
  <li><b>Sound:</b> this game has both UI, environment, enemy and player sounds and more!</li>
  <li><b>Particle effects:</b> this game features some particle systems, like vent smoke, weapon fire or fog.</li>
  <li><b>Animations:</b> both the player and zombies have animations, e.g. attacking, running, reloading a weapon.</li>
  <li><b>Multiple Scenes:</b> game features few scenes, from the main scene, to the main menu, pause menu or a game over menu.</li>
  <li><b>Round System:</b> The Living Dead core mechanic is rounds: every round you get a random number of zombies and you must kill them to proceed to a next round.</li>
  <li><b>Shop System:</b> You can buy various items, from ammo to utilities that will help you to survive!</li>
  <li><b>Zombie Prevention System:</b> this prevents a zombie from being stuck right at his spawn point, so a player would not wander around looking for it or restart the game.</li>
</ul>

## <a name="PlannedFeatures"></a>Planned Features
<p>This is a list of features that I planned to implement, but due to various factors, such as time, I could not.</p>
<ul>
  <li>Inventory and Loot system</li>
  <li>Player throwables(grenades, mines and etc.)</li>
  <li>Interactable environment</li>
  <li>Killstreak/scorestreak system</li>
  <li>Different types of zombies</li>
</ul>

## <a name="ThirdPartyAssets"></a>Third-Party Assets
<p>In this game I used third-party assets, starting from 3d objects, audio to animations and particle effects.</p>

<table style="width:30%">
  <tr>
    <th>Asset Type</th>
    <th>Asset Name</th>
    <th>Asset Url</th>
  </tr>
  <tr>
    <td>Skybox</td>
    <td>AllSkyFree</td>
    <td><a href="https://assetstore.unity.com/packages/2d/textures-materials/sky/allsky-free-10-sky-skybox-set-146014" target="_blank">url</a></td>
  </tr>
  <tr>
   <td>3D objects</td>
    <td>Yughues Free Concrete Barriers</td>
    <td><a href="https://assetstore.unity.com/packages/3d/props/exterior/yughues-free-concrete-barriers-13248" target="_blank">url</a>      </td>
  </tr> 
  <tr>
   <td>3D objects/animations/particle effects</td>
    <td>Yughues Free Concrete Barriers</td>
    <td><a href="https://assetstore.unity.com/packages/3d/props/weapons/animated-hands-with-weapons-pack-132915" target="_blank">url</a>     </td>
  </tr>   
  <tr>
   <td>Particle effects</td>
    <td>War FX</td>
    <td><a href="https://assetstore.unity.com/packages/vfx/particles/war-fx-5669" target="_blank">url</a></td>
  </tr>    
  <tr>
   <td>Particle effects</td>
    <td>Cartoon FX Easy Editor</td>
    <td>-</td>
  </tr> 
  <tr>
   <td>UI</td>
    <td>Modern UI Pack</td>
    <td><a href="https://assetstore.unity.com/packages/tools/gui/modern-ui-pack-150824" target="_blank">url</a></td>
  </tr>   
  <tr>
   <td>3D Environment</td>
    <td>Modular City Alley Pack</td>
    <td><a href="https://assetstore.unity.com/packages/3d/environments/urban/modular-city-alley-pack-65890" target="_blank">url</a></td>
  </tr>  
  <tr>
   <td>3D objects/particle effects</td>
    <td>Modern Guns: Handgun</td>
    <td><a href="https://assetstore.unity.com/packages/3d/props/guns/modern-guns-handgun-129821" target="_blank">url</a></td>
  </tr>    
  <tr>
   <td>3D objects/animations</td>
    <td>Zombie</td>
    <td><a href="https://assetstore.unity.com/packages/3d/characters/humanoids/zombie-30232" target="_blank">url</a></td>
  </tr>     
 <tr>
   <td>Pathfinding</td>
    <td>A* Pathfinding</td>
    <td><a href="https://arongranberg.com/astar/" target="_blank">url</a></td>
  </tr>   
 <tr>
   <td>State Machine</td>
    <td>Unity 3D Finite State Machine</td>
    <td><a href="https://github.com/thefuntastic/Unity3d-Finite-State-Machine" target="_blank">url</a></td>
  </tr>
 <tr>
   <td>Asset Pack</td>
    <td>Standard assets for Unity 2017</td>
    <td><a href="https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-for-unity-2017-3-32351" target="_blank">url</a></td>
  </tr>   
 <tr>
   <td>Font</td>
    <td>KG Blank Space</td>
    <td><a href="https://www.dafont.com/kg-blank-space.font" target="_blank">url</a></td>
 </tr>   
 <tr>
   <td>UI icons</td>
    <td>Various icons for the game</td>
    <td>UI icon sources.txt</td>
 </tr>    
 <tr>
   <td>Audio</td>
    <td>Various audio files</td>
    <td>Audio sources.txt</td>
  </tr>     
  
</table>


## <a name="RoundSystem"></a>Round System
<p>Before every round, the round system generates a random number between increasing min and max ranges.<br>
That number is going to be total zombies that will spawn for that particular round.<br><br>
E.g for round number 1, you can expect between 5 and 10 zombies.<br>
    For round number 10, you can expect between 23 and 55 zombies.
</p>

<a target="_blank" href="https://github.com/GintasS/The-Living-Dead/blob/master/Images/Graph2.JPG">
  <img src="https://github.com/GintasS/The-Living-Dead/blob/master/Images/Graph2.JPG" height="300" style="max-width:100%;"></img>
</a>

## <a name="EconomyOverview"></a>Economy Overview
<p>This game has currency to buy items at the shop.<br>
  You gain 200 credits for every zombie killed. Later you can increase it via purchasing an utility item.<br>
 
 <p>Available items at the shop:</p>
 <table style="width:30%">
  <tr>
    <th>Item Name</th>
    <th>Item Cost</th>
    <th>Item Description</th>
  </tr>
  <tr>
    <td>1 Ammo Clip (Assault Rifle)</td>
    <td>500</td>
    <td>Single juicy ammo clip for your assault rifle needs!</td>
  </tr>
  <tr>
    <td>3 Ammo Clips (Assault Rifle)</td>
    <td>1400</td>
    <td>Three is better than one.Use your assault rifle and kill' them!</td>
  </tr>
  <tr>
    <td>5 Ammo Clips (Assault Rifle)</td>
    <td>2700</td>
    <td>Ultimate ammo box for your assault rifle.</td>
  </tr>
  <tr>
    <td>1 Ammo Clip (Pistol)</td>
    <td>200</td>
    <td>The old and lonely single ammo clip for your pistol.</td>
  </tr>
  <tr>
    <td>3 Ammo Clips (Pistol)</td>
    <td>800</td>
    <td>The best bang for the buck!Buy it now white it lasts!</td>
  </tr>
  <tr>
    <td>5 Ammo Clips (Pistol)</td>
    <td>1400</td>
    <td>You will kill all the zombies with this bag of 5 ammo clips for your pistol.</td>
  </tr>
  <tr>
    <td>Shop Radar</td>
    <td>0</td>
    <td>Displays a distance to the nearest shop.<b>Yay, you already have it!</b></td>
  </tr>
  <tr>
    <td>Zombie Counter</td>
    <td>10000</td>
    <td>Allows you to see how many zombies are currently alive in this current round.</td>
  </tr>
  <tr>
    <td>Scrooge McDuck</td>
    <td>14200</td>
    <td>Increases the money given per every zombie killed.</td>
  </tr>
  <tr>
    <td>Health Regeneration</td>
    <td>18900</td>
    <td>Makes a player nearly invincible(sort of). Regenerate health every X seconds.</td>
  </tr>   
</table>

<p><center><b>Zombie kills needed to buy a specific item</b></center></p>

<a target="_blank" href="https://github.com/GintasS/The-Living-Dead/blob/master/Images/Graph4.JPG">
  <img src="https://github.com/GintasS/The-Living-Dead/blob/master/Images/Graph4.JPG" height="300" style="max-width:100%;"></img>
</a>

## <a name="Media"></a>Media
<p><b>YouTube demo:</b></p>

[![The Living Dead (Demo)](https://img.youtube.com/vi/U5Mt9gAZAMo/0.jpg)](https://www.youtube.com/watch?v=U5Mt9gAZAMo&feature=youtu.be "The Living Dead (Demo)")

<a target="_blank" href="https://github.com/GintasS/The-Living-Dead/blob/master/Images/Game%201.jpg">
  <img src="https://github.com/GintasS/The-Living-Dead/blob/master/Images/Game%201.jpg" height="300" style="max-width:100%;"></img>
</a>
<blockquote>Looking into a door (3/6/2020)</blockquote>
<br>
<a target="_blank" href="https://github.com/GintasS/The-Living-Dead/blob/master/Images/Game%202.jpg">
  <img src="https://github.com/GintasS/The-Living-Dead/blob/master/Images/Game%202.jpg" height="300" style="max-width:100%;"></img>
</a>
<blockquote>Spotted a zombie (3/6/2020)</blockquote>

<br>
<a target="_blank" href="https://github.com/GintasS/The-Living-Dead/blob/master/Images/Game%203.jpg">
  <img src="https://github.com/GintasS/The-Living-Dead/blob/master/Images/Game%203.jpg" height="300" style="max-width:100%;"></img>
</a>
<blockquote>Shooting a zombie (3/6/2020)</blockquote>

<br>
<a target="_blank" href="https://github.com/GintasS/The-Living-Dead/blob/master/Images/Game%204.jpg">
  <img src="https://github.com/GintasS/The-Living-Dead/blob/master/Images/Game%204.jpg" height="300" style="max-width:100%;"></img>
</a>
<blockquote>Shop Menu (3/6/2020)</blockquote>

<br>
<a target="_blank" href="https://github.com/GintasS/The-Living-Dead/blob/master/Images/Game%205.jpg">
  <img src="https://github.com/GintasS/The-Living-Dead/blob/master/Images/Game%205.jpg" height="300" style="max-width:100%;"></img>
</a>
<blockquote>Pistol (3/6/2020)</blockquote>

## <a name="Changelog"></a>Changelog

<h3>CHANGELOG 3/6/2020</h3>
<ul>
  <li>Added the whole project to GitHub.</li>
  <li>Recorded a demo video and uploaded it to YouTube.</li>
  <li>Added proper ReadMe.</li>
  <li>Added images/media.</li>
</ul>

<h3>CHANGELOG 27/3/2021</h3>
<ul>
  <li>Fixed grammar mistakes.</li>
</ul>
