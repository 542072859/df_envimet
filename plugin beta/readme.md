Here you can find a beta version of dragonfly components. They will be released in official Dragonfly Legacy as soon as they are tested enough.

## Installation

For those people who want to try them, please follow these steps:
<ol>
  <li>Download "pluginBeta.zip".</li>
  <li>Check if downloaded .zip file has been blocked: right click on it, and choose Properties. If there is an Unblock button click on it, otherwise it is OK. Unzip it.</li>
  <li>Go to Libraries folder of Grasshopper: Open Grasshopper and go to File->Special Folders->Components Folder.</li>
  <li>Copy and paste "Dragonfly" folder wherever you want on your machine in order to make a backup copy of it.</li>
  <li>Replace the files with new ones within "pluginBeta".</li>
  <li>Restart Rhino</li>
</ol>

What will happen to your existing gh files? Some components are the same of the previous versions, other required a replacement. I suggest save your workflows in the same folder of backup of plugin.

## New features
[2020/06/08]:
- 'Nesting grids' can be 0
- Default folder: ENVImet445
- 2D Building Info added

[2020/04/14]:
- Edit Facade Material component
- Facade visualization improvement
![Alt Text](https://github.com/AntonelloDN/df_envimet/blob/master/envimet/EditFacadeMaterial.gif)

[2020/03/12]:
- dll 1.0.0.2 and new classes
- Grid results components
- Grid calculation improvement*
- Facade folder and possibility to bake facades*
- Delete facades component*
- Facade results component*

[2020/03/04]:
- 2D matrix much more accurate
- New method to create envimet terrain
- Building avg results reader added

[2020/02/18]:
- Receptor Reader added: you can read fast all receptor results without using excel!
- Improved batch to run simulations (from Simone Piccolo's issue).

![Alt Text](https://github.com/AntonelloDN/df_envimet/blob/master/envimet/ReceptorOutputReader.gif)

[2020/01/26]:
- Calculation speed improvement for soils and trees
- Modelinfo output for DF Envimet Spaces

[2020/01/23]:
- minor bug fixed: Wrong constant for installation folder; component descriptions.
- bug fixed: Concept of centroid of automatic grid; Combined grid in right position; Grid visualization (Thanks to Simone Piccolo for finding it).
- small improvements: Right representation of envimet grid xyz on GH; Uppercase search keyword in Library component

[2020/01/20]:
- Closed mesh or brep to create a terrain. Useful for terrain with sharp changes. Thanks to Ivan Heitmann for input.

[2019/11/28]:
- Installation Directory component added. Thanks to Minggang Yin.

[2019/11/22]:
- Receptor Object added. Thanks to Wendy Sunarya

[2019/10/20]:
- New object structure of the plugin;
- Usability: Multiple envimet object are supported now;
- Apply materials easily;
- Combined grid added (telescope + equidistant) - there is a small issue of visualization (WIP with Envimet);
- Terrain color bug fixed;
- Simplified method of calculation for buiding added;
- "Move building up" component removed, it is not necessary;
- SimpleForcing is mandatory for new Config Intermediate file;
- Config file support simulation more than 24 hours now;

[2019/05/11]:
- Read User DB Library;

[2019/03/06]:
- Run simulation directly with Grasshopper;
- Output file timing settings;
- LBC settings for simulation file - removed because of latest ENVI_MET 4.4.1;

[2019/02/24]:
- Horizontal overhang;

[2019/02/20]:
- Edit building materials (E.g. for windows);<br>
![Alt Text](https://github.com/AntonelloDN/df_envimet/blob/master/envimet/EditBuildingMaterialComponent.png)

[2019/02/09]:
- Soil init condition for simulation file;

[2019/01/23]:
- LBC settings for simulation file;

[2019/01/21]:
- Timesteps settings for simulation file;
- Building indoor temperature for simulation file;
- Terrain (early adopter);
- Move building component for terrain;
