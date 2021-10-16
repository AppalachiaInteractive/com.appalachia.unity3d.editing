using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Appalachia.Utility.Constants.Icons;
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR

#endif

namespace Appalachia.Editing.Core
{
    public static class EditorGUIIcons
    {
        public const string BUILD_VERSION = "2021.2.0b4";
        public const int VALUE_COUNT = 1864;
        public const string VALUE_COUNT_STRING = "1864";

#region Enumerations

        public enum Enum
        {
            None = 0,
            _help = 1581332909,
            _menu = 1836124805,
            _popup = 1428973157,
            aboutwindow_mainheader = 231878718,
            ageialogo = 1195056202,
            alphabeticalsorting = 2020306644,
            anchortransformtool_on = 1288832863,
            anchortransformtool = 394406592,
            animation_addevent = 962187310,
            animation_addkeyframe = 2047171085,
            animation_eventmarker = 2067093738,
            animation_filterbyselection = 355889322,
            animation_firstkey = 894262299,
            animation_lastkey = 1745371360,
            animation_nextkey = 524546882,
            animation_play = 1362872618,
            animation_prevkey = 1766387062,
            animation_record = 267486950,
            animation_sequencerlink = 865646374,
            animationanimated = 1575681977,
            animationdopesheetkeyframe = 476499885,
            animationkeyframe = 1638784862,
            animationnocurve = 1022385616,
            animationvisibilitytoggleoff = 249337245,
            animationvisibilitytoggleon = 558534935,
            animationwrapmodemenu = 860614831,
            assemblylock = 826669773,
            asset_store = 1415960675,
            unity_assetstore_originals_logo_white = 599042335,
            audio_mixer = 556629325,
            autolightbakingoff = 342293116,
            autolightbakingon = 1683148755,
            avatarcompass = 1920303793,
            avatarcontroller_layer = 1086663874,
            avatarcontroller_layerhover = 1743417667,
            avatarcontroller_layerselected = 1093064352,
            bodypartpicker = 1251693548,
            bodysilhouette = 1761187141,
            dotfill = 621798184,
            dotframe = 600208038,
            dotframedotted = 1421860488,
            dotselection = 1733461552,
            head = 539367,
            headik = 309753826,
            headzoom = 940324013,
            headzoomsilhouette = 856651431,
            leftarm = 292496100,
            leftfeetik = 1269026349,
            leftfingers = 244711848,
            leftfingersik = 1785965284,
            lefthandzoom = 225722275,
            lefthandzoomsilhouette = 1583665098,
            leftleg = 283913566,
            maskeditor_root = 886240611,
            rightarm = 523972658,
            rightfeetik = 250789713,
            rightfingers = 172073787,
            rightfingersik = 775158497,
            righthandzoom = 229558763,
            righthandzoomsilhouette = 1610868787,
            rightleg = 1597980676,
            torso = 795831207,
            avatarpivot = 129185035,
            avatarselector = 489821800,
            back = 219822934,
            beginbutton_on = 1164112820,
            beginbutton = 1092808352,
            blendkey = 1161761183,
            blendkeyoverlay = 416277426,
            blendkeyselected = 1602521698,
            blendsampler = 1579495354,
            bluegroove = 836350177,
            buildsettings_android_on = 1883172595,
            buildsettings_android = 344484749,
            buildsettings_android_small = 603900342,
            buildsettings_broadcom = 253447024,
            buildsettings_editor = 539365479,
            buildsettings_editor_small = 1437583477,
            buildsettings_embeddedlinux_on = 1625136056,
            buildsettings_embeddedlinux = 1277300068,
            buildsettings_embeddedlinux_small = 660641547,
            buildsettings_facebook_on = 994527119,
            buildsettings_facebook = 116453826,
            buildsettings_facebook_small = 489691953,
            buildsettings_flashplayer = 1375784836,
            buildsettings_flashplayer_small = 1509837106,
            buildsettings_gamecorescarlett_on = 1867984618,
            buildsettings_gamecorescarlett = 1598820671,
            buildsettings_gamecorescarlett_small = 2146555215,
            buildsettings_gamecorexboxone_on = 270465134,
            buildsettings_gamecorexboxone = 1147178694,
            buildsettings_gamecorexboxone_small = 1410845578,
            buildsettings_iphone_on = 161619061,
            buildsettings_iphone = 1866072720,
            buildsettings_iphone_small = 2125885925,
            buildsettings_lumin_on = 1123199019,
            buildsettings_lumin = 518128980,
            buildsettings_lumin_small = 372541886,
            buildsettings_metro_on = 2030260767,
            buildsettings_metro = 472739772,
            buildsettings_metro_small = 63443586,
            buildsettings_n3ds_on = 1952694738,
            buildsettings_n3ds = 1925424849,
            buildsettings_n3ds_small = 1723537005,
            buildsettings_ps4_on = 1124536211,
            buildsettings_ps4 = 393048880,
            buildsettings_ps4_small = 1309862950,
            buildsettings_ps5_on = 1135913822,
            buildsettings_ps5 = 437128539,
            buildsettings_ps5_small = 1580444373,
            buildsettings_psm = 885802456,
            buildsettings_psm_small = 277588094,
            buildsettings_psp2 = 212228124,
            buildsettings_psp2_small = 923079610,
            buildsettings_selectedicon = 46411811,
            buildsettings_stadia_on = 1269415755,
            buildsettings_stadia = 130278652,
            buildsettings_stadia_small = 27543400,
            buildsettings_standalone_on = 1087800201,
            buildsettings_standalone = 1152878976,
            buildsettings_standalone_small = 728587386,
            buildsettings_standalonebroadcom_small = 1267865143,
            buildsettings_standalonegles20emu_small = 1172607767,
            buildsettings_standaloneglesemu = 982698833,
            buildsettings_standaloneglesemu_small = 1853657546,
            buildsettings_switch_on = 215934728,
            buildsettings_switch = 1008324090,
            buildsettings_switch_small = 1545045029,
            buildsettings_tvos_on = 1092197187,
            buildsettings_tvos = 1553138593,
            buildsettings_tvos_small = 828876078,
            buildsettings_web = 485070600,
            buildsettings_web_small = 182605178,
            buildsettings_webgl_on = 1140164117,
            buildsettings_webgl = 1157803186,
            buildsettings_webgl_small = 1559659294,
            buildsettings_wp8 = 1759629165,
            buildsettings_wp8_small = 1678545742,
            buildsettings_xbox360 = 1144711483,
            buildsettings_xbox360_small = 1578273367,
            buildsettings_xboxone_on = 291406825,
            buildsettings_xboxone = 1833765884,
            buildsettings_xboxone_small = 1101325943,
            cacheserverconnected = 1817061186,
            cacheserverdisabled = 1720801983,
            cacheserverdisconnected = 90348719,
            checkerfloor = 610815518,
            clipboard = 500410473,
            clothinspector_painttool = 1131619759,
            clothinspector_paintvalue = 885561751,
            clothinspector_selecttool = 1262770136,
            clothinspector_settingstool = 1706644408,
            clothinspector_viewvalue = 482181042,
            cloudconnect = 180700682,
            collab_build = 1267152493,
            collab_buildfailed = 2007533730,
            collab_buildsucceeded = 147050187,
            collab_fileadded = 617569295,
            collab_fileconflict = 292408148,
            collab_filedeleted = 1360578014,
            collab_fileignored = 303976723,
            collab_filemoved = 1614091760,
            collab_fileupdated = 2030349113,
            collab_folderadded = 2143312019,
            collab_folderconflict = 1897922861,
            collab_folderdeleted = 1742100702,
            collab_folderignored = 1873562432,
            collab_foldermoved = 1727717886,
            collab_folderupdated = 1744943416,
            collab_nointernet = 27296925,
            collab = 1610560726,
            collab_warning = 286215212,
            collabconflict = 1448319087,
            collaberror = 463983047,
            collabnew = 137612407,
            collaboffline = 1152096439,
            collabprogress = 373393945,
            collabpull = 1288640857,
            collabpush = 238393871,
            colorpicker_colorcycle = 1552035585,
            colorpicker_cyclecolor = 1478753327,
            colorpicker_cycleslider = 1236528423,
            colorpicker_slidercycle = 917946024,
            console_erroricon_inactive_sml = 77105605,
            console_erroricon = 869306403,
            console_erroricon_sml = 78099698,
            console_infoicon_inactive_sml = 1236991183,
            console_infoicon = 1554192893,
            console_infoicon_sml = 1058112260,
            console_warnicon_inactive_sml = 1644756497,
            console_warnicon = 557082052,
            console_warnicon_sml = 1176435885,
            createaddnew = 868844082,
            crossicon = 715537968,
            curvekeyframe = 1474362062,
            curvekeyframeselected = 1705318411,
            curvekeyframeselectedoverlay = 17158423,
            curvekeyframesemiselectedoverlay = 695027564,
            curvekeyframeweighted = 884065466,
            customsorting = 1815446203,
            customtool = 1459676675,
            d__help = 1178128149,
            d__menu = 934384152,
            d__popup = 885883360,
            d_aboutwindow_mainheader = 285348476,
            d_ageialogo = 1467154909,
            d_alphabeticalsorting = 1717908202,
            d_anchortransformtool_on = 1311376713,
            d_anchortransformtool = 1532537351,
            d_animation_addevent = 1296282864,
            d_animation_addkeyframe = 403364326,
            d_animation_eventmarker = 1944722798,
            d_animation_filterbyselection = 1210082561,
            d_animation_firstkey = 208171756,
            d_animation_lastkey = 1067040133,
            d_animation_nextkey = 275458832,
            d_animation_play = 1060963623,
            d_animation_prevkey = 807365018,
            d_animation_record = 1051704002,
            d_animation_sequencerlink = 394020397,
            d_animationanimated = 1287840239,
            d_animationkeyframe = 2142852067,
            d_animationnocurve = 986813770,
            d_animationvisibilitytoggleoff = 1161664835,
            d_animationvisibilitytoggleon = 1797045226,
            d_animationwrapmodemenu = 1585933216,
            d_as_badge_delete = 110119031,
            d_as_badge_new = 2017744842,
            d_assemblylock = 1428695632,
            d_asset_store = 1797627091,
            d_audio_mixer = 862148423,
            d_autolightbakingoff = 472390130,
            d_autolightbakingon = 971889914,
            d_avatarblendbackground = 1079547659,
            d_avatarblendleft = 606246550,
            d_avatarblendlefta = 1435337943,
            d_avatarblendright = 441971537,
            d_avatarblendrighta = 2069506728,
            d_avatarcompass = 394669501,
            d_avatarpivot = 1473887467,
            d_avatarselector = 1339572722,
            d_back = 1768476352,
            d_beginbutton_on = 1011499066,
            d_beginbutton = 1444928612,
            d_bluegroove = 1806787759,
            d_buildsettings_android = 334978455,
            d_buildsettings_android_small = 310048241,
            d_buildsettings_broadcom = 1268951991,
            d_buildsettings_facebook = 1915580090,
            d_buildsettings_facebook_small = 755252007,
            d_buildsettings_flashplayer = 1522468823,
            d_buildsettings_flashplayer_small = 932283111,
            d_buildsettings_gamecorescarlett = 246511098,
            d_buildsettings_gamecorescarlett_small = 1723243196,
            d_buildsettings_gamecorexboxone = 1864793741,
            d_buildsettings_gamecorexboxone_small = 1258923516,
            d_buildsettings_iphone = 1669105939,
            d_buildsettings_iphone_small = 934568631,
            d_buildsettings_lumin = 1849717712,
            d_buildsettings_lumin_small = 1872954489,
            d_buildsettings_metro = 241832599,
            d_buildsettings_metro_small = 2059681159,
            d_buildsettings_n3ds = 1974652765,
            d_buildsettings_n3ds_small = 954875536,
            d_buildsettings_ps4 = 2119626464,
            d_buildsettings_ps4_small = 1694686288,
            d_buildsettings_ps5 = 646333686,
            d_buildsettings_ps5_small = 1429847663,
            d_buildsettings_psp2 = 1071449538,
            d_buildsettings_psp2_small = 76700630,
            d_buildsettings_selectedicon = 727119500,
            d_buildsettings_stadia = 1522409073,
            d_buildsettings_stadia_small = 285844392,
            d_buildsettings_standalone = 295999244,
            d_buildsettings_standalone_small = 1040643384,
            d_buildsettings_switch = 1559785985,
            d_buildsettings_switch_small = 1938964792,
            d_buildsettings_tvos = 448327179,
            d_buildsettings_tvos_small = 1275996288,
            d_buildsettings_web = 2132584829,
            d_buildsettings_web_small = 2025257120,
            d_buildsettings_webgl = 1043652905,
            d_buildsettings_webgl_small = 876299696,
            d_buildsettings_xbox360 = 1963673819,
            d_buildsettings_xbox360_small = 1605771400,
            d_buildsettings_xboxone = 1584989586,
            d_buildsettings_xboxone_small = 722167800,
            d_buildsettings_xiaomi = 2050393716,
            d_buildsettings_xiaomi_small = 1909067507,
            d_cacheserverconnected = 1538455092,
            d_cacheserverdisabled = 2087268083,
            d_cacheserverdisconnected = 419804197,
            d_checkerfloor = 1000502168,
            d_cloudconnect = 1808729487,
            d_collab_fileadded = 1736276214,
            d_collab_fileconflict = 139537079,
            d_collab_filedeleted = 979006518,
            d_collab_fileignored = 804154296,
            d_collab_filemoved = 1712649564,
            d_collab_fileupdated = 1909373231,
            d_collab_folderadded = 466809592,
            d_collab_folderconflict = 526797401,
            d_collab_folderdeleted = 1902105321,
            d_collab_folderignored = 44351174,
            d_collab_foldermoved = 1591463066,
            d_collab_folderupdated = 1414951204,
            d_collab = 1310899262,
            d_colorpicker_cyclecolor = 444798170,
            d_colorpicker_cycleslider = 1087096041,
            d_console_erroricon_inactive_sml = 1846755766,
            d_console_erroricon = 697772547,
            d_console_erroricon_sml = 1511616756,
            d_console_infoicon_inactive_sml = 1237249542,
            d_console_infoicon = 1812980267,
            d_console_infoicon_sml = 676037041,
            d_console_warnicon_inactive_sml = 1103363318,
            d_console_warnicon = 184005282,
            d_console_warnicon_sml = 979374053,
            d_createaddnew = 348977343,
            d_curvekeyframe = 353586005,
            d_curvekeyframeselected = 581751485,
            d_curvekeyframeselectedoverlay = 176690315,
            d_curvekeyframesemiselectedoverlay = 1632976894,
            d_curvekeyframeweighted = 1245584228,
            d_customsorting = 1181997012,
            d_customtool = 496776162,
            d_debuggerattached = 663347198,
            d_debuggerdisabled = 1688745714,
            d_debuggerenabled = 1611611271,
            d_defaultsorting = 2032455728,
            d_editcollider = 231340571,
            d_editcollision_16 = 1324493781,
            d_editcollision_32 = 2027715666,
            d_editconstraints_16 = 470025137,
            d_editconstraints_32 = 593040265,
            d_editicon_sml = 422737186,
            d_endbutton_on = 1846658821,
            d_endbutton = 1198960345,
            d_exposure = 743085828,
            d_eyedropper_large = 1216891423,
            d_eyedropper_sml = 1197255748,
            d_favorite = 1733137768,
            d_filterbylabel = 251493532,
            d_filterbytype = 1674440192,
            d_filterselectedonly = 1945649721,
            d_forward = 939337493,
            d_framecapture = 1868026262,
            d_gear = 1606374252,
            d_gizmostoggle_on = 1199889181,
            d_gizmostoggle = 1028218059,
            d_grid_boxtool = 219245730,
            d_grid_default = 626597035,
            d_grid_erasertool = 967388201,
            d_grid_filltool = 486770919,
            d_grid_movetool = 678568197,
            d_grid_painttool = 681308654,
            d_grid_pickingtool = 840336159,
            d_groove = 1262862636,
            d_horizontalsplit = 1413266374,
            d_icon_dropdown = 326169745,
            d_import = 1462602235,
            d_inspectorlock = 268294160,
            d_invalid = 2124821704,
            d_jointangularlimits = 2140177597,
            d_leftbracket = 1168508046,
            d_lighting = 150132296,
            d_lightmapeditor_windowtitle = 142110860,
            d_linked = 1919603957,
            d_mainstageview = 2047060527,
            d_mirror = 278429944,
            d_model_large = 1732886169,
            d_monologo = 733763297,
            d_moreoptions = 1575997162,
            d_movetool_on = 873069106,
            d_movetool = 1962526199,
            d_navigation = 2086972805,
            d_occlusion = 1142406771,
            d_package_manager = 688812203,
            d_particle_effect = 2095563134,
            d_particleshapetool_on = 340483156,
            d_particleshapetool = 1712150154,
            d_pausebutton_on = 520786810,
            d_pausebutton = 387055972,
            d_playbutton_on = 1591911919,
            d_playbutton = 349253381,
            d_playbuttonprofile_on = 665138150,
            d_playbuttonprofile = 1293121617,
            d_playloopoff = 254963615,
            d_playloopon = 424000734,
            d_preaudioautoplayoff = 1591720883,
            d_preaudioautoplayon = 1398232346,
            d_preaudioloopoff = 637408226,
            d_preaudioloopon = 1923692012,
            d_preaudioplayoff = 1905510898,
            d_preaudioplayon = 2064653870,
            d_prematcube = 884753788,
            d_prematcylinder = 264724540,
            d_prematlight0 = 972797182,
            d_prematlight1 = 1862810378,
            d_prematquad = 935187105,
            d_prematsphere = 1413454765,
            d_premattorus = 1779004166,
            d_preset_context = 1121862604,
            d_pretexa = 1609993256,
            d_pretexb = 1094437084,
            d_pretexg = 1472953710,
            d_pretexr = 949680907,
            d_pretexrgb = 498604387,
            d_pretexturealpha = 513339386,
            d_pretexturemipmaphigh = 477086439,
            d_pretexturemipmaplow = 371720090,
            d_pretexturergb = 1218208614,
            d_profiler_audio = 1598745560,
            d_profiler_cpu = 1002873840,
            d_profiler_custom = 1871021739,
            d_profiler_firstframe = 1753876413,
            d_profiler_globalillumination = 1357197279,
            d_profiler_gpu = 1190046509,
            d_profiler_lastframe = 1226147416,
            d_profiler_memory = 1274364644,
            d_profiler_network = 2027075664,
            d_profiler_networkmessages = 1153146011,
            d_profiler_networkoperations = 829465770,
            d_profiler_nextframe = 1438818246,
            d_profiler_open = 356472156,
            d_profiler_physics = 2047635516,
            d_profiler_physics2d = 1965215583,
            d_profiler_prevframe = 93134321,
            d_profiler_record = 1517488262,
            d_profiler_rendering = 1425560594,
            d_profiler_ui = 1518090448,
            d_profiler_uidetails = 380695067,
            d_profiler_video = 341737720,
            d_profiler_virtualtexturing = 1062600314,
            d_profilercolumn_warningcount = 2001678160,
            d_progress = 1170474225,
            d_project = 1889787856,
            d_record_off = 395824933,
            d_record_on = 470492206,
            d_recttool_on = 571033640,
            d_recttool = 266829026,
            d_recttransformblueprint = 1206430234,
            d_recttransformraw = 802227646,
            d_redgroove = 376433551,
            d_reflectionprobeselector = 1837348434,
            d_refresh = 1235611901,
            d_rightbracket = 1483389118,
            d_rotatetool_on = 1187281013,
            d_rotatetool = 114479114,
            d_saveas = 450045790,
            d_scaletool_on = 1983524487,
            d_scaletool = 1886193,
            d_scenepicking_notpickable_mixed = 1630176622,
            d_scenepicking_notpickable_mixed_hover = 1547466942,
            d_scenepicking_notpickable = 346336181,
            d_scenepicking_notpickable_hover = 1738927003,
            d_scenepicking_pickable_mixed = 1469794358,
            d_scenepicking_pickable_mixed_hover = 1872026761,
            d_scenepicking_pickable = 865386236,
            d_scenepicking_pickable_hover = 1228310587,
            d_sceneview2d_on = 179528044,
            d_sceneview2d = 556042381,
            d_sceneviewalpha = 561986774,
            d_sceneviewaudio_on = 1529022101,
            d_sceneviewaudio = 1646731208,
            d_sceneviewcamera = 326478829,
            d_sceneviewfx_on = 1958052415,
            d_sceneviewfx = 1450196172,
            d_sceneviewlighting_on = 1595026038,
            d_sceneviewlighting = 1508667432,
            d_sceneviewortho = 2128402873,
            d_sceneviewrgb = 1194436037,
            d_sceneviewtools = 647263308,
            d_sceneviewvisibility_on = 923160599,
            d_sceneviewvisibility = 1043685419,
            d_scenevis_hidden_mixed = 517495289,
            d_scenevis_hidden_mixed_hover = 796606965,
            d_scenevis_hidden = 680167998,
            d_scenevis_hidden_hover = 1126917285,
            d_scenevis_scene_hover = 1713544321,
            d_scenevis_visible_mixed = 471319514,
            d_scenevis_visible_mixed_hover = 1519961744,
            d_scenevis_visible = 41811962,
            d_scenevis_visible_hover = 1039937757,
            d_scrollshadow = 947207625,
            d_settings = 2106243790,
            d_settingsicon = 1780598996,
            d_showpanels = 1806973474,
            d_socialnetworks_facebookshare = 1245919833,
            d_socialnetworks_linkedinshare = 1753254845,
            d_socialnetworks_tweet = 398791192,
            d_socialnetworks_udnopen = 1120169758,
            d_speedscale = 2008704006,
            d_stepbutton_on = 1333053099,
            d_stepbutton = 1246150530,
            d_stepleftbutton_on = 249422249,
            d_stepleftbutton = 1538908219,
            d_tab_next = 1403812562,
            d_tab_prev = 397487266,
            d_terraininspector_terraintooladd = 71554478,
            d_terraininspector_terraintoollower_on = 1672283158,
            d_terraininspector_terraintoolloweralt = 755588889,
            d_terraininspector_terraintoolplants_on = 851430922,
            d_terraininspector_terraintoolplants = 1802341436,
            d_terraininspector_terraintoolplantsalt_on = 1089210206,
            d_terraininspector_terraintoolplantsalt = 1595805225,
            d_terraininspector_terraintoolraise_on = 892920537,
            d_terraininspector_terraintoolraise = 1309871773,
            d_terraininspector_terraintoolsetheight_on = 1261518638,
            d_terraininspector_terraintoolsetheight = 1696589495,
            d_terraininspector_terraintoolsetheightalt_on = 512854380,
            d_terraininspector_terraintoolsetheightalt = 1800449461,
            d_terraininspector_terraintoolsettings_on = 447898355,
            d_terraininspector_terraintoolsettings = 499630375,
            d_terraininspector_terraintoolsmoothheight_on = 102780840,
            d_terraininspector_terraintoolsmoothheight = 1762072346,
            d_terraininspector_terraintoolsplat_on = 297254960,
            d_terraininspector_terraintoolsplat = 190382398,
            d_terraininspector_terraintoolsplatalt_on = 868199979,
            d_terraininspector_terraintoolsplatalt = 1302090047,
            d_terraininspector_terraintooltrees_on = 1072526717,
            d_terraininspector_terraintooltrees = 778219277,
            d_terraininspector_terraintooltreesalt_on = 1854458080,
            d_terraininspector_terraintooltreesalt = 705271559,
            d_toggleuvoverlay = 1856678229,
            d_toolbar_minus = 88478949,
            d_toolbar_plus_more = 1475295804,
            d_toolbar_plus = 2144693069,
            d_toolhandlecenter = 1211583965,
            d_toolhandleglobal = 617853607,
            d_toolhandlelocal = 109859992,
            d_toolhandlepivot = 389425308,
            d_toolsicon = 1006729586,
            d_tranp = 1926089143,
            d_transformtool_on = 2020636987,
            d_transformtool = 763857786,
            d_tree_icon = 947432987,
            d_tree_icon_branch = 859524213,
            d_tree_icon_branch_frond = 514383302,
            d_tree_icon_frond = 799802192,
            d_tree_icon_leaf = 1048923410,
            d_treeeditor_addbranches = 2042366073,
            d_treeeditor_addleaves = 1444133280,
            d_treeeditor_branch_on = 444553841,
            d_treeeditor_branch = 804224717,
            d_treeeditor_branchfreehand_on = 154540147,
            d_treeeditor_branchfreehand = 1799142681,
            d_treeeditor_branchrotate_on = 1019955347,
            d_treeeditor_branchrotate = 125207112,
            d_treeeditor_branchscale_on = 613979086,
            d_treeeditor_branchscale = 1364902309,
            d_treeeditor_branchtranslate_on = 1902448315,
            d_treeeditor_branchtranslate = 111026652,
            d_treeeditor_distribution_on = 1808751587,
            d_treeeditor_distribution = 28929939,
            d_treeeditor_duplicate = 1690446630,
            d_treeeditor_geometry_on = 876928255,
            d_treeeditor_geometry = 1216439725,
            d_treeeditor_leaf_on = 1948183340,
            d_treeeditor_leaf = 1011512617,
            d_treeeditor_leaffreehand_on = 521901832,
            d_treeeditor_leaffreehand = 650253003,
            d_treeeditor_leafrotate_on = 485014499,
            d_treeeditor_leafrotate = 616148551,
            d_treeeditor_leafscale_on = 1505765000,
            d_treeeditor_leafscale = 482794167,
            d_treeeditor_leaftranslate_on = 481556933,
            d_treeeditor_leaftranslate = 1369280222,
            d_treeeditor_material_on = 1263362910,
            d_treeeditor_material = 448977386,
            d_treeeditor_refresh = 2128483770,
            d_treeeditor_trash = 1499742208,
            d_treeeditor_wind_on = 1752111734,
            d_treeeditor_wind = 1066529716,
            d_unityeditor_animationwindow = 718084456,
            d_unityeditor_consolewindow = 350662855,
            d_unityeditor_debuginspectorwindow = 1263346600,
            d_unityeditor_devicesimulation_simulatorwindow = 1729744079,
            d_unityeditor_finddependencies = 81683499,
            d_unityeditor_gameview = 1590742307,
            d_unityeditor_graphs_animatorcontrollertool = 1466216846,
            d_unityeditor_hierarchywindow = 61111170,
            d_unityeditor_inspectorwindow = 306191678,
            d_unityeditor_profilerwindow = 888659165,
            d_unityeditor_scenehierarchywindow = 2005313193,
            d_unityeditor_sceneview = 480368700,
            d_unityeditor_timeline_timelinewindow = 1166022821,
            d_unityeditor_versioncontrol = 369698213,
            d_unitylogo = 1768563027,
            d_unlinked = 1518392527,
            d_valid = 1090758570,
            d_verticalsplit = 1769871755,
            d_viewtoolmove_on = 1882670046,
            d_viewtoolmove = 902637124,
            d_viewtoolorbit_on = 1581252271,
            d_viewtoolorbit = 607644813,
            d_viewtoolzoom_on = 530588660,
            d_viewtoolzoom = 631142477,
            d_visibilityoff = 1357628388,
            d_visibilityon = 1594872128,
            d_vumetertexturehorizontal = 925842605,
            d_vumetertexturevertical = 372840677,
            d_waitspin00 = 620145494,
            d_waitspin01 = 589981136,
            d_waitspin02 = 1534609071,
            d_waitspin03 = 963458412,
            d_waitspin04 = 524005850,
            d_waitspin05 = 693074675,
            d_waitspin06 = 1891907282,
            d_waitspin07 = 607330215,
            d_waitspin08 = 391033706,
            d_waitspin09 = 914772882,
            d_waitspin10 = 2008004082,
            d_waitspin11 = 1815958588,
            d_welcomescreen_assetstorelogo = 449753589,
            d_winbtn_graph = 856514057,
            d_winbtn_graph_close_h = 814394452,
            d_winbtn_graph_max_h = 1540487817,
            d_winbtn_graph_min_h = 1273363390,
            d_winbtn_mac_close = 1992833246,
            d_winbtn_mac_close_a = 819841285,
            d_winbtn_mac_close_h = 1091044222,
            d_winbtn_mac_inact = 1543372556,
            d_winbtn_mac_max = 503525983,
            d_winbtn_mac_max_a = 1684585027,
            d_winbtn_mac_max_h = 177115558,
            d_winbtn_mac_min = 1652129463,
            d_winbtn_mac_min_a = 1071962592,
            d_winbtn_mac_min_h = 1271264975,
            d_winbtn_win_close = 1299035235,
            d_winbtn_win_close_a = 1409860382,
            d_winbtn_win_close_h = 582718106,
            d_winbtn_win_max = 1700890023,
            d_winbtn_win_max_a = 520763623,
            d_winbtn_win_max_h = 1873247811,
            d_winbtn_win_min = 445439922,
            d_winbtn_win_min_a = 743401223,
            d_winbtn_win_min_h = 524583703,
            d_winbtn_win_rest = 1979814641,
            d_winbtn_win_rest_a = 1734463893,
            d_winbtn_win_rest_h = 1899095242,
            d_winbtn_win_restore = 660151785,
            d_winbtn_win_restore_a = 1530220254,
            d_winbtn_win_restore_h = 704610901,
            debuggerattached = 354273076,
            debuggerdisabled = 1298118814,
            debuggerenabled = 1012371913,
            defaultsorting = 2110782278,
            editcollider = 1190653825,
            editcollision_16 = 619695513,
            editcollision_32 = 262307489,
            editconstraints_16 = 246119203,
            editconstraints_32 = 2030723466,
            editicon_sml = 1086419480,
            endbutton_on = 967146254,
            endbutton = 1356105973,
            exposure = 669700042,
            eyedropper_large = 312031449,
            eyedropper_sml = 855906445,
            favorite = 1149115297,
            filterbylabel = 272268037,
            filterbytype = 1530330490,
            filterselectedonly = 824190162,
            forward = 1982698492,
            framecapture_on = 1018837706,
            framecapture = 1130470888,
            gear = 95293008,
            gizmostoggle_on = 1238681291,
            gizmostoggle = 445999774,
            grid_boxtool = 1409242635,
            grid_default = 283265235,
            grid_erasertool = 1051404556,
            grid_filltool = 1169789643,
            grid_movetool = 420317713,
            grid_painttool = 868402088,
            grid_pickingtool = 2027533648,
            groove = 533015044,
            align_horizontally = 1385706987,
            align_horizontally_center = 1390608806,
            align_horizontally_center_active = 525099353,
            align_horizontally_left = 2086806986,
            align_horizontally_left_active = 35354222,
            align_horizontally_right = 345187428,
            align_horizontally_right_active = 1528991014,
            align_vertically = 1195066330,
            align_vertically_bottom = 1447021799,
            align_vertically_bottom_active = 213174372,
            align_vertically_center = 1264095756,
            align_vertically_center_active = 346551267,
            align_vertically_top = 1615725905,
            align_vertically_top_active = 856687091,
            d_align_horizontally = 1048438817,
            d_align_horizontally_center = 638811109,
            d_align_horizontally_center_active = 161925752,
            d_align_horizontally_left = 1110779086,
            d_align_horizontally_left_active = 927813268,
            d_align_horizontally_right = 1242279426,
            d_align_horizontally_right_active = 830798220,
            d_align_vertically = 966962916,
            d_align_vertically_bottom = 2066090629,
            d_align_vertically_bottom_active = 657667559,
            d_align_vertically_center = 1114882169,
            d_align_vertically_center_active = 375675220,
            d_align_vertically_top = 1464532070,
            d_align_vertically_top_active = 1701877699,
            horizontalsplit = 1855876105,
            icon_dropdown = 1181236116,
            import = 1996075876,
            inspectorlock = 1672483193,
            invalid = 1316658881,
            jointangularlimits = 314636572,
            knobcshape = 136360131,
            knobcshapemini = 1297536865,
            leftbracket = 796439239,
            lighting = 1739909343,
            lightmapeditor_windowtitle = 600260377,
            lightmapping = 499335790,
            d_greenlight = 158513138,
            d_lightoff = 2015226606,
            d_lightrim = 1238600982,
            d_orangelight = 1687634988,
            d_redlight = 431930867,
            greenlight = 589018105,
            lightoff = 2059293184,
            lightrim = 650627622,
            orangelight = 1572767159,
            redlight = 368060175,
            linked = 1527973301,
            lockicon_on = 644871383,
            lockicon = 527296072,
            loop = 1937786415,
            mainstageview = 396430702,
            mirror = 549030215,
            monologo = 2135436819,
            moreoptions = 1830609121,
            movetool_on = 1240733791,
            movetool = 105811671,
            navigation = 1572730011,
            occlusion = 728928758,
            camerapreview = 836983169,
            d_camerapreview = 14745724,
            d_gridandsnap = 937407352,
            d_orientationgizmo = 728850793,
            d_searchoverlay = 1988258542,
            d_standardtools = 855530556,
            d_toolsettings = 1800810990,
            d_toolstoggle = 368708099,
            d_viewoptions = 1749357829,
            gridandsnap = 1023773954,
            grip_horizontalcontainer = 1838727013,
            grip_verticalcontainer = 2076885660,
            hoverbar_down = 1169293296,
            hoverbar_leftright = 2046555079,
            hoverbar_up = 2090260131,
            locked = 2057844535,
            orientationgizmo = 1569016700,
            searchoverlay = 1211478112,
            standardtools = 16669786,
            toolsettings = 299394711,
            toolstoggle = 1561066241,
            unlocked = 1243825668,
            viewoptions = 1703271809,
            package_manager = 549549514,
            packagebadgedelete = 714681192,
            packagebadgenew = 31755619,
            feature_selected = 1490571146,
            feature = 559415200,
            quickstart = 582780473,
            add_available = 1704532142,
            custom = 1005490003,
            customized = 1947145674,
            download_available = 417088428,
            error = 722630878,
            git = 1605680078,
            import_available = 1583726464,
            info = 309679860,
            installed = 1091081811,
            link = 992088513,
            loading = 2057443905,
            refresh = 710643355,
            update_available = 833983996,
            warning = 938837475,
            particle_effect = 694684372,
            particleshapetool_on = 1987264722,
            particleshapetool = 2008164020,
            pausebutton_on = 1743625291,
            pausebutton = 280446707,
            playbutton_on = 445570880,
            playbutton = 483330526,
            playbuttonprofile_on = 1923709772,
            playbuttonprofile = 738841824,
            playloopoff = 1271833610,
            playloopon = 679514387,
            playspeed = 361956452,
            preaudioautoplayoff = 1558585251,
            preaudioautoplayon = 1559465562,
            preaudioloopoff = 1295561389,
            preaudioloopon = 1484847543,
            preaudioplayoff = 316430468,
            preaudioplayon = 2035333907,
            prematcube = 665587313,
            prematcylinder = 1478490434,
            prematlight0 = 1282772119,
            prematlight1 = 969809014,
            prematquad = 1980577121,
            prematsphere = 904778724,
            premattorus = 922164078,
            preset_context = 166451078,
            pretexa = 116128632,
            pretexb = 984806500,
            pretexg = 1077117653,
            pretexr = 1564737504,
            pretexrgb = 33649527,
            pretexturealpha = 1990593374,
            pretexturearrayfirstslice = 286508380,
            pretexturearraylastslice = 1276554403,
            pretexturemipmaphigh = 915991269,
            pretexturemipmaplow = 431770004,
            pretexturergb = 1969035701,
            previewpackageinuse = 1455248252,
            arealight_gizmo = 788936398,
            arealight_icon = 695283421,
            assembly_icon = 1331632680,
            assetstore_icon = 337239645,
            audiomixerview_icon = 220898138,
            audiosource_gizmo = 1745174418,
            boo_script_icon = 2070082813,
            camera_gizmo = 1367951467,
            chorusfilter_icon = 268205865,
            collabchanges_icon = 64512576,
            collabchangesconflict_icon = 784849252,
            collabchangesdeleted_icon = 1265291564,
            collabconflict_icon = 1813273424,
            collabcreate_icon = 1665420438,
            collabdeleted_icon = 1555646502,
            collabedit_icon = 281686653,
            collabexclude_icon = 161868520,
            collabmoved_icon = 778450452,
            cs_script_icon = 1989652659,
            d_arealight_icon = 1457697453,
            d_assembly_icon = 988812071,
            d_assetstore_icon = 1780767471,
            d_audiomixerview_icon = 1541519340,
            d_boo_script_icon = 1162674546,
            d_collabchanges_icon = 892551212,
            d_collabchangesconflict_icon = 1396051154,
            d_collabchangesdeleted_icon = 758470156,
            d_collabconflict_icon = 1144374043,
            d_collabcreate_icon = 281746921,
            d_collabdeleted_icon = 205359035,
            d_collabedit_icon = 898365604,
            d_collabexclude_icon = 637593987,
            d_collabmoved_icon = 1027427458,
            d_cs_script_icon = 2001877302,
            d_directionallight_icon = 1226240194,
            d_favorite_icon = 271276046,
            d_favorite_on_icon = 136875240,
            d_folder_icon = 247487674,
            d_folder_on_icon = 735888011,
            d_folderempty_icon = 8730592,
            d_folderempty_on_icon = 60630958,
            d_folderfavorite_icon = 2033818876,
            d_folderfavorite_on_icon = 1570002848,
            d_folderopened_icon = 732270275,
            d_gridlayoutgroup_icon = 1781227722,
            d_horizontallayoutgroup_icon = 49513133,
            d_js_script_icon = 34324497,
            d_lightingdataassetparent_icon = 947854920,
            d_microphone_icon = 1846184540,
            d_prefab_icon = 49673278,
            d_prefab_on_icon = 1644965833,
            d_prefabmodel_icon = 204012536,
            d_prefabmodel_on_icon = 2089159763,
            d_prefabvariant_icon = 282095102,
            d_prefabvariant_on_icon = 1732056003,
            d_raycastcollider_icon = 1633770085,
            d_search_icon = 2093430478,
            d_search_on_icon = 1498005581,
            d_searchjump_icon = 324161105,
            d_settings_icon = 983756911,
            d_shortcut_icon = 1012657537,
            d_spotlight_icon = 34166005,
            d_verticallayoutgroup_icon = 219888285,
            defaultslate_icon = 520411834,
            directionallight_gizmo = 2017453490,
            directionallight_icon = 1942007472,
            disclight_gizmo = 1012136912,
            disclight_icon = 182763169,
            dll_script_icon = 3205467,
            echofilter_icon = 1080713838,
            favorite_icon = 538738265,
            favorite_on_icon = 1635263732,
            folder_icon = 816160060,
            folder_on_icon = 258613578,
            folderempty_icon = 1511486819,
            folderempty_on_icon = 576614225,
            folderfavorite_icon = 334035738,
            folderfavorite_on_icon = 1297198182,
            folderopened_icon = 105327847,
            folderopened_on_icon = 1186357680,
            gamemanager_icon = 127986689,
            gridbrush_icon = 681918151,
            highpassfilter_icon = 1401666902,
            horizontallayoutgroup_icon = 2113855164,
            js_script_icon = 1594353890,
            lensflare_gizmo = 344304313,
            lightingdataassetparent_icon = 903235636,
            lightprobegroup_gizmo = 1023049925,
            lightprobeproxyvolume_gizmo = 1100650068,
            lowpassfilter_icon = 2097130794,
            main_light_gizmo = 1765504752,
            metafile_icon = 1522832071,
            microphone_icon = 59710502,
            muscleclip_icon = 1032684037,
            particlesystem_gizmo = 1796969209,
            particlesystemforcefield_gizmo = 954414573,
            pointlight_gizmo = 2140782310,
            prefab_icon = 1665270988,
            prefab_on_icon = 1029191226,
            prefabmodel_icon = 519635146,
            prefabmodel_on_icon = 641655106,
            prefaboverlayadded_icon = 1464717062,
            prefaboverlaymodified_icon = 148398482,
            prefaboverlayremoved_icon = 739736684,
            prefabvariant_icon = 1573968581,
            prefabvariant_on_icon = 1313744991,
            projector_gizmo = 1001458643,
            raycastcollider_icon = 1594833892,
            reflectionprobe_gizmo = 789535281,
            reverbfilter_icon = 1334081136,
            sceneset_icon = 289393346,
            search_icon = 376053420,
            search_on_icon = 913722740,
            searchjump_icon = 143622509,
            settings_icon = 770659987,
            shortcut_icon = 783941357,
            softlockprojectbrowser_icon = 879454814,
            speedtreemodel_icon = 1725053421,
            spotlight_gizmo = 292225430,
            spotlight_icon = 1667852885,
            spritecollider_icon = 2136140853,
            sv_icon_dot0_pix16_gizmo = 436734584,
            sv_icon_dot10_pix16_gizmo = 1494378122,
            sv_icon_dot11_pix16_gizmo = 1071337095,
            sv_icon_dot12_pix16_gizmo = 1905999202,
            sv_icon_dot13_pix16_gizmo = 1836238098,
            sv_icon_dot14_pix16_gizmo = 2011220100,
            sv_icon_dot15_pix16_gizmo = 918906598,
            sv_icon_dot1_pix16_gizmo = 344868850,
            sv_icon_dot2_pix16_gizmo = 896739192,
            sv_icon_dot3_pix16_gizmo = 430568911,
            sv_icon_dot4_pix16_gizmo = 1253777171,
            sv_icon_dot5_pix16_gizmo = 1507175628,
            sv_icon_dot6_pix16_gizmo = 1465801729,
            sv_icon_dot7_pix16_gizmo = 538192352,
            sv_icon_dot8_pix16_gizmo = 521462319,
            sv_icon_dot9_pix16_gizmo = 1734452392,
            animatorcontroller_icon = 1399034061,
            animatorcontroller_on_icon = 407669923,
            animatorstate_icon = 341349960,
            animatorstatemachine_icon = 839108426,
            animatorstatetransition_icon = 580079566,
            blendtree_icon = 1156828259,
            d_animatorcontroller_icon = 1386569437,
            d_animatorcontroller_on_icon = 94570246,
            d_animatorstate_icon = 1290632082,
            d_animatorstatemachine_icon = 1127774247,
            d_animatorstatetransition_icon = 426733298,
            d_blendtree_icon = 1765887253,
            animationwindowevent_icon = 1202817699,
            audiomixercontroller_icon = 2058710200,
            audiomixercontroller_on_icon = 2057229358,
            d_audiomixercontroller_icon = 253346197,
            d_audiomixercontroller_on_icon = 345916914,
            audioimporter_icon = 2109673658,
            d_audioimporter_icon = 1518352773,
            d_defaultasset_icon = 140551249,
            d_filter_icon = 1575326458,
            d_ihvimageformatimporter_icon = 1261450723,
            d_lightingdataasset_icon = 2049437807,
            d_lightmapparameters_icon = 78625528,
            d_lightmapparameters_on_icon = 471153222,
            d_modelimporter_icon = 1261691159,
            d_sceneasset_icon = 2023812225,
            d_shaderimporter_icon = 725900818,
            d_shaderinclude_icon = 1054238834,
            d_textscriptimporter_icon = 1754179952,
            d_textureimporter_icon = 1722328356,
            d_truetypefontimporter_icon = 1915179378,
            defaultasset_icon = 721991520,
            editorsettings_icon = 1299483684,
            filter_icon = 1875207159,
            anystatenode_icon = 1150905284,
            d_anystatenode_icon = 1277103765,
            humantemplate_icon = 1756995654,
            ihvimageformatimporter_icon = 1555964804,
            lightingdataasset_icon = 651699407,
            lightmapparameters_icon = 1422871905,
            lightmapparameters_on_icon = 1783158055,
            modelimporter_icon = 1517407631,
            preset_icon = 1124723823,
            sceneasset_icon = 1278065078,
            sceneasset_on_icon = 207022631,
            scenetemplateasset_icon = 1316503789,
            d_searchdatabase_icon = 857047128,
            d_searchquery_icon = 211208527,
            d_searchqueryasset_icon = 453125190,
            searchdatabase_icon = 2131629162,
            searchquery_icon = 465409690,
            searchqueryasset_icon = 152893854,
            shaderimporter_icon = 1012824718,
            shaderinclude_icon = 1590898532,
            speedtreeimporter_icon = 216607527,
            substancearchive_icon = 244944539,
            textscriptimporter_icon = 604617164,
            textureimporter_icon = 1116995966,
            truetypefontimporter_icon = 720885172,
            d_spriteatlasasset_icon = 410017065,
            d_spriteatlasimporter_icon = 1581034449,
            spriteatlasasset_icon = 304776924,
            spriteatlasimporter_icon = 231179974,
            d_visualeffectsubgraphblock_icon = 215695096,
            d_visualeffectsubgraphoperator_icon = 2076480522,
            visualeffectsubgraphblock_icon = 412985933,
            visualeffectsubgraphoperator_icon = 225269996,
            videoclipimporter_icon = 709298961,
            assemblydefinitionasset_icon = 421644416,
            assemblydefinitionreferenceasset_icon = 1034259500,
            d_assemblydefinitionasset_icon = 128493359,
            d_assemblydefinitionreferenceasset_icon = 1458691938,
            d_navmeshagent_icon = 591836385,
            d_navmeshdata_icon = 706650628,
            d_navmeshobstacle_icon = 1305795023,
            d_offmeshlink_icon = 1672026244,
            navmeshagent_icon = 448643670,
            navmeshdata_icon = 691351362,
            navmeshobstacle_icon = 613597503,
            offmeshlink_icon = 1570041769,
            analyticstracker_icon = 448362984,
            d_analyticstracker_icon = 197807354,
            animation_icon = 1256584974,
            animationclip_icon = 1041921281,
            animationclip_on_icon = 1716087058,
            aimconstraint_icon = 1896222349,
            d_aimconstraint_icon = 1410680475,
            d_lookatconstraint_icon = 47869079,
            d_parentconstraint_icon = 1837396848,
            d_positionconstraint_icon = 494309457,
            d_rotationconstraint_icon = 1039972018,
            d_scaleconstraint_icon = 475928380,
            lookatconstraint_icon = 1517271541,
            parentconstraint_icon = 1139018899,
            positionconstraint_icon = 1484643756,
            rotationconstraint_icon = 225615358,
            scaleconstraint_icon = 190289130,
            animator_icon = 308987639,
            animatoroverridecontroller_icon = 1927132544,
            animatoroverridecontroller_on_icon = 484349013,
            areaeffector2d_icon = 936778600,
            articulationbody_icon = 373648850,
            audiomixergroup_icon = 1738426609,
            audiomixersnapshot_icon = 965403960,
            audiospatializermicrosoft_icon = 1766812172,
            d_audiomixergroup_icon = 2030669246,
            d_audiomixersnapshot_icon = 421260996,
            d_audiospatializermicrosoft_icon = 915710369,
            audiochorusfilter_icon = 1525535707,
            audioclip_icon = 36149835,
            audioclip_on_icon = 1800672028,
            audiodistortionfilter_icon = 1222206534,
            audioechofilter_icon = 910218394,
            audiohighpassfilter_icon = 287134136,
            audiolistener_icon = 251207667,
            audiolowpassfilter_icon = 2140017745,
            audioreverbfilter_icon = 1545890439,
            audioreverbzone_icon = 1495807700,
            audiosource_icon = 1506727996,
            avatar_icon = 1489878206,
            avatarmask_icon = 172121317,
            avatarmask_on_icon = 1381689435,
            billboardasset_icon = 4443019,
            billboardrenderer_icon = 485787598,
            boxcollider_icon = 2056298589,
            boxcollider2d_icon = 1582306324,
            buoyancyeffector2d_icon = 815834713,
            camera_icon = 1512447130,
            canvas_icon = 215260850,
            canvasgroup_icon = 1644428356,
            canvasrenderer_icon = 1297168436,
            capsulecollider_icon = 1230596399,
            capsulecollider2d_icon = 509491840,
            charactercontroller_icon = 1623528970,
            characterjoint_icon = 2050197607,
            circlecollider2d_icon = 816349687,
            cloth_icon = 1644702959,
            compositecollider2d_icon = 832342080,
            computeshader_icon = 1599529590,
            configurablejoint_icon = 1297180726,
            constantforce_icon = 1956562788,
            constantforce2d_icon = 382951423,
            cubemap_icon = 667252129,
            customcollider2d_icon = 1041392421,
            d_animation_icon = 1604038010,
            d_animationclip_icon = 1876238614,
            d_animationclip_on_icon = 330167635,
            d_animator_icon = 1599901029,
            d_animatoroverridecontroller_icon = 197480354,
            d_animatoroverridecontroller_on_icon = 871855982,
            d_areaeffector2d_icon = 1737810723,
            d_articulationbody_icon = 1775891852,
            d_audiochorusfilter_icon = 1674396052,
            d_audioclip_icon = 385052567,
            d_audioclip_on_icon = 1866449544,
            d_audiodistortionfilter_icon = 2079756293,
            d_audioechofilter_icon = 1629312309,
            d_audiohighpassfilter_icon = 1601495514,
            d_audiolistener_icon = 296662231,
            d_audiolowpassfilter_icon = 954898928,
            d_audioreverbfilter_icon = 891473113,
            d_audioreverbzone_icon = 1517406267,
            d_audiosource_icon = 88532306,
            d_avatar_icon = 2099464799,
            d_avatarmask_icon = 829004590,
            d_avatarmask_on_icon = 1994092645,
            d_billboardasset_icon = 898007187,
            d_billboardrenderer_icon = 626423270,
            d_boxcollider_icon = 469606197,
            d_boxcollider2d_icon = 1784800202,
            d_buoyancyeffector2d_icon = 1960780223,
            d_camera_icon = 320726320,
            d_canvas_icon = 2107111392,
            d_canvasgroup_icon = 967982737,
            d_canvasrenderer_icon = 1881776769,
            d_capsulecollider_icon = 157429523,
            d_capsulecollider2d_icon = 1588907811,
            d_charactercontroller_icon = 720898148,
            d_characterjoint_icon = 249922700,
            d_circlecollider2d_icon = 233598767,
            d_cloth_icon = 1664309919,
            d_compositecollider2d_icon = 904681061,
            d_computeshader_icon = 1834324715,
            d_configurablejoint_icon = 673678774,
            d_constantforce_icon = 1098535926,
            d_constantforce2d_icon = 696740631,
            d_cubemap_icon = 1837642023,
            d_distancejoint2d_icon = 339016061,
            d_edgecollider2d_icon = 616923116,
            d_fixedjoint_icon = 1296146943,
            d_flare_icon = 402815740,
            d_flare_on_icon = 846541774,
            d_flarelayer_icon = 1880671043,
            d_font_icon = 1213682658,
            d_font_on_icon = 1484645624,
            d_frictionjoint2d_icon = 1048172032,
            d_gameobject_icon = 1298108867,
            d_grid_icon = 575526699,
            d_guiskin_icon = 59755311,
            d_guiskin_on_icon = 421880500,
            d_halo_icon = 1933760112,
            d_hingejoint_icon = 799196974,
            d_hingejoint2d_icon = 721068810,
            d_light_icon = 584623283,
            d_lightingsettings_icon = 1643000491,
            d_lightprobegroup_icon = 1430650413,
            d_lightprobeproxyvolume_icon = 630421746,
            d_lightprobes_icon = 254388246,
            d_linerenderer_icon = 588653619,
            d_lodgroup_icon = 1917567991,
            d_material_icon = 1254054997,
            d_material_on_icon = 871940819,
            d_mesh_icon = 656067515,
            d_meshcollider_icon = 1084873012,
            d_meshfilter_icon = 1851872690,
            d_meshrenderer_icon = 1942237396,
            d_motion_icon = 1321341649,
            d_occlusionarea_icon = 915407204,
            d_occlusionportal_icon = 256208101,
            d_particlesystem_icon = 1048938953,
            d_particlesystemforcefield_icon = 1581477562,
            d_physicmaterial_icon = 756438894,
            d_physicmaterial_on_icon = 1244737505,
            d_physicsmaterial2d_icon = 1408981637,
            d_physicsmaterial2d_on_icon = 15189255,
            d_platformeffector2d_icon = 557435281,
            d_pointeffector2d_icon = 561188892,
            d_polygoncollider2d_icon = 32558173,
            d_proceduralmaterial_icon = 585080091,
            d_projector_icon = 789074895,
            d_raytracingshader_icon = 1579056626,
            d_recttransform_icon = 1607861592,
            d_reflectionprobe_icon = 870159241,
            d_relativejoint2d_icon = 1759282540,
            d_rendertexture_icon = 821976038,
            d_rendertexture_on_icon = 165712423,
            d_rigidbody_icon = 769892732,
            d_rigidbody2d_icon = 1357100301,
            d_scriptableobject_icon = 1823887379,
            d_scriptableobject_on_icon = 1794937895,
            d_shader_icon = 332107676,
            d_shadervariantcollection_icon = 1280036468,
            d_skinnedmeshrenderer_icon = 1734032413,
            d_skybox_icon = 1533029192,
            d_sliderjoint2d_icon = 1212312220,
            d_spherecollider_icon = 1362484104,
            d_springjoint_icon = 270659366,
            d_springjoint2d_icon = 260255152,
            d_sprite_icon = 214005383,
            d_spritemask_icon = 481408109,
            d_spriterenderer_icon = 899831787,
            d_streamingcontroller_icon = 554594968,
            d_surfaceeffector2d_icon = 717243837,
            d_targetjoint2d_icon = 1466643603,
            d_terrain_icon = 632134940,
            d_terraincollider_icon = 206610389,
            d_terraindata_icon = 1891771712,
            d_textasset_icon = 656125008,
            d_texture_icon = 1630429389,
            d_texture2d_icon = 700705341,
            d_trailrenderer_icon = 1903850501,
            d_transform_icon = 1267497728,
            d_wheelcollider_icon = 1125409031,
            d_wheeljoint2d_icon = 1850359293,
            d_windzone_icon = 198095817,
            distancejoint2d_icon = 564555939,
            edgecollider2d_icon = 1802108391,
            d_eventsystem_icon = 1718099242,
            d_eventtrigger_icon = 407664124,
            d_hololensinputmodule_icon = 1037870767,
            d_physics2draycaster_icon = 1381775471,
            d_physicsraycaster_icon = 1522992652,
            d_standaloneinputmodule_icon = 1923113705,
            d_touchinputmodule_icon = 1702112566,
            eventsystem_icon = 510779407,
            eventtrigger_icon = 705555846,
            hololensinputmodule_icon = 360790820,
            physics2draycaster_icon = 1710685121,
            physicsraycaster_icon = 1847372540,
            standaloneinputmodule_icon = 1178934347,
            touchinputmodule_icon = 1818926175,
            raytracingshader_icon = 749172690,
            fixedjoint_icon = 1204245452,
            fixedjoint2d_icon = 339463952,
            flare_icon = 1806174375,
            flare_on_icon = 1806142571,
            flarelayer_icon = 1176721486,
            font_icon = 1582938071,
            font_on_icon = 1383486452,
            frictionjoint2d_icon = 145273922,
            gameobject_icon = 142961833,
            gameobject_on_icon = 1742212944,
            grid_icon = 1358245574,
            guilayer_icon = 744644242,
            guiskin_icon = 508768366,
            guiskin_on_icon = 1357074920,
            guitext_icon = 986032664,
            guitexture_icon = 409657507,
            halo_icon = 1102161187,
            hingejoint_icon = 1532255580,
            hingejoint2d_icon = 1248489460,
            lensflare_icon = 1780628277,
            light_icon = 1635985791,
            lightingsettings_icon = 1189363535,
            lightprobegroup_icon = 1724961686,
            lightprobeproxyvolume_icon = 1722348753,
            lightprobes_icon = 5105550,
            linerenderer_icon = 296926648,
            lodgroup_icon = 1001088159,
            material_icon = 1989694751,
            material_on_icon = 1017864352,
            mesh_icon = 568855900,
            meshcollider_icon = 773117760,
            meshfilter_icon = 46520345,
            meshrenderer_icon = 606907141,
            motion_icon = 2102338809,
            movietexture_icon = 814319232,
            d_networkanimator_icon = 969007833,
            d_networkdiscovery_icon = 1249335163,
            d_networkidentity_icon = 1784940576,
            d_networklobbymanager_icon = 1353182489,
            d_networklobbyplayer_icon = 631161809,
            d_networkmanager_icon = 770406134,
            d_networkmanagerhud_icon = 1999033944,
            d_networkmigrationmanager_icon = 2082962359,
            d_networkproximitychecker_icon = 424420280,
            d_networkstartposition_icon = 556989354,
            d_networktransform_icon = 180088007,
            d_networktransformchild_icon = 1774988816,
            d_networktransformvisualizer_icon = 1901205131,
            networkanimator_icon = 581095586,
            networkdiscovery_icon = 1317076163,
            networkidentity_icon = 1103050602,
            networklobbymanager_icon = 1480089197,
            networklobbyplayer_icon = 315650319,
            networkmanager_icon = 1069405827,
            networkmanagerhud_icon = 924658250,
            networkmigrationmanager_icon = 407837872,
            networkproximitychecker_icon = 1078578708,
            networkstartposition_icon = 1404510012,
            networktransform_icon = 577321692,
            networktransformchild_icon = 2108954728,
            networktransformvisualizer_icon = 1800222101,
            networkview_icon = 2020655607,
            occlusionarea_icon = 646286515,
            occlusionportal_icon = 27096670,
            particlesystem_icon = 1742385299,
            particlesystemforcefield_icon = 1254226890,
            physicmaterial_icon = 1596951580,
            physicmaterial_on_icon = 1142275321,
            physicsmaterial2d_icon = 750226236,
            physicsmaterial2d_on_icon = 1054730766,
            platformeffector2d_icon = 529958610,
            d_playabledirector_icon = 996875853,
            playabledirector_icon = 783896269,
            pointeffector2d_icon = 1807608899,
            polygoncollider2d_icon = 1480214564,
            proceduralmaterial_icon = 1197171062,
            projector_icon = 1734135778,
            recttransform_icon = 294625611,
            reflectionprobe_icon = 1794485595,
            relativejoint2d_icon = 1360524885,
            d_sortinggroup_icon = 112535947,
            sortinggroup_icon = 320880221,
            rendertexture_icon = 1016216384,
            rendertexture_on_icon = 820287315,
            rigidbody_icon = 35147772,
            rigidbody2d_icon = 1779252764,
            scriptableobject_icon = 1712387935,
            scriptableobject_on_icon = 1073178298,
            shader_icon = 1303745155,
            shadervariantcollection_icon = 1304860673,
            skinnedmeshrenderer_icon = 1889047761,
            skybox_icon = 470104439,
            sliderjoint2d_icon = 413041342,
            trackedposedriver_icon = 349463547,
            spherecollider_icon = 513163720,
            springjoint_icon = 1212380623,
            springjoint2d_icon = 605001265,
            sprite_icon = 1935297506,
            spritemask_icon = 1861447028,
            spriterenderer_icon = 354780280,
            streamingcontroller_icon = 1530043853,
            surfaceeffector2d_icon = 1967393515,
            targetjoint2d_icon = 1297565044,
            terrain_icon = 981789435,
            terraincollider_icon = 1069406777,
            terraindata_icon = 1597117457,
            textasset_icon = 2107961313,
            textmesh_icon = 1627178733,
            texture_icon = 1160730481,
            texture2d_icon = 1092310469,
            d_tile_icon = 1797596486,
            d_tilemap_icon = 41491713,
            d_tilemapcollider2d_icon = 1840275116,
            d_tilemaprenderer_icon = 542413330,
            tile_icon = 1732439102,
            tilemap_icon = 350847177,
            tilemapcollider2d_icon = 988390009,
            tilemaprenderer_icon = 278830728,
            d_signalasset_icon = 662388577,
            d_signalemitter_icon = 1916085336,
            d_signalreceiver_icon = 2052931560,
            d_timelineasset_icon = 543021828,
            d_timelineasset_on_icon = 1076589269,
            signalasset_icon = 1140315384,
            signalemitter_icon = 1786077832,
            signalreceiver_icon = 1186177232,
            timelineasset_icon = 322970736,
            timelineasset_on_icon = 523366347,
            trailrenderer_icon = 2113732486,
            transform_icon = 871685198,
            tree_icon = 1450755346,
            d_spriteatlas_icon = 1712803032,
            d_spriteatlas_on_icon = 1983648847,
            d_spriteshaperenderer_icon = 430774036,
            spriteatlas_icon = 1320322107,
            spriteatlas_on_icon = 575469594,
            spriteshaperenderer_icon = 1986845272,
            aspectratiofitter_icon = 1893750970,
            button_icon = 582031593,
            canvasscaler_icon = 1875913954,
            contentsizefitter_icon = 664935331,
            d_aspectratiofitter_icon = 1179186987,
            d_button_icon = 1296883192,
            d_canvasscaler_icon = 1475015955,
            d_contentsizefitter_icon = 1734483698,
            d_dropdown_icon = 422008911,
            d_freeformlayoutgroup_icon = 854821163,
            d_graphicraycaster_icon = 225713335,
            d_image_icon = 200249796,
            d_inputfield_icon = 920727849,
            d_layoutelement_icon = 1125959249,
            d_mask_icon = 464468484,
            d_outline_icon = 373431924,
            d_physicalresolution_icon = 1327620287,
            d_positionasuv1_icon = 1320710189,
            d_rawimage_icon = 1076831151,
            d_rectmask2d_icon = 77887210,
            d_scrollbar_icon = 331231207,
            d_scrollrect_icon = 142115293,
            d_scrollviewarea_icon = 14203888,
            d_selectable_icon = 616318351,
            d_selectionlist_icon = 1916880928,
            d_selectionlistitem_icon = 1260959532,
            d_selectionlisttemplate_icon = 740288037,
            d_shadow_icon = 1805085786,
            d_slider_icon = 1354533704,
            d_text_icon = 212934539,
            d_toggle_icon = 1514716327,
            d_togglegroup_icon = 2088485569,
            dropdown_icon = 564540468,
            freeformlayoutgroup_icon = 971247907,
            graphicraycaster_icon = 693963549,
            gridlayoutgroup_icon = 1723766774,
            image_icon = 1764744399,
            inputfield_icon = 985879363,
            layoutelement_icon = 8804262,
            mask_icon = 1621960521,
            outline_icon = 2084256966,
            positionasuv1_icon = 2099376352,
            rawimage_icon = 421201798,
            rectmask2d_icon = 331581766,
            scrollbar_icon = 1221643334,
            scrollrect_icon = 1533856532,
            selectable_icon = 729132341,
            shadow_icon = 1985875454,
            slider_icon = 1342980387,
            text_icon = 2050229038,
            toggle_icon = 1091506763,
            togglegroup_icon = 272241753,
            verticallayoutgroup_icon = 1735550549,
            d_panelsettings_icon = 1090823874,
            d_panelsettings_on_icon = 1545667380,
            d_stylesheet_icon = 491395975,
            d_uidocument_icon = 2000857148,
            d_visualtreeasset_icon = 159361382,
            panelsettings_icon = 1634345468,
            panelsettings_on_icon = 1749313721,
            stylesheet_icon = 1329645791,
            uidocument_icon = 1615907737,
            visualtreeasset_icon = 678419832,
            d_visualeffect_icon = 1526532473,
            d_visualeffectasset_icon = 315615807,
            visualeffect_icon = 786135607,
            visualeffectasset_icon = 565015524,
            d_videoplayer_icon = 690774221,
            videoclip_icon = 406313083,
            videoplayer_icon = 1622248872,
            wheelcollider_icon = 677493124,
            wheeljoint2d_icon = 2097401350,
            windzone_icon = 476974231,
            d_spatialmappingcollider_icon = 1394669700,
            spatialmappingcollider_icon = 1865133585,
            spatialmappingrenderer_icon = 1798803144,
            worldanchor_icon = 1759120597,
            ussscript_icon = 1535519970,
            uxmlscript_icon = 244540846,
            videoeffect_icon = 258197379,
            visualeffect_gizmo = 304324236,
            windzone_gizmo = 453602824,
            profiler_audio = 1422745571,
            profiler_cpu = 1661141115,
            profiler_custom = 50517799,
            profiler_firstframe = 184735287,
            profiler_globalillumination = 770297146,
            profiler_gpu = 1598728295,
            profiler_instrumentation = 1550248318,
            profiler_lastframe = 1060115580,
            profiler_memory = 1707593604,
            profiler_networkmessages = 1773775208,
            profiler_networkoperations = 411489186,
            profiler_nextframe = 327010326,
            profiler_open = 350291501,
            profiler_physics = 766576789,
            profiler_physics2d = 180059052,
            profiler_prevframe = 350035148,
            profiler_record = 1926150139,
            profiler_rendering = 1645366641,
            profiler_ui = 1780991279,
            profiler_uidetails = 492319224,
            profiler_video = 1897285770,
            profiler_virtualtexturing = 81439303,
            profilercolumn_warningcount = 2120392817,
            progress = 2025679646,
            project = 1830227786,
            d_dragarrow = 32744001,
            d_gridview_on = 1082416403,
            d_gridview = 1082084567,
            d_help = 424041681,
            d_listview_on = 1057962737,
            d_listview = 1056719221,
            d_more = 151093889,
            d_searchwindow = 1556307080,
            d_syncsearch_on = 229510834,
            d_syncsearch = 1637287274,
            d_tableview_on = 343855859,
            d_tableview = 1180087373,
            dragarrow = 566985888,
            gridview_on = 1508442350,
            gridview = 1813192290,
            help = 1950895427,
            listview_on = 1012717599,
            listview = 2052480602,
            more = 697513728,
            package_installed = 866357652,
            package_update = 1539823781,
            searchwindow = 1143196222,
            syncsearch_on = 1484926561,
            syncsearch = 881615955,
            tableview_on = 1074114062,
            tableview = 1089592907,
            record_off = 1437533970,
            record_on = 620556555,
            recttool_on = 1566335215,
            recttool = 938786561,
            recttransformblueprint = 405926069,
            recttransformraw = 955758081,
            redgroove = 1808883765,
            reflectionprobeselector = 968881314,
            repaintdot = 194997348,
            rightbracket = 234580535,
            rotatetool_on = 1502895459,
            rotatetool = 1505509054,
            saveactive = 553335292,
            saveas = 219638450,
            savefromplay = 497257895,
            savepassive = 1768577240,
            scaletool_on = 1504933595,
            scaletool = 750893202,
            sceneloadin = 2034156144,
            sceneloadout = 1374266492,
            scenepicking_notpickable_mixed = 545041724,
            scenepicking_notpickable_mixed_hover = 1878858517,
            scenepicking_notpickable = 1239651338,
            scenepicking_notpickable_hover = 403930097,
            scenepicking_pickable_mixed = 1663584249,
            scenepicking_pickable_mixed_hover = 315738667,
            scenepicking_pickable = 97054754,
            scenepicking_pickable_hover = 1165767149,
            scenesave = 2012855852,
            scenesavegrey = 524538575,
            pin = 724451168,
            pinned = 1691762255,
            scene_template_2d_scene = 1970079398,
            scene_template_3d_scene = 898801600,
            scene_template_dark = 1582753760,
            scene_template_default_scene = 568554648,
            scene_template_empty_scene = 1670863302,
            scene_template_light = 1770876019,
            scene_template = 1321662025,
            sceneview2d_on = 1541583874,
            sceneview2d = 1842473437,
            sceneviewalpha = 244419155,
            sceneviewaudio_on = 972318446,
            sceneviewaudio = 111819502,
            sceneviewcamera_on = 1016268220,
            sceneviewcamera = 385250731,
            sceneviewfx_on = 1200384552,
            sceneviewfx = 1551379526,
            sceneviewlighting_on = 707444555,
            sceneviewlighting = 2127711372,
            sceneviewortho = 2146351761,
            sceneviewrgb = 1031497691,
            sceneviewtools_on = 2057761529,
            sceneviewtools = 291877534,
            sceneviewvisibility_on = 1396810191,
            sceneviewvisibility = 730007104,
            scenevis_hidden_mixed = 1589940893,
            scenevis_hidden_mixed_hover = 318963483,
            scenevis_hidden = 679264114,
            scenevis_hidden_hover = 2049871917,
            scenevis_scene_hover = 810585437,
            scenevis_visible_mixed = 1727549517,
            scenevis_visible_mixed_hover = 118641258,
            scenevis_visible = 100489210,
            scenevis_visible_hover = 595111103,
            scrollshadow = 1724252053,
            settings = 1862119393,
            settingsicon = 509968824,
            alertdialog = 1473117535,
            conflict_icon = 195580191,
            showpanels = 468619460,
            d_gridaxisx_on = 1729423831,
            d_gridaxisx = 1015160864,
            d_gridaxisy_on = 357407583,
            d_gridaxisy = 1870491580,
            d_gridaxisz_on = 1111990280,
            d_gridaxisz = 1142497775,
            d_sceneviewsnap_on = 1811019253,
            d_sceneviewsnap = 1259908995,
            d_snapincrement = 2062630472,
            gridaxisx_on = 2127750235,
            gridaxisx = 247810204,
            gridaxisy_on = 811323330,
            gridaxisy = 1265577347,
            gridaxisz_on = 796092915,
            gridaxisz = 1257146716,
            sceneviewsnap_on = 1964147671,
            sceneviewsnap = 1222797139,
            snapincrement = 730365953,
            socialnetworks_facebookshare = 2093990882,
            socialnetworks_linkedinshare = 496482247,
            socialnetworks_tweet = 1852386286,
            socialnetworks_udnlogo = 657548434,
            socialnetworks_udnopen = 666955647,
            softlockinline = 596021918,
            speedscale = 1066854039,
            statemachineeditor_arrowtip = 8010558,
            statemachineeditor_arrowtipselected = 168487135,
            statemachineeditor_background = 170320510,
            statemachineeditor_state = 1232270404,
            statemachineeditor_statehover = 1017071610,
            statemachineeditor_stateselected = 828259354,
            statemachineeditor_statesub = 1039677127,
            statemachineeditor_statesubhover = 83742362,
            statemachineeditor_statesubselected = 1077918427,
            statemachineeditor_upbutton = 476286462,
            statemachineeditor_upbuttonhover = 1953772997,
            stepbutton_on = 457312982,
            stepbutton = 2059385748,
            stepleftbutton_on = 1433799502,
            stepleftbutton = 1536028795,
            sv_icon_dot0_sml = 1390249584,
            sv_icon_dot10_sml = 922382048,
            sv_icon_dot11_sml = 442173561,
            sv_icon_dot12_sml = 92848243,
            sv_icon_dot13_sml = 1669236255,
            sv_icon_dot14_sml = 1482906454,
            sv_icon_dot15_sml = 26649881,
            sv_icon_dot1_sml = 1391238125,
            sv_icon_dot2_sml = 251031495,
            sv_icon_dot3_sml = 952705804,
            sv_icon_dot4_sml = 699626489,
            sv_icon_dot5_sml = 75927223,
            sv_icon_dot6_sml = 851173784,
            sv_icon_dot7_sml = 909713109,
            sv_icon_dot8_sml = 1663587776,
            sv_icon_dot9_sml = 583672482,
            sv_icon_name0 = 1848341419,
            sv_icon_name1 = 766141694,
            sv_icon_name2 = 604405669,
            sv_icon_name3 = 2061290746,
            sv_icon_name4 = 341842766,
            sv_icon_name5 = 1838885139,
            sv_icon_name6 = 273882957,
            sv_icon_name7 = 1779912646,
            sv_icon_none = 1818785645,
            sv_label_0 = 569851127,
            sv_label_1 = 371120639,
            sv_label_2 = 1116621779,
            sv_label_3 = 1025157111,
            sv_label_4 = 1381738733,
            sv_label_5 = 1116054509,
            sv_label_6 = 1479013059,
            sv_label_7 = 1321746589,
            tab_next = 837196693,
            tab_prev = 1980597909,
            tabtofilter = 1927382353,
            terraininspector_terraintooladd = 823604279,
            terraininspector_terraintoollower_on = 2070893235,
            terraininspector_terraintoollower = 1081407723,
            terraininspector_terraintoolloweralt = 500079251,
            terraininspector_terraintoolplants_on = 2109838921,
            terraininspector_terraintoolplants = 1955842564,
            terraininspector_terraintoolplantsalt_on = 1870256780,
            terraininspector_terraintoolplantsalt = 449058496,
            terraininspector_terraintoolraise_on = 1122783284,
            terraininspector_terraintoolraise = 1372478545,
            terraininspector_terraintoolsculpt_on = 139179366,
            terraininspector_terraintoolsculpt = 1471083265,
            terraininspector_terraintoolsetheight_on = 1275331318,
            terraininspector_terraintoolsetheight = 523995377,
            terraininspector_terraintoolsetheightalt_on = 1256887090,
            terraininspector_terraintoolsetheightalt = 273513093,
            terraininspector_terraintoolsettings_on = 1297559828,
            terraininspector_terraintoolsettings = 653473338,
            terraininspector_terraintoolsmoothheight_on = 1547880249,
            terraininspector_terraintoolsmoothheight = 1466875229,
            terraininspector_terraintoolsplat_on = 595444736,
            terraininspector_terraintoolsplat = 1344570231,
            terraininspector_terraintoolsplatalt_on = 1352398357,
            terraininspector_terraintoolsplatalt = 1841221747,
            terraininspector_terraintooltrees_on = 251864410,
            terraininspector_terraintooltrees = 379266240,
            terraininspector_terraintooltreesalt_on = 1915953808,
            terraininspector_terraintooltreesalt = 844461384,
            testfailed = 204747761,
            testignored = 1287052313,
            testinconclusive = 1074059456,
            testnormal = 850351077,
            testpassed = 1064670504,
            teststopwatch = 1221192480,
            toggleuvoverlay = 113490280,
            toolbar_minus = 739692933,
            toolbar_plus_more = 109508585,
            toolbar_plus = 890883159,
            d_debug = 1637392915,
            d_objectmode = 535734500,
            d_sceneviewtools_on = 705906272,
            d_shaded = 1091586477,
            d_shadedwireframe = 1507591219,
            d_wireframe = 1538939595,
            debug_on = 376834706,
            debug = 1719714683,
            objectmode = 956421585,
            shaded = 828039223,
            shadedwireframe = 1814383200,
            wireframe = 419265523,
            toolhandlecenter = 826114142,
            toolhandleglobal = 130350678,
            toolhandlelocal = 242288455,
            toolhandlepivot = 1435626165,
            toolsicon = 154960055,
            tranp = 643450006,
            transformtool_on = 2016575750,
            transformtool = 724227444,
            tree_icon_branch = 1912549939,
            tree_icon_branch_frond = 236335743,
            tree_icon_frond = 800610184,
            tree_icon_leaf = 794386630,
            treeeditor_addbranches = 635770024,
            treeeditor_addleaves = 1786381256,
            treeeditor_branch_on = 652139613,
            treeeditor_branch = 665118581,
            treeeditor_branchfreehand_on = 1805549547,
            treeeditor_branchfreehand = 1321342150,
            treeeditor_branchrotate_on = 1249252574,
            treeeditor_branchrotate = 422063712,
            treeeditor_branchscale_on = 1105736587,
            treeeditor_branchscale = 246898811,
            treeeditor_branchtranslate_on = 1719561673,
            treeeditor_branchtranslate = 1177247486,
            treeeditor_distribution_on = 1797848458,
            treeeditor_distribution = 153458785,
            treeeditor_duplicate = 353073741,
            treeeditor_geometry_on = 607288484,
            treeeditor_geometry = 1380891419,
            treeeditor_leaf_on = 2025560454,
            treeeditor_leaf = 756412397,
            treeeditor_leaffreehand_on = 788785588,
            treeeditor_leaffreehand = 1021821654,
            treeeditor_leafrotate_on = 799956073,
            treeeditor_leafrotate = 1732229845,
            treeeditor_leafscale_on = 1944660972,
            treeeditor_leafscale = 1290293739,
            treeeditor_leaftranslate_on = 613667965,
            treeeditor_leaftranslate = 1693653089,
            treeeditor_material_on = 354706197,
            treeeditor_material = 464565313,
            treeeditor_refresh = 1731004495,
            treeeditor_trash = 1919710381,
            treeeditor_wind_on = 1940778849,
            treeeditor_wind = 360021333,
            unityeditor_animationwindow = 1515016442,
            unityeditor_consolewindow = 1160597450,
            unityeditor_debuginspectorwindow = 1393602687,
            unityeditor_devicesimulation_simulatorwindow = 1123531351,
            unityeditor_finddependencies = 1890327344,
            unityeditor_gameview = 635706022,
            unityeditor_graphs_animatorcontrollertool = 407346852,
            unityeditor_hierarchywindow = 738620319,
            unityeditor_inspectorwindow = 1915978197,
            unityeditor_profilerwindow = 146255829,
            unityeditor_scenehierarchywindow = 764825886,
            unityeditor_sceneview = 65753738,
            unityeditor_timeline_timelinewindow = 2131551715,
            unityeditor_versioncontrol = 286643731,
            unitylogo = 160881633,
            unitylogolarge = 1460414404,
            unlinked = 2093099907,
            uparrow = 663444784,
            valid = 338507936,
            d_file = 1978199476,
            d_incoming_icon = 987583809,
            d_p4_addedlocal = 1126142702,
            d_p4_addedremote = 1871535016,
            d_p4_blueleftparenthesis = 1574507404,
            d_p4_bluerightparenthesis = 1526969616,
            d_p4_checkoutlocal = 1655060417,
            d_p4_checkoutremote = 225774281,
            d_p4_conflicted = 1676087832,
            d_p4_deletedlocal = 2018652975,
            d_p4_deletedremote = 1687043685,
            d_p4_local = 666985840,
            d_p4_lockedlocal = 351098455,
            d_p4_lockedremote = 264904001,
            d_p4_offline = 1795478528,
            d_p4_outofsync = 842874627,
            d_p4_redleftparenthesis = 2097132623,
            d_p4_redrightparenthesis = 428775033,
            d_p4_updating = 16442775,
            file = 1226148033,
            incoming_icon = 901458517,
            incoming_on_icon = 1551629229,
            outgoing_icon = 1025174846,
            p4_addedlocal = 684570091,
            p4_addedremote = 875221606,
            p4_blueleftparenthesis = 1733135718,
            p4_bluerightparenthesis = 65086459,
            p4_checkoutlocal = 1357024412,
            p4_checkoutremote = 2064929372,
            p4_conflicted = 322597681,
            p4_deletedlocal = 1454675807,
            p4_deletedremote = 2022242825,
            p4_local = 356527442,
            p4_lockedlocal = 1496112793,
            p4_lockedremote = 1404317451,
            p4_offline = 1609473870,
            p4_outofsync = 78276318,
            p4_redleftparenthesis = 1943576131,
            p4_redrightparenthesis = 909595288,
            p4_updating = 555845877,
            verticalsplit = 272266079,
            viewtoolmove_on = 84359272,
            viewtoolmove = 17647014,
            viewtoolorbit_on = 828459913,
            viewtoolorbit = 1544305349,
            viewtoolzoom_on = 1636538653,
            viewtoolzoom = 1858018644,
            visibilityoff = 450510117,
            visibilityon = 284655790,
            vumetertexturehorizontal = 1561012804,
            vumetertexturevertical = 904782001,
            waitspin00 = 780483899,
            waitspin01 = 958847082,
            waitspin02 = 1721450102,
            waitspin03 = 1091150809,
            waitspin04 = 1675068562,
            waitspin05 = 457763786,
            waitspin06 = 1009105698,
            waitspin07 = 1283957309,
            waitspin08 = 1514836552,
            waitspin09 = 1506456776,
            waitspin10 = 356096879,
            waitspin11 = 198171155,
            welcomescreen_assetstorelogo = 193035699,
            winbtn_graph = 1332286160,
            winbtn_graph_close_h = 329819183,
            winbtn_graph_max_h = 807179353,
            winbtn_graph_min_h = 787854828,
            winbtn_mac_close = 1466210313,
            winbtn_mac_close_a = 2039970139,
            winbtn_mac_close_h = 1308990709,
            winbtn_mac_inact = 1141740854,
            winbtn_mac_max = 523533862,
            winbtn_mac_max_a = 1961164212,
            winbtn_mac_max_h = 136656436,
            winbtn_mac_min = 1836184589,
            winbtn_mac_min_a = 1375455187,
            winbtn_mac_min_h = 336800021,
            winbtn_win_close = 348011812,
            winbtn_win_close_a = 1233789776,
            winbtn_win_close_h = 2026977057,
            winbtn_win_max = 1820442515,
            winbtn_win_max_a = 1877916457,
            winbtn_win_max_h = 455048983,
            winbtn_win_min = 290150445,
            winbtn_win_min_a = 143280975,
            winbtn_win_min_h = 113937816,
            winbtn_win_rest = 685475082,
            winbtn_win_rest_a = 832496382,
            winbtn_win_rest_h = 1086668029,
            winbtn_win_restore = 884004928,
            winbtn_win_restore_a = 74597796,
            winbtn_win_restore_h = 1771169877,

        }

        internal enum SortEnum
        {
            None = 0,
            _help = 1,
            _menu = 2,
            _popup = 3,
            aboutwindow_mainheader = 4,
            ageialogo = 5,
            alphabeticalsorting = 6,
            anchortransformtool_on = 7,
            anchortransformtool = 8,
            animation_addevent = 9,
            animation_addkeyframe = 10,
            animation_eventmarker = 11,
            animation_filterbyselection = 12,
            animation_firstkey = 13,
            animation_lastkey = 14,
            animation_nextkey = 15,
            animation_play = 16,
            animation_prevkey = 17,
            animation_record = 18,
            animation_sequencerlink = 19,
            animationanimated = 20,
            animationdopesheetkeyframe = 21,
            animationkeyframe = 22,
            animationnocurve = 23,
            animationvisibilitytoggleoff = 24,
            animationvisibilitytoggleon = 25,
            animationwrapmodemenu = 26,
            assemblylock = 27,
            asset_store = 28,
            unity_assetstore_originals_logo_white = 29,
            audio_mixer = 30,
            autolightbakingoff = 31,
            autolightbakingon = 32,
            avatarcompass = 33,
            avatarcontroller_layer = 34,
            avatarcontroller_layerhover = 35,
            avatarcontroller_layerselected = 36,
            bodypartpicker = 37,
            bodysilhouette = 38,
            dotfill = 39,
            dotframe = 40,
            dotframedotted = 41,
            dotselection = 42,
            head = 43,
            headik = 44,
            headzoom = 45,
            headzoomsilhouette = 46,
            leftarm = 47,
            leftfeetik = 48,
            leftfingers = 49,
            leftfingersik = 50,
            lefthandzoom = 51,
            lefthandzoomsilhouette = 52,
            leftleg = 53,
            maskeditor_root = 54,
            rightarm = 55,
            rightfeetik = 56,
            rightfingers = 57,
            rightfingersik = 58,
            righthandzoom = 59,
            righthandzoomsilhouette = 60,
            rightleg = 61,
            torso = 62,
            avatarpivot = 63,
            avatarselector = 64,
            back = 65,
            beginbutton_on = 66,
            beginbutton = 67,
            blendkey = 68,
            blendkeyoverlay = 69,
            blendkeyselected = 70,
            blendsampler = 71,
            bluegroove = 72,
            buildsettings_android_on = 73,
            buildsettings_android = 74,
            buildsettings_android_small = 75,
            buildsettings_broadcom = 76,
            buildsettings_editor = 77,
            buildsettings_editor_small = 78,
            buildsettings_embeddedlinux_on = 79,
            buildsettings_embeddedlinux = 80,
            buildsettings_embeddedlinux_small = 81,
            buildsettings_facebook_on = 82,
            buildsettings_facebook = 83,
            buildsettings_facebook_small = 84,
            buildsettings_flashplayer = 85,
            buildsettings_flashplayer_small = 86,
            buildsettings_gamecorescarlett_on = 87,
            buildsettings_gamecorescarlett = 88,
            buildsettings_gamecorescarlett_small = 89,
            buildsettings_gamecorexboxone_on = 90,
            buildsettings_gamecorexboxone = 91,
            buildsettings_gamecorexboxone_small = 92,
            buildsettings_iphone_on = 93,
            buildsettings_iphone = 94,
            buildsettings_iphone_small = 95,
            buildsettings_lumin_on = 96,
            buildsettings_lumin = 97,
            buildsettings_lumin_small = 98,
            buildsettings_metro_on = 99,
            buildsettings_metro = 100,
            buildsettings_metro_small = 101,
            buildsettings_n3ds_on = 102,
            buildsettings_n3ds = 103,
            buildsettings_n3ds_small = 104,
            buildsettings_ps4_on = 105,
            buildsettings_ps4 = 106,
            buildsettings_ps4_small = 107,
            buildsettings_ps5_on = 108,
            buildsettings_ps5 = 109,
            buildsettings_ps5_small = 110,
            buildsettings_psm = 111,
            buildsettings_psm_small = 112,
            buildsettings_psp2 = 113,
            buildsettings_psp2_small = 114,
            buildsettings_selectedicon = 115,
            buildsettings_stadia_on = 116,
            buildsettings_stadia = 117,
            buildsettings_stadia_small = 118,
            buildsettings_standalone_on = 119,
            buildsettings_standalone = 120,
            buildsettings_standalone_small = 121,
            buildsettings_standalonebroadcom_small = 122,
            buildsettings_standalonegles20emu_small = 123,
            buildsettings_standaloneglesemu = 124,
            buildsettings_standaloneglesemu_small = 125,
            buildsettings_switch_on = 126,
            buildsettings_switch = 127,
            buildsettings_switch_small = 128,
            buildsettings_tvos_on = 129,
            buildsettings_tvos = 130,
            buildsettings_tvos_small = 131,
            buildsettings_web = 132,
            buildsettings_web_small = 133,
            buildsettings_webgl_on = 134,
            buildsettings_webgl = 135,
            buildsettings_webgl_small = 136,
            buildsettings_wp8 = 137,
            buildsettings_wp8_small = 138,
            buildsettings_xbox360 = 139,
            buildsettings_xbox360_small = 140,
            buildsettings_xboxone_on = 141,
            buildsettings_xboxone = 142,
            buildsettings_xboxone_small = 143,
            cacheserverconnected = 144,
            cacheserverdisabled = 145,
            cacheserverdisconnected = 146,
            checkerfloor = 147,
            clipboard = 148,
            clothinspector_painttool = 149,
            clothinspector_paintvalue = 150,
            clothinspector_selecttool = 151,
            clothinspector_settingstool = 152,
            clothinspector_viewvalue = 153,
            cloudconnect = 154,
            collab_build = 155,
            collab_buildfailed = 156,
            collab_buildsucceeded = 157,
            collab_fileadded = 158,
            collab_fileconflict = 159,
            collab_filedeleted = 160,
            collab_fileignored = 161,
            collab_filemoved = 162,
            collab_fileupdated = 163,
            collab_folderadded = 164,
            collab_folderconflict = 165,
            collab_folderdeleted = 166,
            collab_folderignored = 167,
            collab_foldermoved = 168,
            collab_folderupdated = 169,
            collab_nointernet = 170,
            collab = 171,
            collab_warning = 172,
            collabconflict = 173,
            collaberror = 174,
            collabnew = 175,
            collaboffline = 176,
            collabprogress = 177,
            collabpull = 178,
            collabpush = 179,
            colorpicker_colorcycle = 180,
            colorpicker_cyclecolor = 181,
            colorpicker_cycleslider = 182,
            colorpicker_slidercycle = 183,
            console_erroricon_inactive_sml = 184,
            console_erroricon = 185,
            console_erroricon_sml = 186,
            console_infoicon_inactive_sml = 187,
            console_infoicon = 188,
            console_infoicon_sml = 189,
            console_warnicon_inactive_sml = 190,
            console_warnicon = 191,
            console_warnicon_sml = 192,
            createaddnew = 193,
            crossicon = 194,
            curvekeyframe = 195,
            curvekeyframeselected = 196,
            curvekeyframeselectedoverlay = 197,
            curvekeyframesemiselectedoverlay = 198,
            curvekeyframeweighted = 199,
            customsorting = 200,
            customtool = 201,
            d__help = 202,
            d__menu = 203,
            d__popup = 204,
            d_aboutwindow_mainheader = 205,
            d_ageialogo = 206,
            d_alphabeticalsorting = 207,
            d_anchortransformtool_on = 208,
            d_anchortransformtool = 209,
            d_animation_addevent = 210,
            d_animation_addkeyframe = 211,
            d_animation_eventmarker = 212,
            d_animation_filterbyselection = 213,
            d_animation_firstkey = 214,
            d_animation_lastkey = 215,
            d_animation_nextkey = 216,
            d_animation_play = 217,
            d_animation_prevkey = 218,
            d_animation_record = 219,
            d_animation_sequencerlink = 220,
            d_animationanimated = 221,
            d_animationkeyframe = 222,
            d_animationnocurve = 223,
            d_animationvisibilitytoggleoff = 224,
            d_animationvisibilitytoggleon = 225,
            d_animationwrapmodemenu = 226,
            d_as_badge_delete = 227,
            d_as_badge_new = 228,
            d_assemblylock = 229,
            d_asset_store = 230,
            d_audio_mixer = 231,
            d_autolightbakingoff = 232,
            d_autolightbakingon = 233,
            d_avatarblendbackground = 234,
            d_avatarblendleft = 235,
            d_avatarblendlefta = 236,
            d_avatarblendright = 237,
            d_avatarblendrighta = 238,
            d_avatarcompass = 239,
            d_avatarpivot = 240,
            d_avatarselector = 241,
            d_back = 242,
            d_beginbutton_on = 243,
            d_beginbutton = 244,
            d_bluegroove = 245,
            d_buildsettings_android = 246,
            d_buildsettings_android_small = 247,
            d_buildsettings_broadcom = 248,
            d_buildsettings_facebook = 249,
            d_buildsettings_facebook_small = 250,
            d_buildsettings_flashplayer = 251,
            d_buildsettings_flashplayer_small = 252,
            d_buildsettings_gamecorescarlett = 253,
            d_buildsettings_gamecorescarlett_small = 254,
            d_buildsettings_gamecorexboxone = 255,
            d_buildsettings_gamecorexboxone_small = 256,
            d_buildsettings_iphone = 257,
            d_buildsettings_iphone_small = 258,
            d_buildsettings_lumin = 259,
            d_buildsettings_lumin_small = 260,
            d_buildsettings_metro = 261,
            d_buildsettings_metro_small = 262,
            d_buildsettings_n3ds = 263,
            d_buildsettings_n3ds_small = 264,
            d_buildsettings_ps4 = 265,
            d_buildsettings_ps4_small = 266,
            d_buildsettings_ps5 = 267,
            d_buildsettings_ps5_small = 268,
            d_buildsettings_psp2 = 269,
            d_buildsettings_psp2_small = 270,
            d_buildsettings_selectedicon = 271,
            d_buildsettings_stadia = 272,
            d_buildsettings_stadia_small = 273,
            d_buildsettings_standalone = 274,
            d_buildsettings_standalone_small = 275,
            d_buildsettings_switch = 276,
            d_buildsettings_switch_small = 277,
            d_buildsettings_tvos = 278,
            d_buildsettings_tvos_small = 279,
            d_buildsettings_web = 280,
            d_buildsettings_web_small = 281,
            d_buildsettings_webgl = 282,
            d_buildsettings_webgl_small = 283,
            d_buildsettings_xbox360 = 284,
            d_buildsettings_xbox360_small = 285,
            d_buildsettings_xboxone = 286,
            d_buildsettings_xboxone_small = 287,
            d_buildsettings_xiaomi = 288,
            d_buildsettings_xiaomi_small = 289,
            d_cacheserverconnected = 290,
            d_cacheserverdisabled = 291,
            d_cacheserverdisconnected = 292,
            d_checkerfloor = 293,
            d_cloudconnect = 294,
            d_collab_fileadded = 295,
            d_collab_fileconflict = 296,
            d_collab_filedeleted = 297,
            d_collab_fileignored = 298,
            d_collab_filemoved = 299,
            d_collab_fileupdated = 300,
            d_collab_folderadded = 301,
            d_collab_folderconflict = 302,
            d_collab_folderdeleted = 303,
            d_collab_folderignored = 304,
            d_collab_foldermoved = 305,
            d_collab_folderupdated = 306,
            d_collab = 307,
            d_colorpicker_cyclecolor = 308,
            d_colorpicker_cycleslider = 309,
            d_console_erroricon_inactive_sml = 310,
            d_console_erroricon = 311,
            d_console_erroricon_sml = 312,
            d_console_infoicon_inactive_sml = 313,
            d_console_infoicon = 314,
            d_console_infoicon_sml = 315,
            d_console_warnicon_inactive_sml = 316,
            d_console_warnicon = 317,
            d_console_warnicon_sml = 318,
            d_createaddnew = 319,
            d_curvekeyframe = 320,
            d_curvekeyframeselected = 321,
            d_curvekeyframeselectedoverlay = 322,
            d_curvekeyframesemiselectedoverlay = 323,
            d_curvekeyframeweighted = 324,
            d_customsorting = 325,
            d_customtool = 326,
            d_debuggerattached = 327,
            d_debuggerdisabled = 328,
            d_debuggerenabled = 329,
            d_defaultsorting = 330,
            d_editcollider = 331,
            d_editcollision_16 = 332,
            d_editcollision_32 = 333,
            d_editconstraints_16 = 334,
            d_editconstraints_32 = 335,
            d_editicon_sml = 336,
            d_endbutton_on = 337,
            d_endbutton = 338,
            d_exposure = 339,
            d_eyedropper_large = 340,
            d_eyedropper_sml = 341,
            d_favorite = 342,
            d_filterbylabel = 343,
            d_filterbytype = 344,
            d_filterselectedonly = 345,
            d_forward = 346,
            d_framecapture = 347,
            d_gear = 348,
            d_gizmostoggle_on = 349,
            d_gizmostoggle = 350,
            d_grid_boxtool = 351,
            d_grid_default = 352,
            d_grid_erasertool = 353,
            d_grid_filltool = 354,
            d_grid_movetool = 355,
            d_grid_painttool = 356,
            d_grid_pickingtool = 357,
            d_groove = 358,
            d_horizontalsplit = 359,
            d_icon_dropdown = 360,
            d_import = 361,
            d_inspectorlock = 362,
            d_invalid = 363,
            d_jointangularlimits = 364,
            d_leftbracket = 365,
            d_lighting = 366,
            d_lightmapeditor_windowtitle = 367,
            d_linked = 368,
            d_mainstageview = 369,
            d_mirror = 370,
            d_model_large = 371,
            d_monologo = 372,
            d_moreoptions = 373,
            d_movetool_on = 374,
            d_movetool = 375,
            d_navigation = 376,
            d_occlusion = 377,
            d_package_manager = 378,
            d_particle_effect = 379,
            d_particleshapetool_on = 380,
            d_particleshapetool = 381,
            d_pausebutton_on = 382,
            d_pausebutton = 383,
            d_playbutton_on = 384,
            d_playbutton = 385,
            d_playbuttonprofile_on = 386,
            d_playbuttonprofile = 387,
            d_playloopoff = 388,
            d_playloopon = 389,
            d_preaudioautoplayoff = 390,
            d_preaudioautoplayon = 391,
            d_preaudioloopoff = 392,
            d_preaudioloopon = 393,
            d_preaudioplayoff = 394,
            d_preaudioplayon = 395,
            d_prematcube = 396,
            d_prematcylinder = 397,
            d_prematlight0 = 398,
            d_prematlight1 = 399,
            d_prematquad = 400,
            d_prematsphere = 401,
            d_premattorus = 402,
            d_preset_context = 403,
            d_pretexa = 404,
            d_pretexb = 405,
            d_pretexg = 406,
            d_pretexr = 407,
            d_pretexrgb = 408,
            d_pretexturealpha = 409,
            d_pretexturemipmaphigh = 410,
            d_pretexturemipmaplow = 411,
            d_pretexturergb = 412,
            d_profiler_audio = 413,
            d_profiler_cpu = 414,
            d_profiler_custom = 415,
            d_profiler_firstframe = 416,
            d_profiler_globalillumination = 417,
            d_profiler_gpu = 418,
            d_profiler_lastframe = 419,
            d_profiler_memory = 420,
            d_profiler_network = 421,
            d_profiler_networkmessages = 422,
            d_profiler_networkoperations = 423,
            d_profiler_nextframe = 424,
            d_profiler_open = 425,
            d_profiler_physics = 426,
            d_profiler_physics2d = 427,
            d_profiler_prevframe = 428,
            d_profiler_record = 429,
            d_profiler_rendering = 430,
            d_profiler_ui = 431,
            d_profiler_uidetails = 432,
            d_profiler_video = 433,
            d_profiler_virtualtexturing = 434,
            d_profilercolumn_warningcount = 435,
            d_progress = 436,
            d_project = 437,
            d_record_off = 438,
            d_record_on = 439,
            d_recttool_on = 440,
            d_recttool = 441,
            d_recttransformblueprint = 442,
            d_recttransformraw = 443,
            d_redgroove = 444,
            d_reflectionprobeselector = 445,
            d_refresh = 446,
            d_rightbracket = 447,
            d_rotatetool_on = 448,
            d_rotatetool = 449,
            d_saveas = 450,
            d_scaletool_on = 451,
            d_scaletool = 452,
            d_scenepicking_notpickable_mixed = 453,
            d_scenepicking_notpickable_mixed_hover = 454,
            d_scenepicking_notpickable = 455,
            d_scenepicking_notpickable_hover = 456,
            d_scenepicking_pickable_mixed = 457,
            d_scenepicking_pickable_mixed_hover = 458,
            d_scenepicking_pickable = 459,
            d_scenepicking_pickable_hover = 460,
            d_sceneview2d_on = 461,
            d_sceneview2d = 462,
            d_sceneviewalpha = 463,
            d_sceneviewaudio_on = 464,
            d_sceneviewaudio = 465,
            d_sceneviewcamera = 466,
            d_sceneviewfx_on = 467,
            d_sceneviewfx = 468,
            d_sceneviewlighting_on = 469,
            d_sceneviewlighting = 470,
            d_sceneviewortho = 471,
            d_sceneviewrgb = 472,
            d_sceneviewtools = 473,
            d_sceneviewvisibility_on = 474,
            d_sceneviewvisibility = 475,
            d_scenevis_hidden_mixed = 476,
            d_scenevis_hidden_mixed_hover = 477,
            d_scenevis_hidden = 478,
            d_scenevis_hidden_hover = 479,
            d_scenevis_scene_hover = 480,
            d_scenevis_visible_mixed = 481,
            d_scenevis_visible_mixed_hover = 482,
            d_scenevis_visible = 483,
            d_scenevis_visible_hover = 484,
            d_scrollshadow = 485,
            d_settings = 486,
            d_settingsicon = 487,
            d_showpanels = 488,
            d_socialnetworks_facebookshare = 489,
            d_socialnetworks_linkedinshare = 490,
            d_socialnetworks_tweet = 491,
            d_socialnetworks_udnopen = 492,
            d_speedscale = 493,
            d_stepbutton_on = 494,
            d_stepbutton = 495,
            d_stepleftbutton_on = 496,
            d_stepleftbutton = 497,
            d_tab_next = 498,
            d_tab_prev = 499,
            d_terraininspector_terraintooladd = 500,
            d_terraininspector_terraintoollower_on = 501,
            d_terraininspector_terraintoolloweralt = 502,
            d_terraininspector_terraintoolplants_on = 503,
            d_terraininspector_terraintoolplants = 504,
            d_terraininspector_terraintoolplantsalt_on = 505,
            d_terraininspector_terraintoolplantsalt = 506,
            d_terraininspector_terraintoolraise_on = 507,
            d_terraininspector_terraintoolraise = 508,
            d_terraininspector_terraintoolsetheight_on = 509,
            d_terraininspector_terraintoolsetheight = 510,
            d_terraininspector_terraintoolsetheightalt_on = 511,
            d_terraininspector_terraintoolsetheightalt = 512,
            d_terraininspector_terraintoolsettings_on = 513,
            d_terraininspector_terraintoolsettings = 514,
            d_terraininspector_terraintoolsmoothheight_on = 515,
            d_terraininspector_terraintoolsmoothheight = 516,
            d_terraininspector_terraintoolsplat_on = 517,
            d_terraininspector_terraintoolsplat = 518,
            d_terraininspector_terraintoolsplatalt_on = 519,
            d_terraininspector_terraintoolsplatalt = 520,
            d_terraininspector_terraintooltrees_on = 521,
            d_terraininspector_terraintooltrees = 522,
            d_terraininspector_terraintooltreesalt_on = 523,
            d_terraininspector_terraintooltreesalt = 524,
            d_toggleuvoverlay = 525,
            d_toolbar_minus = 526,
            d_toolbar_plus_more = 527,
            d_toolbar_plus = 528,
            d_toolhandlecenter = 529,
            d_toolhandleglobal = 530,
            d_toolhandlelocal = 531,
            d_toolhandlepivot = 532,
            d_toolsicon = 533,
            d_tranp = 534,
            d_transformtool_on = 535,
            d_transformtool = 536,
            d_tree_icon = 537,
            d_tree_icon_branch = 538,
            d_tree_icon_branch_frond = 539,
            d_tree_icon_frond = 540,
            d_tree_icon_leaf = 541,
            d_treeeditor_addbranches = 542,
            d_treeeditor_addleaves = 543,
            d_treeeditor_branch_on = 544,
            d_treeeditor_branch = 545,
            d_treeeditor_branchfreehand_on = 546,
            d_treeeditor_branchfreehand = 547,
            d_treeeditor_branchrotate_on = 548,
            d_treeeditor_branchrotate = 549,
            d_treeeditor_branchscale_on = 550,
            d_treeeditor_branchscale = 551,
            d_treeeditor_branchtranslate_on = 552,
            d_treeeditor_branchtranslate = 553,
            d_treeeditor_distribution_on = 554,
            d_treeeditor_distribution = 555,
            d_treeeditor_duplicate = 556,
            d_treeeditor_geometry_on = 557,
            d_treeeditor_geometry = 558,
            d_treeeditor_leaf_on = 559,
            d_treeeditor_leaf = 560,
            d_treeeditor_leaffreehand_on = 561,
            d_treeeditor_leaffreehand = 562,
            d_treeeditor_leafrotate_on = 563,
            d_treeeditor_leafrotate = 564,
            d_treeeditor_leafscale_on = 565,
            d_treeeditor_leafscale = 566,
            d_treeeditor_leaftranslate_on = 567,
            d_treeeditor_leaftranslate = 568,
            d_treeeditor_material_on = 569,
            d_treeeditor_material = 570,
            d_treeeditor_refresh = 571,
            d_treeeditor_trash = 572,
            d_treeeditor_wind_on = 573,
            d_treeeditor_wind = 574,
            d_unityeditor_animationwindow = 575,
            d_unityeditor_consolewindow = 576,
            d_unityeditor_debuginspectorwindow = 577,
            d_unityeditor_devicesimulation_simulatorwindow = 578,
            d_unityeditor_finddependencies = 579,
            d_unityeditor_gameview = 580,
            d_unityeditor_graphs_animatorcontrollertool = 581,
            d_unityeditor_hierarchywindow = 582,
            d_unityeditor_inspectorwindow = 583,
            d_unityeditor_profilerwindow = 584,
            d_unityeditor_scenehierarchywindow = 585,
            d_unityeditor_sceneview = 586,
            d_unityeditor_timeline_timelinewindow = 587,
            d_unityeditor_versioncontrol = 588,
            d_unitylogo = 589,
            d_unlinked = 590,
            d_valid = 591,
            d_verticalsplit = 592,
            d_viewtoolmove_on = 593,
            d_viewtoolmove = 594,
            d_viewtoolorbit_on = 595,
            d_viewtoolorbit = 596,
            d_viewtoolzoom_on = 597,
            d_viewtoolzoom = 598,
            d_visibilityoff = 599,
            d_visibilityon = 600,
            d_vumetertexturehorizontal = 601,
            d_vumetertexturevertical = 602,
            d_waitspin00 = 603,
            d_waitspin01 = 604,
            d_waitspin02 = 605,
            d_waitspin03 = 606,
            d_waitspin04 = 607,
            d_waitspin05 = 608,
            d_waitspin06 = 609,
            d_waitspin07 = 610,
            d_waitspin08 = 611,
            d_waitspin09 = 612,
            d_waitspin10 = 613,
            d_waitspin11 = 614,
            d_welcomescreen_assetstorelogo = 615,
            d_winbtn_graph = 616,
            d_winbtn_graph_close_h = 617,
            d_winbtn_graph_max_h = 618,
            d_winbtn_graph_min_h = 619,
            d_winbtn_mac_close = 620,
            d_winbtn_mac_close_a = 621,
            d_winbtn_mac_close_h = 622,
            d_winbtn_mac_inact = 623,
            d_winbtn_mac_max = 624,
            d_winbtn_mac_max_a = 625,
            d_winbtn_mac_max_h = 626,
            d_winbtn_mac_min = 627,
            d_winbtn_mac_min_a = 628,
            d_winbtn_mac_min_h = 629,
            d_winbtn_win_close = 630,
            d_winbtn_win_close_a = 631,
            d_winbtn_win_close_h = 632,
            d_winbtn_win_max = 633,
            d_winbtn_win_max_a = 634,
            d_winbtn_win_max_h = 635,
            d_winbtn_win_min = 636,
            d_winbtn_win_min_a = 637,
            d_winbtn_win_min_h = 638,
            d_winbtn_win_rest = 639,
            d_winbtn_win_rest_a = 640,
            d_winbtn_win_rest_h = 641,
            d_winbtn_win_restore = 642,
            d_winbtn_win_restore_a = 643,
            d_winbtn_win_restore_h = 644,
            debuggerattached = 645,
            debuggerdisabled = 646,
            debuggerenabled = 647,
            defaultsorting = 648,
            editcollider = 649,
            editcollision_16 = 650,
            editcollision_32 = 651,
            editconstraints_16 = 652,
            editconstraints_32 = 653,
            editicon_sml = 654,
            endbutton_on = 655,
            endbutton = 656,
            exposure = 657,
            eyedropper_large = 658,
            eyedropper_sml = 659,
            favorite = 660,
            filterbylabel = 661,
            filterbytype = 662,
            filterselectedonly = 663,
            forward = 664,
            framecapture_on = 665,
            framecapture = 666,
            gear = 667,
            gizmostoggle_on = 668,
            gizmostoggle = 669,
            grid_boxtool = 670,
            grid_default = 671,
            grid_erasertool = 672,
            grid_filltool = 673,
            grid_movetool = 674,
            grid_painttool = 675,
            grid_pickingtool = 676,
            groove = 677,
            align_horizontally = 678,
            align_horizontally_center = 679,
            align_horizontally_center_active = 680,
            align_horizontally_left = 681,
            align_horizontally_left_active = 682,
            align_horizontally_right = 683,
            align_horizontally_right_active = 684,
            align_vertically = 685,
            align_vertically_bottom = 686,
            align_vertically_bottom_active = 687,
            align_vertically_center = 688,
            align_vertically_center_active = 689,
            align_vertically_top = 690,
            align_vertically_top_active = 691,
            d_align_horizontally = 692,
            d_align_horizontally_center = 693,
            d_align_horizontally_center_active = 694,
            d_align_horizontally_left = 695,
            d_align_horizontally_left_active = 696,
            d_align_horizontally_right = 697,
            d_align_horizontally_right_active = 698,
            d_align_vertically = 699,
            d_align_vertically_bottom = 700,
            d_align_vertically_bottom_active = 701,
            d_align_vertically_center = 702,
            d_align_vertically_center_active = 703,
            d_align_vertically_top = 704,
            d_align_vertically_top_active = 705,
            horizontalsplit = 706,
            icon_dropdown = 707,
            import = 708,
            inspectorlock = 709,
            invalid = 710,
            jointangularlimits = 711,
            knobcshape = 712,
            knobcshapemini = 713,
            leftbracket = 714,
            lighting = 715,
            lightmapeditor_windowtitle = 716,
            lightmapping = 717,
            d_greenlight = 718,
            d_lightoff = 719,
            d_lightrim = 720,
            d_orangelight = 721,
            d_redlight = 722,
            greenlight = 723,
            lightoff = 724,
            lightrim = 725,
            orangelight = 726,
            redlight = 727,
            linked = 728,
            lockicon_on = 729,
            lockicon = 730,
            loop = 731,
            mainstageview = 732,
            mirror = 733,
            monologo = 734,
            moreoptions = 735,
            movetool_on = 736,
            movetool = 737,
            navigation = 738,
            occlusion = 739,
            camerapreview = 740,
            d_camerapreview = 741,
            d_gridandsnap = 742,
            d_orientationgizmo = 743,
            d_searchoverlay = 744,
            d_standardtools = 745,
            d_toolsettings = 746,
            d_toolstoggle = 747,
            d_viewoptions = 748,
            gridandsnap = 749,
            grip_horizontalcontainer = 750,
            grip_verticalcontainer = 751,
            hoverbar_down = 752,
            hoverbar_leftright = 753,
            hoverbar_up = 754,
            locked = 755,
            orientationgizmo = 756,
            searchoverlay = 757,
            standardtools = 758,
            toolsettings = 759,
            toolstoggle = 760,
            unlocked = 761,
            viewoptions = 762,
            package_manager = 763,
            packagebadgedelete = 764,
            packagebadgenew = 765,
            feature_selected = 766,
            feature = 767,
            quickstart = 768,
            add_available = 769,
            custom = 770,
            customized = 771,
            download_available = 772,
            error = 773,
            git = 774,
            import_available = 775,
            info = 776,
            installed = 777,
            link = 778,
            loading = 779,
            refresh = 780,
            update_available = 781,
            warning = 782,
            particle_effect = 783,
            particleshapetool_on = 784,
            particleshapetool = 785,
            pausebutton_on = 786,
            pausebutton = 787,
            playbutton_on = 788,
            playbutton = 789,
            playbuttonprofile_on = 790,
            playbuttonprofile = 791,
            playloopoff = 792,
            playloopon = 793,
            playspeed = 794,
            preaudioautoplayoff = 795,
            preaudioautoplayon = 796,
            preaudioloopoff = 797,
            preaudioloopon = 798,
            preaudioplayoff = 799,
            preaudioplayon = 800,
            prematcube = 801,
            prematcylinder = 802,
            prematlight0 = 803,
            prematlight1 = 804,
            prematquad = 805,
            prematsphere = 806,
            premattorus = 807,
            preset_context = 808,
            pretexa = 809,
            pretexb = 810,
            pretexg = 811,
            pretexr = 812,
            pretexrgb = 813,
            pretexturealpha = 814,
            pretexturearrayfirstslice = 815,
            pretexturearraylastslice = 816,
            pretexturemipmaphigh = 817,
            pretexturemipmaplow = 818,
            pretexturergb = 819,
            previewpackageinuse = 820,
            arealight_gizmo = 821,
            arealight_icon = 822,
            assembly_icon = 823,
            assetstore_icon = 824,
            audiomixerview_icon = 825,
            audiosource_gizmo = 826,
            boo_script_icon = 827,
            camera_gizmo = 828,
            chorusfilter_icon = 829,
            collabchanges_icon = 830,
            collabchangesconflict_icon = 831,
            collabchangesdeleted_icon = 832,
            collabconflict_icon = 833,
            collabcreate_icon = 834,
            collabdeleted_icon = 835,
            collabedit_icon = 836,
            collabexclude_icon = 837,
            collabmoved_icon = 838,
            cs_script_icon = 839,
            d_arealight_icon = 840,
            d_assembly_icon = 841,
            d_assetstore_icon = 842,
            d_audiomixerview_icon = 843,
            d_boo_script_icon = 844,
            d_collabchanges_icon = 845,
            d_collabchangesconflict_icon = 846,
            d_collabchangesdeleted_icon = 847,
            d_collabconflict_icon = 848,
            d_collabcreate_icon = 849,
            d_collabdeleted_icon = 850,
            d_collabedit_icon = 851,
            d_collabexclude_icon = 852,
            d_collabmoved_icon = 853,
            d_cs_script_icon = 854,
            d_directionallight_icon = 855,
            d_favorite_icon = 856,
            d_favorite_on_icon = 857,
            d_folder_icon = 858,
            d_folder_on_icon = 859,
            d_folderempty_icon = 860,
            d_folderempty_on_icon = 861,
            d_folderfavorite_icon = 862,
            d_folderfavorite_on_icon = 863,
            d_folderopened_icon = 864,
            d_gridlayoutgroup_icon = 865,
            d_horizontallayoutgroup_icon = 866,
            d_js_script_icon = 867,
            d_lightingdataassetparent_icon = 868,
            d_microphone_icon = 869,
            d_prefab_icon = 870,
            d_prefab_on_icon = 871,
            d_prefabmodel_icon = 872,
            d_prefabmodel_on_icon = 873,
            d_prefabvariant_icon = 874,
            d_prefabvariant_on_icon = 875,
            d_raycastcollider_icon = 876,
            d_search_icon = 877,
            d_search_on_icon = 878,
            d_searchjump_icon = 879,
            d_settings_icon = 880,
            d_shortcut_icon = 881,
            d_spotlight_icon = 882,
            d_verticallayoutgroup_icon = 883,
            defaultslate_icon = 884,
            directionallight_gizmo = 885,
            directionallight_icon = 886,
            disclight_gizmo = 887,
            disclight_icon = 888,
            dll_script_icon = 889,
            echofilter_icon = 890,
            favorite_icon = 891,
            favorite_on_icon = 892,
            folder_icon = 893,
            folder_on_icon = 894,
            folderempty_icon = 895,
            folderempty_on_icon = 896,
            folderfavorite_icon = 897,
            folderfavorite_on_icon = 898,
            folderopened_icon = 899,
            folderopened_on_icon = 900,
            gamemanager_icon = 901,
            gridbrush_icon = 902,
            highpassfilter_icon = 903,
            horizontallayoutgroup_icon = 904,
            js_script_icon = 905,
            lensflare_gizmo = 906,
            lightingdataassetparent_icon = 907,
            lightprobegroup_gizmo = 908,
            lightprobeproxyvolume_gizmo = 909,
            lowpassfilter_icon = 910,
            main_light_gizmo = 911,
            metafile_icon = 912,
            microphone_icon = 913,
            muscleclip_icon = 914,
            particlesystem_gizmo = 915,
            particlesystemforcefield_gizmo = 916,
            pointlight_gizmo = 917,
            prefab_icon = 918,
            prefab_on_icon = 919,
            prefabmodel_icon = 920,
            prefabmodel_on_icon = 921,
            prefaboverlayadded_icon = 922,
            prefaboverlaymodified_icon = 923,
            prefaboverlayremoved_icon = 924,
            prefabvariant_icon = 925,
            prefabvariant_on_icon = 926,
            projector_gizmo = 927,
            raycastcollider_icon = 928,
            reflectionprobe_gizmo = 929,
            reverbfilter_icon = 930,
            sceneset_icon = 931,
            search_icon = 932,
            search_on_icon = 933,
            searchjump_icon = 934,
            settings_icon = 935,
            shortcut_icon = 936,
            softlockprojectbrowser_icon = 937,
            speedtreemodel_icon = 938,
            spotlight_gizmo = 939,
            spotlight_icon = 940,
            spritecollider_icon = 941,
            sv_icon_dot0_pix16_gizmo = 942,
            sv_icon_dot10_pix16_gizmo = 943,
            sv_icon_dot11_pix16_gizmo = 944,
            sv_icon_dot12_pix16_gizmo = 945,
            sv_icon_dot13_pix16_gizmo = 946,
            sv_icon_dot14_pix16_gizmo = 947,
            sv_icon_dot15_pix16_gizmo = 948,
            sv_icon_dot1_pix16_gizmo = 949,
            sv_icon_dot2_pix16_gizmo = 950,
            sv_icon_dot3_pix16_gizmo = 951,
            sv_icon_dot4_pix16_gizmo = 952,
            sv_icon_dot5_pix16_gizmo = 953,
            sv_icon_dot6_pix16_gizmo = 954,
            sv_icon_dot7_pix16_gizmo = 955,
            sv_icon_dot8_pix16_gizmo = 956,
            sv_icon_dot9_pix16_gizmo = 957,
            animatorcontroller_icon = 958,
            animatorcontroller_on_icon = 959,
            animatorstate_icon = 960,
            animatorstatemachine_icon = 961,
            animatorstatetransition_icon = 962,
            blendtree_icon = 963,
            d_animatorcontroller_icon = 964,
            d_animatorcontroller_on_icon = 965,
            d_animatorstate_icon = 966,
            d_animatorstatemachine_icon = 967,
            d_animatorstatetransition_icon = 968,
            d_blendtree_icon = 969,
            animationwindowevent_icon = 970,
            audiomixercontroller_icon = 971,
            audiomixercontroller_on_icon = 972,
            d_audiomixercontroller_icon = 973,
            d_audiomixercontroller_on_icon = 974,
            audioimporter_icon = 975,
            d_audioimporter_icon = 976,
            d_defaultasset_icon = 977,
            d_filter_icon = 978,
            d_ihvimageformatimporter_icon = 979,
            d_lightingdataasset_icon = 980,
            d_lightmapparameters_icon = 981,
            d_lightmapparameters_on_icon = 982,
            d_modelimporter_icon = 983,
            d_sceneasset_icon = 984,
            d_shaderimporter_icon = 985,
            d_shaderinclude_icon = 986,
            d_textscriptimporter_icon = 987,
            d_textureimporter_icon = 988,
            d_truetypefontimporter_icon = 989,
            defaultasset_icon = 990,
            editorsettings_icon = 991,
            filter_icon = 992,
            anystatenode_icon = 993,
            d_anystatenode_icon = 994,
            humantemplate_icon = 995,
            ihvimageformatimporter_icon = 996,
            lightingdataasset_icon = 997,
            lightmapparameters_icon = 998,
            lightmapparameters_on_icon = 999,
            modelimporter_icon = 1000,
            preset_icon = 1001,
            sceneasset_icon = 1002,
            sceneasset_on_icon = 1003,
            scenetemplateasset_icon = 1004,
            d_searchdatabase_icon = 1005,
            d_searchquery_icon = 1006,
            d_searchqueryasset_icon = 1007,
            searchdatabase_icon = 1008,
            searchquery_icon = 1009,
            searchqueryasset_icon = 1010,
            shaderimporter_icon = 1011,
            shaderinclude_icon = 1012,
            speedtreeimporter_icon = 1013,
            substancearchive_icon = 1014,
            textscriptimporter_icon = 1015,
            textureimporter_icon = 1016,
            truetypefontimporter_icon = 1017,
            d_spriteatlasasset_icon = 1018,
            d_spriteatlasimporter_icon = 1019,
            spriteatlasasset_icon = 1020,
            spriteatlasimporter_icon = 1021,
            d_visualeffectsubgraphblock_icon = 1022,
            d_visualeffectsubgraphoperator_icon = 1023,
            visualeffectsubgraphblock_icon = 1024,
            visualeffectsubgraphoperator_icon = 1025,
            videoclipimporter_icon = 1026,
            assemblydefinitionasset_icon = 1027,
            assemblydefinitionreferenceasset_icon = 1028,
            d_assemblydefinitionasset_icon = 1029,
            d_assemblydefinitionreferenceasset_icon = 1030,
            d_navmeshagent_icon = 1031,
            d_navmeshdata_icon = 1032,
            d_navmeshobstacle_icon = 1033,
            d_offmeshlink_icon = 1034,
            navmeshagent_icon = 1035,
            navmeshdata_icon = 1036,
            navmeshobstacle_icon = 1037,
            offmeshlink_icon = 1038,
            analyticstracker_icon = 1039,
            d_analyticstracker_icon = 1040,
            animation_icon = 1041,
            animationclip_icon = 1042,
            animationclip_on_icon = 1043,
            aimconstraint_icon = 1044,
            d_aimconstraint_icon = 1045,
            d_lookatconstraint_icon = 1046,
            d_parentconstraint_icon = 1047,
            d_positionconstraint_icon = 1048,
            d_rotationconstraint_icon = 1049,
            d_scaleconstraint_icon = 1050,
            lookatconstraint_icon = 1051,
            parentconstraint_icon = 1052,
            positionconstraint_icon = 1053,
            rotationconstraint_icon = 1054,
            scaleconstraint_icon = 1055,
            animator_icon = 1056,
            animatoroverridecontroller_icon = 1057,
            animatoroverridecontroller_on_icon = 1058,
            areaeffector2d_icon = 1059,
            articulationbody_icon = 1060,
            audiomixergroup_icon = 1061,
            audiomixersnapshot_icon = 1062,
            audiospatializermicrosoft_icon = 1063,
            d_audiomixergroup_icon = 1064,
            d_audiomixersnapshot_icon = 1065,
            d_audiospatializermicrosoft_icon = 1066,
            audiochorusfilter_icon = 1067,
            audioclip_icon = 1068,
            audioclip_on_icon = 1069,
            audiodistortionfilter_icon = 1070,
            audioechofilter_icon = 1071,
            audiohighpassfilter_icon = 1072,
            audiolistener_icon = 1073,
            audiolowpassfilter_icon = 1074,
            audioreverbfilter_icon = 1075,
            audioreverbzone_icon = 1076,
            audiosource_icon = 1077,
            avatar_icon = 1078,
            avatarmask_icon = 1079,
            avatarmask_on_icon = 1080,
            billboardasset_icon = 1081,
            billboardrenderer_icon = 1082,
            boxcollider_icon = 1083,
            boxcollider2d_icon = 1084,
            buoyancyeffector2d_icon = 1085,
            camera_icon = 1086,
            canvas_icon = 1087,
            canvasgroup_icon = 1088,
            canvasrenderer_icon = 1089,
            capsulecollider_icon = 1090,
            capsulecollider2d_icon = 1091,
            charactercontroller_icon = 1092,
            characterjoint_icon = 1093,
            circlecollider2d_icon = 1094,
            cloth_icon = 1095,
            compositecollider2d_icon = 1096,
            computeshader_icon = 1097,
            configurablejoint_icon = 1098,
            constantforce_icon = 1099,
            constantforce2d_icon = 1100,
            cubemap_icon = 1101,
            customcollider2d_icon = 1102,
            d_animation_icon = 1103,
            d_animationclip_icon = 1104,
            d_animationclip_on_icon = 1105,
            d_animator_icon = 1106,
            d_animatoroverridecontroller_icon = 1107,
            d_animatoroverridecontroller_on_icon = 1108,
            d_areaeffector2d_icon = 1109,
            d_articulationbody_icon = 1110,
            d_audiochorusfilter_icon = 1111,
            d_audioclip_icon = 1112,
            d_audioclip_on_icon = 1113,
            d_audiodistortionfilter_icon = 1114,
            d_audioechofilter_icon = 1115,
            d_audiohighpassfilter_icon = 1116,
            d_audiolistener_icon = 1117,
            d_audiolowpassfilter_icon = 1118,
            d_audioreverbfilter_icon = 1119,
            d_audioreverbzone_icon = 1120,
            d_audiosource_icon = 1121,
            d_avatar_icon = 1122,
            d_avatarmask_icon = 1123,
            d_avatarmask_on_icon = 1124,
            d_billboardasset_icon = 1125,
            d_billboardrenderer_icon = 1126,
            d_boxcollider_icon = 1127,
            d_boxcollider2d_icon = 1128,
            d_buoyancyeffector2d_icon = 1129,
            d_camera_icon = 1130,
            d_canvas_icon = 1131,
            d_canvasgroup_icon = 1132,
            d_canvasrenderer_icon = 1133,
            d_capsulecollider_icon = 1134,
            d_capsulecollider2d_icon = 1135,
            d_charactercontroller_icon = 1136,
            d_characterjoint_icon = 1137,
            d_circlecollider2d_icon = 1138,
            d_cloth_icon = 1139,
            d_compositecollider2d_icon = 1140,
            d_computeshader_icon = 1141,
            d_configurablejoint_icon = 1142,
            d_constantforce_icon = 1143,
            d_constantforce2d_icon = 1144,
            d_cubemap_icon = 1145,
            d_distancejoint2d_icon = 1146,
            d_edgecollider2d_icon = 1147,
            d_fixedjoint_icon = 1148,
            d_flare_icon = 1149,
            d_flare_on_icon = 1150,
            d_flarelayer_icon = 1151,
            d_font_icon = 1152,
            d_font_on_icon = 1153,
            d_frictionjoint2d_icon = 1154,
            d_gameobject_icon = 1155,
            d_grid_icon = 1156,
            d_guiskin_icon = 1157,
            d_guiskin_on_icon = 1158,
            d_halo_icon = 1159,
            d_hingejoint_icon = 1160,
            d_hingejoint2d_icon = 1161,
            d_light_icon = 1162,
            d_lightingsettings_icon = 1163,
            d_lightprobegroup_icon = 1164,
            d_lightprobeproxyvolume_icon = 1165,
            d_lightprobes_icon = 1166,
            d_linerenderer_icon = 1167,
            d_lodgroup_icon = 1168,
            d_material_icon = 1169,
            d_material_on_icon = 1170,
            d_mesh_icon = 1171,
            d_meshcollider_icon = 1172,
            d_meshfilter_icon = 1173,
            d_meshrenderer_icon = 1174,
            d_motion_icon = 1175,
            d_occlusionarea_icon = 1176,
            d_occlusionportal_icon = 1177,
            d_particlesystem_icon = 1178,
            d_particlesystemforcefield_icon = 1179,
            d_physicmaterial_icon = 1180,
            d_physicmaterial_on_icon = 1181,
            d_physicsmaterial2d_icon = 1182,
            d_physicsmaterial2d_on_icon = 1183,
            d_platformeffector2d_icon = 1184,
            d_pointeffector2d_icon = 1185,
            d_polygoncollider2d_icon = 1186,
            d_proceduralmaterial_icon = 1187,
            d_projector_icon = 1188,
            d_raytracingshader_icon = 1189,
            d_recttransform_icon = 1190,
            d_reflectionprobe_icon = 1191,
            d_relativejoint2d_icon = 1192,
            d_rendertexture_icon = 1193,
            d_rendertexture_on_icon = 1194,
            d_rigidbody_icon = 1195,
            d_rigidbody2d_icon = 1196,
            d_scriptableobject_icon = 1197,
            d_scriptableobject_on_icon = 1198,
            d_shader_icon = 1199,
            d_shadervariantcollection_icon = 1200,
            d_skinnedmeshrenderer_icon = 1201,
            d_skybox_icon = 1202,
            d_sliderjoint2d_icon = 1203,
            d_spherecollider_icon = 1204,
            d_springjoint_icon = 1205,
            d_springjoint2d_icon = 1206,
            d_sprite_icon = 1207,
            d_spritemask_icon = 1208,
            d_spriterenderer_icon = 1209,
            d_streamingcontroller_icon = 1210,
            d_surfaceeffector2d_icon = 1211,
            d_targetjoint2d_icon = 1212,
            d_terrain_icon = 1213,
            d_terraincollider_icon = 1214,
            d_terraindata_icon = 1215,
            d_textasset_icon = 1216,
            d_texture_icon = 1217,
            d_texture2d_icon = 1218,
            d_trailrenderer_icon = 1219,
            d_transform_icon = 1220,
            d_wheelcollider_icon = 1221,
            d_wheeljoint2d_icon = 1222,
            d_windzone_icon = 1223,
            distancejoint2d_icon = 1224,
            edgecollider2d_icon = 1225,
            d_eventsystem_icon = 1226,
            d_eventtrigger_icon = 1227,
            d_hololensinputmodule_icon = 1228,
            d_physics2draycaster_icon = 1229,
            d_physicsraycaster_icon = 1230,
            d_standaloneinputmodule_icon = 1231,
            d_touchinputmodule_icon = 1232,
            eventsystem_icon = 1233,
            eventtrigger_icon = 1234,
            hololensinputmodule_icon = 1235,
            physics2draycaster_icon = 1236,
            physicsraycaster_icon = 1237,
            standaloneinputmodule_icon = 1238,
            touchinputmodule_icon = 1239,
            raytracingshader_icon = 1240,
            fixedjoint_icon = 1241,
            fixedjoint2d_icon = 1242,
            flare_icon = 1243,
            flare_on_icon = 1244,
            flarelayer_icon = 1245,
            font_icon = 1246,
            font_on_icon = 1247,
            frictionjoint2d_icon = 1248,
            gameobject_icon = 1249,
            gameobject_on_icon = 1250,
            grid_icon = 1251,
            guilayer_icon = 1252,
            guiskin_icon = 1253,
            guiskin_on_icon = 1254,
            guitext_icon = 1255,
            guitexture_icon = 1256,
            halo_icon = 1257,
            hingejoint_icon = 1258,
            hingejoint2d_icon = 1259,
            lensflare_icon = 1260,
            light_icon = 1261,
            lightingsettings_icon = 1262,
            lightprobegroup_icon = 1263,
            lightprobeproxyvolume_icon = 1264,
            lightprobes_icon = 1265,
            linerenderer_icon = 1266,
            lodgroup_icon = 1267,
            material_icon = 1268,
            material_on_icon = 1269,
            mesh_icon = 1270,
            meshcollider_icon = 1271,
            meshfilter_icon = 1272,
            meshrenderer_icon = 1273,
            motion_icon = 1274,
            movietexture_icon = 1275,
            d_networkanimator_icon = 1276,
            d_networkdiscovery_icon = 1277,
            d_networkidentity_icon = 1278,
            d_networklobbymanager_icon = 1279,
            d_networklobbyplayer_icon = 1280,
            d_networkmanager_icon = 1281,
            d_networkmanagerhud_icon = 1282,
            d_networkmigrationmanager_icon = 1283,
            d_networkproximitychecker_icon = 1284,
            d_networkstartposition_icon = 1285,
            d_networktransform_icon = 1286,
            d_networktransformchild_icon = 1287,
            d_networktransformvisualizer_icon = 1288,
            networkanimator_icon = 1289,
            networkdiscovery_icon = 1290,
            networkidentity_icon = 1291,
            networklobbymanager_icon = 1292,
            networklobbyplayer_icon = 1293,
            networkmanager_icon = 1294,
            networkmanagerhud_icon = 1295,
            networkmigrationmanager_icon = 1296,
            networkproximitychecker_icon = 1297,
            networkstartposition_icon = 1298,
            networktransform_icon = 1299,
            networktransformchild_icon = 1300,
            networktransformvisualizer_icon = 1301,
            networkview_icon = 1302,
            occlusionarea_icon = 1303,
            occlusionportal_icon = 1304,
            particlesystem_icon = 1305,
            particlesystemforcefield_icon = 1306,
            physicmaterial_icon = 1307,
            physicmaterial_on_icon = 1308,
            physicsmaterial2d_icon = 1309,
            physicsmaterial2d_on_icon = 1310,
            platformeffector2d_icon = 1311,
            d_playabledirector_icon = 1312,
            playabledirector_icon = 1313,
            pointeffector2d_icon = 1314,
            polygoncollider2d_icon = 1315,
            proceduralmaterial_icon = 1316,
            projector_icon = 1317,
            recttransform_icon = 1318,
            reflectionprobe_icon = 1319,
            relativejoint2d_icon = 1320,
            d_sortinggroup_icon = 1321,
            sortinggroup_icon = 1322,
            rendertexture_icon = 1323,
            rendertexture_on_icon = 1324,
            rigidbody_icon = 1325,
            rigidbody2d_icon = 1326,
            scriptableobject_icon = 1327,
            scriptableobject_on_icon = 1328,
            shader_icon = 1329,
            shadervariantcollection_icon = 1330,
            skinnedmeshrenderer_icon = 1331,
            skybox_icon = 1332,
            sliderjoint2d_icon = 1333,
            trackedposedriver_icon = 1334,
            spherecollider_icon = 1335,
            springjoint_icon = 1336,
            springjoint2d_icon = 1337,
            sprite_icon = 1338,
            spritemask_icon = 1339,
            spriterenderer_icon = 1340,
            streamingcontroller_icon = 1341,
            surfaceeffector2d_icon = 1342,
            targetjoint2d_icon = 1343,
            terrain_icon = 1344,
            terraincollider_icon = 1345,
            terraindata_icon = 1346,
            textasset_icon = 1347,
            textmesh_icon = 1348,
            texture_icon = 1349,
            texture2d_icon = 1350,
            d_tile_icon = 1351,
            d_tilemap_icon = 1352,
            d_tilemapcollider2d_icon = 1353,
            d_tilemaprenderer_icon = 1354,
            tile_icon = 1355,
            tilemap_icon = 1356,
            tilemapcollider2d_icon = 1357,
            tilemaprenderer_icon = 1358,
            d_signalasset_icon = 1359,
            d_signalemitter_icon = 1360,
            d_signalreceiver_icon = 1361,
            d_timelineasset_icon = 1362,
            d_timelineasset_on_icon = 1363,
            signalasset_icon = 1364,
            signalemitter_icon = 1365,
            signalreceiver_icon = 1366,
            timelineasset_icon = 1367,
            timelineasset_on_icon = 1368,
            trailrenderer_icon = 1369,
            transform_icon = 1370,
            tree_icon = 1371,
            d_spriteatlas_icon = 1372,
            d_spriteatlas_on_icon = 1373,
            d_spriteshaperenderer_icon = 1374,
            spriteatlas_icon = 1375,
            spriteatlas_on_icon = 1376,
            spriteshaperenderer_icon = 1377,
            aspectratiofitter_icon = 1378,
            button_icon = 1379,
            canvasscaler_icon = 1380,
            contentsizefitter_icon = 1381,
            d_aspectratiofitter_icon = 1382,
            d_button_icon = 1383,
            d_canvasscaler_icon = 1384,
            d_contentsizefitter_icon = 1385,
            d_dropdown_icon = 1386,
            d_freeformlayoutgroup_icon = 1387,
            d_graphicraycaster_icon = 1388,
            d_image_icon = 1389,
            d_inputfield_icon = 1390,
            d_layoutelement_icon = 1391,
            d_mask_icon = 1392,
            d_outline_icon = 1393,
            d_physicalresolution_icon = 1394,
            d_positionasuv1_icon = 1395,
            d_rawimage_icon = 1396,
            d_rectmask2d_icon = 1397,
            d_scrollbar_icon = 1398,
            d_scrollrect_icon = 1399,
            d_scrollviewarea_icon = 1400,
            d_selectable_icon = 1401,
            d_selectionlist_icon = 1402,
            d_selectionlistitem_icon = 1403,
            d_selectionlisttemplate_icon = 1404,
            d_shadow_icon = 1405,
            d_slider_icon = 1406,
            d_text_icon = 1407,
            d_toggle_icon = 1408,
            d_togglegroup_icon = 1409,
            dropdown_icon = 1410,
            freeformlayoutgroup_icon = 1411,
            graphicraycaster_icon = 1412,
            gridlayoutgroup_icon = 1413,
            image_icon = 1414,
            inputfield_icon = 1415,
            layoutelement_icon = 1416,
            mask_icon = 1417,
            outline_icon = 1418,
            positionasuv1_icon = 1419,
            rawimage_icon = 1420,
            rectmask2d_icon = 1421,
            scrollbar_icon = 1422,
            scrollrect_icon = 1423,
            selectable_icon = 1424,
            shadow_icon = 1425,
            slider_icon = 1426,
            text_icon = 1427,
            toggle_icon = 1428,
            togglegroup_icon = 1429,
            verticallayoutgroup_icon = 1430,
            d_panelsettings_icon = 1431,
            d_panelsettings_on_icon = 1432,
            d_stylesheet_icon = 1433,
            d_uidocument_icon = 1434,
            d_visualtreeasset_icon = 1435,
            panelsettings_icon = 1436,
            panelsettings_on_icon = 1437,
            stylesheet_icon = 1438,
            uidocument_icon = 1439,
            visualtreeasset_icon = 1440,
            d_visualeffect_icon = 1441,
            d_visualeffectasset_icon = 1442,
            visualeffect_icon = 1443,
            visualeffectasset_icon = 1444,
            d_videoplayer_icon = 1445,
            videoclip_icon = 1446,
            videoplayer_icon = 1447,
            wheelcollider_icon = 1448,
            wheeljoint2d_icon = 1449,
            windzone_icon = 1450,
            d_spatialmappingcollider_icon = 1451,
            spatialmappingcollider_icon = 1452,
            spatialmappingrenderer_icon = 1453,
            worldanchor_icon = 1454,
            ussscript_icon = 1455,
            uxmlscript_icon = 1456,
            videoeffect_icon = 1457,
            visualeffect_gizmo = 1458,
            windzone_gizmo = 1459,
            profiler_audio = 1460,
            profiler_cpu = 1461,
            profiler_custom = 1462,
            profiler_firstframe = 1463,
            profiler_globalillumination = 1464,
            profiler_gpu = 1465,
            profiler_instrumentation = 1466,
            profiler_lastframe = 1467,
            profiler_memory = 1468,
            profiler_networkmessages = 1469,
            profiler_networkoperations = 1470,
            profiler_nextframe = 1471,
            profiler_open = 1472,
            profiler_physics = 1473,
            profiler_physics2d = 1474,
            profiler_prevframe = 1475,
            profiler_record = 1476,
            profiler_rendering = 1477,
            profiler_ui = 1478,
            profiler_uidetails = 1479,
            profiler_video = 1480,
            profiler_virtualtexturing = 1481,
            profilercolumn_warningcount = 1482,
            progress = 1483,
            project = 1484,
            d_dragarrow = 1485,
            d_gridview_on = 1486,
            d_gridview = 1487,
            d_help = 1488,
            d_listview_on = 1489,
            d_listview = 1490,
            d_more = 1491,
            d_searchwindow = 1492,
            d_syncsearch_on = 1493,
            d_syncsearch = 1494,
            d_tableview_on = 1495,
            d_tableview = 1496,
            dragarrow = 1497,
            gridview_on = 1498,
            gridview = 1499,
            help = 1500,
            listview_on = 1501,
            listview = 1502,
            more = 1503,
            package_installed = 1504,
            package_update = 1505,
            searchwindow = 1506,
            syncsearch_on = 1507,
            syncsearch = 1508,
            tableview_on = 1509,
            tableview = 1510,
            record_off = 1511,
            record_on = 1512,
            recttool_on = 1513,
            recttool = 1514,
            recttransformblueprint = 1515,
            recttransformraw = 1516,
            redgroove = 1517,
            reflectionprobeselector = 1518,
            repaintdot = 1519,
            rightbracket = 1520,
            rotatetool_on = 1521,
            rotatetool = 1522,
            saveactive = 1523,
            saveas = 1524,
            savefromplay = 1525,
            savepassive = 1526,
            scaletool_on = 1527,
            scaletool = 1528,
            sceneloadin = 1529,
            sceneloadout = 1530,
            scenepicking_notpickable_mixed = 1531,
            scenepicking_notpickable_mixed_hover = 1532,
            scenepicking_notpickable = 1533,
            scenepicking_notpickable_hover = 1534,
            scenepicking_pickable_mixed = 1535,
            scenepicking_pickable_mixed_hover = 1536,
            scenepicking_pickable = 1537,
            scenepicking_pickable_hover = 1538,
            scenesave = 1539,
            scenesavegrey = 1540,
            pin = 1541,
            pinned = 1542,
            scene_template_2d_scene = 1543,
            scene_template_3d_scene = 1544,
            scene_template_dark = 1545,
            scene_template_default_scene = 1546,
            scene_template_empty_scene = 1547,
            scene_template_light = 1548,
            scene_template = 1549,
            sceneview2d_on = 1550,
            sceneview2d = 1551,
            sceneviewalpha = 1552,
            sceneviewaudio_on = 1553,
            sceneviewaudio = 1554,
            sceneviewcamera_on = 1555,
            sceneviewcamera = 1556,
            sceneviewfx_on = 1557,
            sceneviewfx = 1558,
            sceneviewlighting_on = 1559,
            sceneviewlighting = 1560,
            sceneviewortho = 1561,
            sceneviewrgb = 1562,
            sceneviewtools_on = 1563,
            sceneviewtools = 1564,
            sceneviewvisibility_on = 1565,
            sceneviewvisibility = 1566,
            scenevis_hidden_mixed = 1567,
            scenevis_hidden_mixed_hover = 1568,
            scenevis_hidden = 1569,
            scenevis_hidden_hover = 1570,
            scenevis_scene_hover = 1571,
            scenevis_visible_mixed = 1572,
            scenevis_visible_mixed_hover = 1573,
            scenevis_visible = 1574,
            scenevis_visible_hover = 1575,
            scrollshadow = 1576,
            settings = 1577,
            settingsicon = 1578,
            alertdialog = 1579,
            conflict_icon = 1580,
            showpanels = 1581,
            d_gridaxisx_on = 1582,
            d_gridaxisx = 1583,
            d_gridaxisy_on = 1584,
            d_gridaxisy = 1585,
            d_gridaxisz_on = 1586,
            d_gridaxisz = 1587,
            d_sceneviewsnap_on = 1588,
            d_sceneviewsnap = 1589,
            d_snapincrement = 1590,
            gridaxisx_on = 1591,
            gridaxisx = 1592,
            gridaxisy_on = 1593,
            gridaxisy = 1594,
            gridaxisz_on = 1595,
            gridaxisz = 1596,
            sceneviewsnap_on = 1597,
            sceneviewsnap = 1598,
            snapincrement = 1599,
            socialnetworks_facebookshare = 1600,
            socialnetworks_linkedinshare = 1601,
            socialnetworks_tweet = 1602,
            socialnetworks_udnlogo = 1603,
            socialnetworks_udnopen = 1604,
            softlockinline = 1605,
            speedscale = 1606,
            statemachineeditor_arrowtip = 1607,
            statemachineeditor_arrowtipselected = 1608,
            statemachineeditor_background = 1609,
            statemachineeditor_state = 1610,
            statemachineeditor_statehover = 1611,
            statemachineeditor_stateselected = 1612,
            statemachineeditor_statesub = 1613,
            statemachineeditor_statesubhover = 1614,
            statemachineeditor_statesubselected = 1615,
            statemachineeditor_upbutton = 1616,
            statemachineeditor_upbuttonhover = 1617,
            stepbutton_on = 1618,
            stepbutton = 1619,
            stepleftbutton_on = 1620,
            stepleftbutton = 1621,
            sv_icon_dot0_sml = 1622,
            sv_icon_dot10_sml = 1623,
            sv_icon_dot11_sml = 1624,
            sv_icon_dot12_sml = 1625,
            sv_icon_dot13_sml = 1626,
            sv_icon_dot14_sml = 1627,
            sv_icon_dot15_sml = 1628,
            sv_icon_dot1_sml = 1629,
            sv_icon_dot2_sml = 1630,
            sv_icon_dot3_sml = 1631,
            sv_icon_dot4_sml = 1632,
            sv_icon_dot5_sml = 1633,
            sv_icon_dot6_sml = 1634,
            sv_icon_dot7_sml = 1635,
            sv_icon_dot8_sml = 1636,
            sv_icon_dot9_sml = 1637,
            sv_icon_name0 = 1638,
            sv_icon_name1 = 1639,
            sv_icon_name2 = 1640,
            sv_icon_name3 = 1641,
            sv_icon_name4 = 1642,
            sv_icon_name5 = 1643,
            sv_icon_name6 = 1644,
            sv_icon_name7 = 1645,
            sv_icon_none = 1646,
            sv_label_0 = 1647,
            sv_label_1 = 1648,
            sv_label_2 = 1649,
            sv_label_3 = 1650,
            sv_label_4 = 1651,
            sv_label_5 = 1652,
            sv_label_6 = 1653,
            sv_label_7 = 1654,
            tab_next = 1655,
            tab_prev = 1656,
            tabtofilter = 1657,
            terraininspector_terraintooladd = 1658,
            terraininspector_terraintoollower_on = 1659,
            terraininspector_terraintoollower = 1660,
            terraininspector_terraintoolloweralt = 1661,
            terraininspector_terraintoolplants_on = 1662,
            terraininspector_terraintoolplants = 1663,
            terraininspector_terraintoolplantsalt_on = 1664,
            terraininspector_terraintoolplantsalt = 1665,
            terraininspector_terraintoolraise_on = 1666,
            terraininspector_terraintoolraise = 1667,
            terraininspector_terraintoolsculpt_on = 1668,
            terraininspector_terraintoolsculpt = 1669,
            terraininspector_terraintoolsetheight_on = 1670,
            terraininspector_terraintoolsetheight = 1671,
            terraininspector_terraintoolsetheightalt_on = 1672,
            terraininspector_terraintoolsetheightalt = 1673,
            terraininspector_terraintoolsettings_on = 1674,
            terraininspector_terraintoolsettings = 1675,
            terraininspector_terraintoolsmoothheight_on = 1676,
            terraininspector_terraintoolsmoothheight = 1677,
            terraininspector_terraintoolsplat_on = 1678,
            terraininspector_terraintoolsplat = 1679,
            terraininspector_terraintoolsplatalt_on = 1680,
            terraininspector_terraintoolsplatalt = 1681,
            terraininspector_terraintooltrees_on = 1682,
            terraininspector_terraintooltrees = 1683,
            terraininspector_terraintooltreesalt_on = 1684,
            terraininspector_terraintooltreesalt = 1685,
            testfailed = 1686,
            testignored = 1687,
            testinconclusive = 1688,
            testnormal = 1689,
            testpassed = 1690,
            teststopwatch = 1691,
            toggleuvoverlay = 1692,
            toolbar_minus = 1693,
            toolbar_plus_more = 1694,
            toolbar_plus = 1695,
            d_debug = 1696,
            d_objectmode = 1697,
            d_sceneviewtools_on = 1698,
            d_shaded = 1699,
            d_shadedwireframe = 1700,
            d_wireframe = 1701,
            debug_on = 1702,
            debug = 1703,
            objectmode = 1704,
            shaded = 1705,
            shadedwireframe = 1706,
            wireframe = 1707,
            toolhandlecenter = 1708,
            toolhandleglobal = 1709,
            toolhandlelocal = 1710,
            toolhandlepivot = 1711,
            toolsicon = 1712,
            tranp = 1713,
            transformtool_on = 1714,
            transformtool = 1715,
            tree_icon_branch = 1716,
            tree_icon_branch_frond = 1717,
            tree_icon_frond = 1718,
            tree_icon_leaf = 1719,
            treeeditor_addbranches = 1720,
            treeeditor_addleaves = 1721,
            treeeditor_branch_on = 1722,
            treeeditor_branch = 1723,
            treeeditor_branchfreehand_on = 1724,
            treeeditor_branchfreehand = 1725,
            treeeditor_branchrotate_on = 1726,
            treeeditor_branchrotate = 1727,
            treeeditor_branchscale_on = 1728,
            treeeditor_branchscale = 1729,
            treeeditor_branchtranslate_on = 1730,
            treeeditor_branchtranslate = 1731,
            treeeditor_distribution_on = 1732,
            treeeditor_distribution = 1733,
            treeeditor_duplicate = 1734,
            treeeditor_geometry_on = 1735,
            treeeditor_geometry = 1736,
            treeeditor_leaf_on = 1737,
            treeeditor_leaf = 1738,
            treeeditor_leaffreehand_on = 1739,
            treeeditor_leaffreehand = 1740,
            treeeditor_leafrotate_on = 1741,
            treeeditor_leafrotate = 1742,
            treeeditor_leafscale_on = 1743,
            treeeditor_leafscale = 1744,
            treeeditor_leaftranslate_on = 1745,
            treeeditor_leaftranslate = 1746,
            treeeditor_material_on = 1747,
            treeeditor_material = 1748,
            treeeditor_refresh = 1749,
            treeeditor_trash = 1750,
            treeeditor_wind_on = 1751,
            treeeditor_wind = 1752,
            unityeditor_animationwindow = 1753,
            unityeditor_consolewindow = 1754,
            unityeditor_debuginspectorwindow = 1755,
            unityeditor_devicesimulation_simulatorwindow = 1756,
            unityeditor_finddependencies = 1757,
            unityeditor_gameview = 1758,
            unityeditor_graphs_animatorcontrollertool = 1759,
            unityeditor_hierarchywindow = 1760,
            unityeditor_inspectorwindow = 1761,
            unityeditor_profilerwindow = 1762,
            unityeditor_scenehierarchywindow = 1763,
            unityeditor_sceneview = 1764,
            unityeditor_timeline_timelinewindow = 1765,
            unityeditor_versioncontrol = 1766,
            unitylogo = 1767,
            unitylogolarge = 1768,
            unlinked = 1769,
            uparrow = 1770,
            valid = 1771,
            d_file = 1772,
            d_incoming_icon = 1773,
            d_p4_addedlocal = 1774,
            d_p4_addedremote = 1775,
            d_p4_blueleftparenthesis = 1776,
            d_p4_bluerightparenthesis = 1777,
            d_p4_checkoutlocal = 1778,
            d_p4_checkoutremote = 1779,
            d_p4_conflicted = 1780,
            d_p4_deletedlocal = 1781,
            d_p4_deletedremote = 1782,
            d_p4_local = 1783,
            d_p4_lockedlocal = 1784,
            d_p4_lockedremote = 1785,
            d_p4_offline = 1786,
            d_p4_outofsync = 1787,
            d_p4_redleftparenthesis = 1788,
            d_p4_redrightparenthesis = 1789,
            d_p4_updating = 1790,
            file = 1791,
            incoming_icon = 1792,
            incoming_on_icon = 1793,
            outgoing_icon = 1794,
            p4_addedlocal = 1795,
            p4_addedremote = 1796,
            p4_blueleftparenthesis = 1797,
            p4_bluerightparenthesis = 1798,
            p4_checkoutlocal = 1799,
            p4_checkoutremote = 1800,
            p4_conflicted = 1801,
            p4_deletedlocal = 1802,
            p4_deletedremote = 1803,
            p4_local = 1804,
            p4_lockedlocal = 1805,
            p4_lockedremote = 1806,
            p4_offline = 1807,
            p4_outofsync = 1808,
            p4_redleftparenthesis = 1809,
            p4_redrightparenthesis = 1810,
            p4_updating = 1811,
            verticalsplit = 1812,
            viewtoolmove_on = 1813,
            viewtoolmove = 1814,
            viewtoolorbit_on = 1815,
            viewtoolorbit = 1816,
            viewtoolzoom_on = 1817,
            viewtoolzoom = 1818,
            visibilityoff = 1819,
            visibilityon = 1820,
            vumetertexturehorizontal = 1821,
            vumetertexturevertical = 1822,
            waitspin00 = 1823,
            waitspin01 = 1824,
            waitspin02 = 1825,
            waitspin03 = 1826,
            waitspin04 = 1827,
            waitspin05 = 1828,
            waitspin06 = 1829,
            waitspin07 = 1830,
            waitspin08 = 1831,
            waitspin09 = 1832,
            waitspin10 = 1833,
            waitspin11 = 1834,
            welcomescreen_assetstorelogo = 1835,
            winbtn_graph = 1836,
            winbtn_graph_close_h = 1837,
            winbtn_graph_max_h = 1838,
            winbtn_graph_min_h = 1839,
            winbtn_mac_close = 1840,
            winbtn_mac_close_a = 1841,
            winbtn_mac_close_h = 1842,
            winbtn_mac_inact = 1843,
            winbtn_mac_max = 1844,
            winbtn_mac_max_a = 1845,
            winbtn_mac_max_h = 1846,
            winbtn_mac_min = 1847,
            winbtn_mac_min_a = 1848,
            winbtn_mac_min_h = 1849,
            winbtn_win_close = 1850,
            winbtn_win_close_a = 1851,
            winbtn_win_close_h = 1852,
            winbtn_win_max = 1853,
            winbtn_win_max_a = 1854,
            winbtn_win_max_h = 1855,
            winbtn_win_min = 1856,
            winbtn_win_min_a = 1857,
            winbtn_win_min_h = 1858,
            winbtn_win_rest = 1859,
            winbtn_win_rest_a = 1860,
            winbtn_win_rest_h = 1861,
            winbtn_win_restore = 1862,
            winbtn_win_restore_a = 1863,
            winbtn_win_restore_h = 1864,

        }

#endregion

#region Constants

        public const string _help = "_help";
        public const string _menu = "_menu";
        public const string _popup = "_popup";
        public const string aboutwindow_mainheader = "aboutwindow.mainheader";
        public const string ageialogo = "ageialogo";
        public const string alphabeticalsorting = "alphabeticalsorting";
        public const string anchortransformtool_on = "anchortransformtool on";
        public const string anchortransformtool = "anchortransformtool";
        public const string animation_addevent = "animation.addevent";
        public const string animation_addkeyframe = "animation.addkeyframe";
        public const string animation_eventmarker = "animation.eventmarker";
        public const string animation_filterbyselection = "animation.filterbyselection";
        public const string animation_firstkey = "animation.firstkey";
        public const string animation_lastkey = "animation.lastkey";
        public const string animation_nextkey = "animation.nextkey";
        public const string animation_play = "animation.play";
        public const string animation_prevkey = "animation.prevkey";
        public const string animation_record = "animation.record";
        public const string animation_sequencerlink = "animation.sequencerlink";
        public const string animationanimated = "animationanimated";
        public const string animationdopesheetkeyframe = "animationdopesheetkeyframe";
        public const string animationkeyframe = "animationkeyframe";
        public const string animationnocurve = "animationnocurve";
        public const string animationvisibilitytoggleoff = "animationvisibilitytoggleoff";
        public const string animationvisibilitytoggleon = "animationvisibilitytoggleon";
        public const string animationwrapmodemenu = "animationwrapmodemenu";
        public const string assemblylock = "assemblylock";
        public const string asset_store = "asset store";
        public const string unity_assetstore_originals_logo_white = "unity-assetstore-originals-logo-white";
        public const string audio_mixer = "audio mixer";
        public const string autolightbakingoff = "autolightbakingoff";
        public const string autolightbakingon = "autolightbakingon";
        public const string avatarcompass = "avatarcompass";
        public const string avatarcontroller_layer = "avatarcontroller.layer";
        public const string avatarcontroller_layerhover = "avatarcontroller.layerhover";
        public const string avatarcontroller_layerselected = "avatarcontroller.layerselected";
        public const string bodypartpicker = "bodypartpicker";
        public const string bodysilhouette = "bodysilhouette";
        public const string dotfill = "dotfill";
        public const string dotframe = "dotframe";
        public const string dotframedotted = "dotframedotted";
        public const string dotselection = "dotselection";
        public const string head = "head";
        public const string headik = "headik";
        public const string headzoom = "headzoom";
        public const string headzoomsilhouette = "headzoomsilhouette";
        public const string leftarm = "leftarm";
        public const string leftfeetik = "leftfeetik";
        public const string leftfingers = "leftfingers";
        public const string leftfingersik = "leftfingersik";
        public const string lefthandzoom = "lefthandzoom";
        public const string lefthandzoomsilhouette = "lefthandzoomsilhouette";
        public const string leftleg = "leftleg";
        public const string maskeditor_root = "maskeditor_root";
        public const string rightarm = "rightarm";
        public const string rightfeetik = "rightfeetik";
        public const string rightfingers = "rightfingers";
        public const string rightfingersik = "rightfingersik";
        public const string righthandzoom = "righthandzoom";
        public const string righthandzoomsilhouette = "righthandzoomsilhouette";
        public const string rightleg = "rightleg";
        public const string torso = "torso";
        public const string avatarpivot = "avatarpivot";
        public const string avatarselector = "avatarselector";
        public const string back = "back";
        public const string beginbutton_on = "beginbutton-on";
        public const string beginbutton = "beginbutton";
        public const string blendkey = "blendkey";
        public const string blendkeyoverlay = "blendkeyoverlay";
        public const string blendkeyselected = "blendkeyselected";
        public const string blendsampler = "blendsampler";
        public const string bluegroove = "bluegroove";
        public const string buildsettings_android_on = "buildsettings.android on";
        public const string buildsettings_android = "buildsettings.android";
        public const string buildsettings_android_small = "buildsettings.android.small";
        public const string buildsettings_broadcom = "buildsettings.broadcom";
        public const string buildsettings_editor = "buildsettings.editor";
        public const string buildsettings_editor_small = "buildsettings.editor.small";
        public const string buildsettings_embeddedlinux_on = "buildsettings.embeddedlinux on";
        public const string buildsettings_embeddedlinux = "buildsettings.embeddedlinux";
        public const string buildsettings_embeddedlinux_small = "buildsettings.embeddedlinux.small";
        public const string buildsettings_facebook_on = "buildsettings.facebook on";
        public const string buildsettings_facebook = "buildsettings.facebook";
        public const string buildsettings_facebook_small = "buildsettings.facebook.small";
        public const string buildsettings_flashplayer = "buildsettings.flashplayer";
        public const string buildsettings_flashplayer_small = "buildsettings.flashplayer.small";
        public const string buildsettings_gamecorescarlett_on = "buildsettings.gamecorescarlett on";
        public const string buildsettings_gamecorescarlett = "buildsettings.gamecorescarlett";
        public const string buildsettings_gamecorescarlett_small = "buildsettings.gamecorescarlett.small";
        public const string buildsettings_gamecorexboxone_on = "buildsettings.gamecorexboxone on";
        public const string buildsettings_gamecorexboxone = "buildsettings.gamecorexboxone";
        public const string buildsettings_gamecorexboxone_small = "buildsettings.gamecorexboxone.small";
        public const string buildsettings_iphone_on = "buildsettings.iphone on";
        public const string buildsettings_iphone = "buildsettings.iphone";
        public const string buildsettings_iphone_small = "buildsettings.iphone.small";
        public const string buildsettings_lumin_on = "buildsettings.lumin on";
        public const string buildsettings_lumin = "buildsettings.lumin";
        public const string buildsettings_lumin_small = "buildsettings.lumin.small";
        public const string buildsettings_metro_on = "buildsettings.metro on";
        public const string buildsettings_metro = "buildsettings.metro";
        public const string buildsettings_metro_small = "buildsettings.metro.small";
        public const string buildsettings_n3ds_on = "buildsettings.n3ds on";
        public const string buildsettings_n3ds = "buildsettings.n3ds";
        public const string buildsettings_n3ds_small = "buildsettings.n3ds.small";
        public const string buildsettings_ps4_on = "buildsettings.ps4 on";
        public const string buildsettings_ps4 = "buildsettings.ps4";
        public const string buildsettings_ps4_small = "buildsettings.ps4.small";
        public const string buildsettings_ps5_on = "buildsettings.ps5 on";
        public const string buildsettings_ps5 = "buildsettings.ps5";
        public const string buildsettings_ps5_small = "buildsettings.ps5.small";
        public const string buildsettings_psm = "buildsettings.psm";
        public const string buildsettings_psm_small = "buildsettings.psm.small";
        public const string buildsettings_psp2 = "buildsettings.psp2";
        public const string buildsettings_psp2_small = "buildsettings.psp2.small";
        public const string buildsettings_selectedicon = "buildsettings.selectedicon";
        public const string buildsettings_stadia_on = "buildsettings.stadia on";
        public const string buildsettings_stadia = "buildsettings.stadia";
        public const string buildsettings_stadia_small = "buildsettings.stadia.small";
        public const string buildsettings_standalone_on = "buildsettings.standalone on";
        public const string buildsettings_standalone = "buildsettings.standalone";
        public const string buildsettings_standalone_small = "buildsettings.standalone.small";
        public const string buildsettings_standalonebroadcom_small = "buildsettings.standalonebroadcom.small";
        public const string buildsettings_standalonegles20emu_small = "buildsettings.standalonegles20emu.small";
        public const string buildsettings_standaloneglesemu = "buildsettings.standaloneglesemu";
        public const string buildsettings_standaloneglesemu_small = "buildsettings.standaloneglesemu.small";
        public const string buildsettings_switch_on = "buildsettings.switch on";
        public const string buildsettings_switch = "buildsettings.switch";
        public const string buildsettings_switch_small = "buildsettings.switch.small";
        public const string buildsettings_tvos_on = "buildsettings.tvos on";
        public const string buildsettings_tvos = "buildsettings.tvos";
        public const string buildsettings_tvos_small = "buildsettings.tvos.small";
        public const string buildsettings_web = "buildsettings.web";
        public const string buildsettings_web_small = "buildsettings.web.small";
        public const string buildsettings_webgl_on = "buildsettings.webgl on";
        public const string buildsettings_webgl = "buildsettings.webgl";
        public const string buildsettings_webgl_small = "buildsettings.webgl.small";
        public const string buildsettings_wp8 = "buildsettings.wp8";
        public const string buildsettings_wp8_small = "buildsettings.wp8.small";
        public const string buildsettings_xbox360 = "buildsettings.xbox360";
        public const string buildsettings_xbox360_small = "buildsettings.xbox360.small";
        public const string buildsettings_xboxone_on = "buildsettings.xboxone on";
        public const string buildsettings_xboxone = "buildsettings.xboxone";
        public const string buildsettings_xboxone_small = "buildsettings.xboxone.small";
        public const string cacheserverconnected = "cacheserverconnected";
        public const string cacheserverdisabled = "cacheserverdisabled";
        public const string cacheserverdisconnected = "cacheserverdisconnected";
        public const string checkerfloor = "checkerfloor";
        public const string clipboard = "clipboard";
        public const string clothinspector_painttool = "clothinspector.painttool";
        public const string clothinspector_paintvalue = "clothinspector.paintvalue";
        public const string clothinspector_selecttool = "clothinspector.selecttool";
        public const string clothinspector_settingstool = "clothinspector.settingstool";
        public const string clothinspector_viewvalue = "clothinspector.viewvalue";
        public const string cloudconnect = "cloudconnect";
        public const string collab_build = "collab.build";
        public const string collab_buildfailed = "collab.buildfailed";
        public const string collab_buildsucceeded = "collab.buildsucceeded";
        public const string collab_fileadded = "collab.fileadded";
        public const string collab_fileconflict = "collab.fileconflict";
        public const string collab_filedeleted = "collab.filedeleted";
        public const string collab_fileignored = "collab.fileignored";
        public const string collab_filemoved = "collab.filemoved";
        public const string collab_fileupdated = "collab.fileupdated";
        public const string collab_folderadded = "collab.folderadded";
        public const string collab_folderconflict = "collab.folderconflict";
        public const string collab_folderdeleted = "collab.folderdeleted";
        public const string collab_folderignored = "collab.folderignored";
        public const string collab_foldermoved = "collab.foldermoved";
        public const string collab_folderupdated = "collab.folderupdated";
        public const string collab_nointernet = "collab.nointernet";
        public const string collab = "collab";
        public const string collab_warning = "collab.warning";
        public const string collabconflict = "collabconflict";
        public const string collaberror = "collaberror";
        public const string collabnew = "collabnew";
        public const string collaboffline = "collaboffline";
        public const string collabprogress = "collabprogress";
        public const string collabpull = "collabpull";
        public const string collabpush = "collabpush";
        public const string colorpicker_colorcycle = "colorpicker.colorcycle";
        public const string colorpicker_cyclecolor = "colorpicker.cyclecolor";
        public const string colorpicker_cycleslider = "colorpicker.cycleslider";
        public const string colorpicker_slidercycle = "colorpicker.slidercycle";
        public const string console_erroricon_inactive_sml = "console.erroricon.inactive.sml";
        public const string console_erroricon = "console.erroricon";
        public const string console_erroricon_sml = "console.erroricon.sml";
        public const string console_infoicon_inactive_sml = "console.infoicon.inactive.sml";
        public const string console_infoicon = "console.infoicon";
        public const string console_infoicon_sml = "console.infoicon.sml";
        public const string console_warnicon_inactive_sml = "console.warnicon.inactive.sml";
        public const string console_warnicon = "console.warnicon";
        public const string console_warnicon_sml = "console.warnicon.sml";
        public const string createaddnew = "createaddnew";
        public const string crossicon = "crossicon";
        public const string curvekeyframe = "curvekeyframe";
        public const string curvekeyframeselected = "curvekeyframeselected";
        public const string curvekeyframeselectedoverlay = "curvekeyframeselectedoverlay";
        public const string curvekeyframesemiselectedoverlay = "curvekeyframesemiselectedoverlay";
        public const string curvekeyframeweighted = "curvekeyframeweighted";
        public const string customsorting = "customsorting";
        public const string customtool = "customtool";
        public const string d__help = "d__help";
        public const string d__menu = "d__menu";
        public const string d__popup = "d__popup";
        public const string d_aboutwindow_mainheader = "d_aboutwindow.mainheader";
        public const string d_ageialogo = "d_ageialogo";
        public const string d_alphabeticalsorting = "d_alphabeticalsorting";
        public const string d_anchortransformtool_on = "d_anchortransformtool on";
        public const string d_anchortransformtool = "d_anchortransformtool";
        public const string d_animation_addevent = "d_animation.addevent";
        public const string d_animation_addkeyframe = "d_animation.addkeyframe";
        public const string d_animation_eventmarker = "d_animation.eventmarker";
        public const string d_animation_filterbyselection = "d_animation.filterbyselection";
        public const string d_animation_firstkey = "d_animation.firstkey";
        public const string d_animation_lastkey = "d_animation.lastkey";
        public const string d_animation_nextkey = "d_animation.nextkey";
        public const string d_animation_play = "d_animation.play";
        public const string d_animation_prevkey = "d_animation.prevkey";
        public const string d_animation_record = "d_animation.record";
        public const string d_animation_sequencerlink = "d_animation.sequencerlink";
        public const string d_animationanimated = "d_animationanimated";
        public const string d_animationkeyframe = "d_animationkeyframe";
        public const string d_animationnocurve = "d_animationnocurve";
        public const string d_animationvisibilitytoggleoff = "d_animationvisibilitytoggleoff";
        public const string d_animationvisibilitytoggleon = "d_animationvisibilitytoggleon";
        public const string d_animationwrapmodemenu = "d_animationwrapmodemenu";
        public const string d_as_badge_delete = "d_as badge delete";
        public const string d_as_badge_new = "d_as badge new";
        public const string d_assemblylock = "d_assemblylock";
        public const string d_asset_store = "d_asset store";
        public const string d_audio_mixer = "d_audio mixer";
        public const string d_autolightbakingoff = "d_autolightbakingoff";
        public const string d_autolightbakingon = "d_autolightbakingon";
        public const string d_avatarblendbackground = "d_avatarblendbackground";
        public const string d_avatarblendleft = "d_avatarblendleft";
        public const string d_avatarblendlefta = "d_avatarblendlefta";
        public const string d_avatarblendright = "d_avatarblendright";
        public const string d_avatarblendrighta = "d_avatarblendrighta";
        public const string d_avatarcompass = "d_avatarcompass";
        public const string d_avatarpivot = "d_avatarpivot";
        public const string d_avatarselector = "d_avatarselector";
        public const string d_back = "d_back";
        public const string d_beginbutton_on = "d_beginbutton-on";
        public const string d_beginbutton = "d_beginbutton";
        public const string d_bluegroove = "d_bluegroove";
        public const string d_buildsettings_android = "d_buildsettings.android";
        public const string d_buildsettings_android_small = "d_buildsettings.android.small";
        public const string d_buildsettings_broadcom = "d_buildsettings.broadcom";
        public const string d_buildsettings_facebook = "d_buildsettings.facebook";
        public const string d_buildsettings_facebook_small = "d_buildsettings.facebook.small";
        public const string d_buildsettings_flashplayer = "d_buildsettings.flashplayer";
        public const string d_buildsettings_flashplayer_small = "d_buildsettings.flashplayer.small";
        public const string d_buildsettings_gamecorescarlett = "d_buildsettings.gamecorescarlett";
        public const string d_buildsettings_gamecorescarlett_small = "d_buildsettings.gamecorescarlett.small";
        public const string d_buildsettings_gamecorexboxone = "d_buildsettings.gamecorexboxone";
        public const string d_buildsettings_gamecorexboxone_small = "d_buildsettings.gamecorexboxone.small";
        public const string d_buildsettings_iphone = "d_buildsettings.iphone";
        public const string d_buildsettings_iphone_small = "d_buildsettings.iphone.small";
        public const string d_buildsettings_lumin = "d_buildsettings.lumin";
        public const string d_buildsettings_lumin_small = "d_buildsettings.lumin.small";
        public const string d_buildsettings_metro = "d_buildsettings.metro";
        public const string d_buildsettings_metro_small = "d_buildsettings.metro.small";
        public const string d_buildsettings_n3ds = "d_buildsettings.n3ds";
        public const string d_buildsettings_n3ds_small = "d_buildsettings.n3ds.small";
        public const string d_buildsettings_ps4 = "d_buildsettings.ps4";
        public const string d_buildsettings_ps4_small = "d_buildsettings.ps4.small";
        public const string d_buildsettings_ps5 = "d_buildsettings.ps5";
        public const string d_buildsettings_ps5_small = "d_buildsettings.ps5.small";
        public const string d_buildsettings_psp2 = "d_buildsettings.psp2";
        public const string d_buildsettings_psp2_small = "d_buildsettings.psp2.small";
        public const string d_buildsettings_selectedicon = "d_buildsettings.selectedicon";
        public const string d_buildsettings_stadia = "d_buildsettings.stadia";
        public const string d_buildsettings_stadia_small = "d_buildsettings.stadia.small";
        public const string d_buildsettings_standalone = "d_buildsettings.standalone";
        public const string d_buildsettings_standalone_small = "d_buildsettings.standalone.small";
        public const string d_buildsettings_switch = "d_buildsettings.switch";
        public const string d_buildsettings_switch_small = "d_buildsettings.switch.small";
        public const string d_buildsettings_tvos = "d_buildsettings.tvos";
        public const string d_buildsettings_tvos_small = "d_buildsettings.tvos.small";
        public const string d_buildsettings_web = "d_buildsettings.web";
        public const string d_buildsettings_web_small = "d_buildsettings.web.small";
        public const string d_buildsettings_webgl = "d_buildsettings.webgl";
        public const string d_buildsettings_webgl_small = "d_buildsettings.webgl.small";
        public const string d_buildsettings_xbox360 = "d_buildsettings.xbox360";
        public const string d_buildsettings_xbox360_small = "d_buildsettings.xbox360.small";
        public const string d_buildsettings_xboxone = "d_buildsettings.xboxone";
        public const string d_buildsettings_xboxone_small = "d_buildsettings.xboxone.small";
        public const string d_buildsettings_xiaomi = "d_buildsettings.xiaomi";
        public const string d_buildsettings_xiaomi_small = "d_buildsettings.xiaomi.small";
        public const string d_cacheserverconnected = "d_cacheserverconnected";
        public const string d_cacheserverdisabled = "d_cacheserverdisabled";
        public const string d_cacheserverdisconnected = "d_cacheserverdisconnected";
        public const string d_checkerfloor = "d_checkerfloor";
        public const string d_cloudconnect = "d_cloudconnect";
        public const string d_collab_fileadded = "d_collab.fileadded";
        public const string d_collab_fileconflict = "d_collab.fileconflict";
        public const string d_collab_filedeleted = "d_collab.filedeleted";
        public const string d_collab_fileignored = "d_collab.fileignored";
        public const string d_collab_filemoved = "d_collab.filemoved";
        public const string d_collab_fileupdated = "d_collab.fileupdated";
        public const string d_collab_folderadded = "d_collab.folderadded";
        public const string d_collab_folderconflict = "d_collab.folderconflict";
        public const string d_collab_folderdeleted = "d_collab.folderdeleted";
        public const string d_collab_folderignored = "d_collab.folderignored";
        public const string d_collab_foldermoved = "d_collab.foldermoved";
        public const string d_collab_folderupdated = "d_collab.folderupdated";
        public const string d_collab = "d_collab";
        public const string d_colorpicker_cyclecolor = "d_colorpicker.cyclecolor";
        public const string d_colorpicker_cycleslider = "d_colorpicker.cycleslider";
        public const string d_console_erroricon_inactive_sml = "d_console.erroricon.inactive.sml";
        public const string d_console_erroricon = "d_console.erroricon";
        public const string d_console_erroricon_sml = "d_console.erroricon.sml";
        public const string d_console_infoicon_inactive_sml = "d_console.infoicon.inactive.sml";
        public const string d_console_infoicon = "d_console.infoicon";
        public const string d_console_infoicon_sml = "d_console.infoicon.sml";
        public const string d_console_warnicon_inactive_sml = "d_console.warnicon.inactive.sml";
        public const string d_console_warnicon = "d_console.warnicon";
        public const string d_console_warnicon_sml = "d_console.warnicon.sml";
        public const string d_createaddnew = "d_createaddnew";
        public const string d_curvekeyframe = "d_curvekeyframe";
        public const string d_curvekeyframeselected = "d_curvekeyframeselected";
        public const string d_curvekeyframeselectedoverlay = "d_curvekeyframeselectedoverlay";
        public const string d_curvekeyframesemiselectedoverlay = "d_curvekeyframesemiselectedoverlay";
        public const string d_curvekeyframeweighted = "d_curvekeyframeweighted";
        public const string d_customsorting = "d_customsorting";
        public const string d_customtool = "d_customtool";
        public const string d_debuggerattached = "d_debuggerattached";
        public const string d_debuggerdisabled = "d_debuggerdisabled";
        public const string d_debuggerenabled = "d_debuggerenabled";
        public const string d_defaultsorting = "d_defaultsorting";
        public const string d_editcollider = "d_editcollider";
        public const string d_editcollision_16 = "d_editcollision_16";
        public const string d_editcollision_32 = "d_editcollision_32";
        public const string d_editconstraints_16 = "d_editconstraints_16";
        public const string d_editconstraints_32 = "d_editconstraints_32";
        public const string d_editicon_sml = "d_editicon.sml";
        public const string d_endbutton_on = "d_endbutton-on";
        public const string d_endbutton = "d_endbutton";
        public const string d_exposure = "d_exposure";
        public const string d_eyedropper_large = "d_eyedropper.large";
        public const string d_eyedropper_sml = "d_eyedropper.sml";
        public const string d_favorite = "d_favorite";
        public const string d_filterbylabel = "d_filterbylabel";
        public const string d_filterbytype = "d_filterbytype";
        public const string d_filterselectedonly = "d_filterselectedonly";
        public const string d_forward = "d_forward";
        public const string d_framecapture = "d_framecapture";
        public const string d_gear = "d_gear";
        public const string d_gizmostoggle_on = "d_gizmostoggle on";
        public const string d_gizmostoggle = "d_gizmostoggle";
        public const string d_grid_boxtool = "d_grid.boxtool";
        public const string d_grid_default = "d_grid.default";
        public const string d_grid_erasertool = "d_grid.erasertool";
        public const string d_grid_filltool = "d_grid.filltool";
        public const string d_grid_movetool = "d_grid.movetool";
        public const string d_grid_painttool = "d_grid.painttool";
        public const string d_grid_pickingtool = "d_grid.pickingtool";
        public const string d_groove = "d_groove";
        public const string d_horizontalsplit = "d_horizontalsplit";
        public const string d_icon_dropdown = "d_icon dropdown";
        public const string d_import = "d_import";
        public const string d_inspectorlock = "d_inspectorlock";
        public const string d_invalid = "d_invalid";
        public const string d_jointangularlimits = "d_jointangularlimits";
        public const string d_leftbracket = "d_leftbracket";
        public const string d_lighting = "d_lighting";
        public const string d_lightmapeditor_windowtitle = "d_lightmapeditor.windowtitle";
        public const string d_linked = "d_linked";
        public const string d_mainstageview = "d_mainstageview";
        public const string d_mirror = "d_mirror";
        public const string d_model_large = "d_model large";
        public const string d_monologo = "d_monologo";
        public const string d_moreoptions = "d_moreoptions";
        public const string d_movetool_on = "d_movetool on";
        public const string d_movetool = "d_movetool";
        public const string d_navigation = "d_navigation";
        public const string d_occlusion = "d_occlusion";
        public const string d_package_manager = "d_package manager";
        public const string d_particle_effect = "d_particle effect";
        public const string d_particleshapetool_on = "d_particleshapetool on";
        public const string d_particleshapetool = "d_particleshapetool";
        public const string d_pausebutton_on = "d_pausebutton on";
        public const string d_pausebutton = "d_pausebutton";
        public const string d_playbutton_on = "d_playbutton on";
        public const string d_playbutton = "d_playbutton";
        public const string d_playbuttonprofile_on = "d_playbuttonprofile on";
        public const string d_playbuttonprofile = "d_playbuttonprofile";
        public const string d_playloopoff = "d_playloopoff";
        public const string d_playloopon = "d_playloopon";
        public const string d_preaudioautoplayoff = "d_preaudioautoplayoff";
        public const string d_preaudioautoplayon = "d_preaudioautoplayon";
        public const string d_preaudioloopoff = "d_preaudioloopoff";
        public const string d_preaudioloopon = "d_preaudioloopon";
        public const string d_preaudioplayoff = "d_preaudioplayoff";
        public const string d_preaudioplayon = "d_preaudioplayon";
        public const string d_prematcube = "d_prematcube";
        public const string d_prematcylinder = "d_prematcylinder";
        public const string d_prematlight0 = "d_prematlight0";
        public const string d_prematlight1 = "d_prematlight1";
        public const string d_prematquad = "d_prematquad";
        public const string d_prematsphere = "d_prematsphere";
        public const string d_premattorus = "d_premattorus";
        public const string d_preset_context = "d_preset.context";
        public const string d_pretexa = "d_pretexa";
        public const string d_pretexb = "d_pretexb";
        public const string d_pretexg = "d_pretexg";
        public const string d_pretexr = "d_pretexr";
        public const string d_pretexrgb = "d_pretexrgb";
        public const string d_pretexturealpha = "d_pretexturealpha";
        public const string d_pretexturemipmaphigh = "d_pretexturemipmaphigh";
        public const string d_pretexturemipmaplow = "d_pretexturemipmaplow";
        public const string d_pretexturergb = "d_pretexturergb";
        public const string d_profiler_audio = "d_profiler.audio";
        public const string d_profiler_cpu = "d_profiler.cpu";
        public const string d_profiler_custom = "d_profiler.custom";
        public const string d_profiler_firstframe = "d_profiler.firstframe";
        public const string d_profiler_globalillumination = "d_profiler.globalillumination";
        public const string d_profiler_gpu = "d_profiler.gpu";
        public const string d_profiler_lastframe = "d_profiler.lastframe";
        public const string d_profiler_memory = "d_profiler.memory";
        public const string d_profiler_network = "d_profiler.network";
        public const string d_profiler_networkmessages = "d_profiler.networkmessages";
        public const string d_profiler_networkoperations = "d_profiler.networkoperations";
        public const string d_profiler_nextframe = "d_profiler.nextframe";
        public const string d_profiler_open = "d_profiler.open";
        public const string d_profiler_physics = "d_profiler.physics";
        public const string d_profiler_physics2d = "d_profiler.physics2d";
        public const string d_profiler_prevframe = "d_profiler.prevframe";
        public const string d_profiler_record = "d_profiler.record";
        public const string d_profiler_rendering = "d_profiler.rendering";
        public const string d_profiler_ui = "d_profiler.ui";
        public const string d_profiler_uidetails = "d_profiler.uidetails";
        public const string d_profiler_video = "d_profiler.video";
        public const string d_profiler_virtualtexturing = "d_profiler.virtualtexturing";
        public const string d_profilercolumn_warningcount = "d_profilercolumn.warningcount";
        public const string d_progress = "d_progress";
        public const string d_project = "d_project";
        public const string d_record_off = "d_record off";
        public const string d_record_on = "d_record on";
        public const string d_recttool_on = "d_recttool on";
        public const string d_recttool = "d_recttool";
        public const string d_recttransformblueprint = "d_recttransformblueprint";
        public const string d_recttransformraw = "d_recttransformraw";
        public const string d_redgroove = "d_redgroove";
        public const string d_reflectionprobeselector = "d_reflectionprobeselector";
        public const string d_refresh = "d_refresh";
        public const string d_rightbracket = "d_rightbracket";
        public const string d_rotatetool_on = "d_rotatetool on";
        public const string d_rotatetool = "d_rotatetool";
        public const string d_saveas = "d_saveas";
        public const string d_scaletool_on = "d_scaletool on";
        public const string d_scaletool = "d_scaletool";
        public const string d_scenepicking_notpickable_mixed = "d_scenepicking_notpickable-mixed";
        public const string d_scenepicking_notpickable_mixed_hover = "d_scenepicking_notpickable-mixed_hover";
        public const string d_scenepicking_notpickable = "d_scenepicking_notpickable";
        public const string d_scenepicking_notpickable_hover = "d_scenepicking_notpickable_hover";
        public const string d_scenepicking_pickable_mixed = "d_scenepicking_pickable-mixed";
        public const string d_scenepicking_pickable_mixed_hover = "d_scenepicking_pickable-mixed_hover";
        public const string d_scenepicking_pickable = "d_scenepicking_pickable";
        public const string d_scenepicking_pickable_hover = "d_scenepicking_pickable_hover";
        public const string d_sceneview2d_on = "d_sceneview2d on";
        public const string d_sceneview2d = "d_sceneview2d";
        public const string d_sceneviewalpha = "d_sceneviewalpha";
        public const string d_sceneviewaudio_on = "d_sceneviewaudio on";
        public const string d_sceneviewaudio = "d_sceneviewaudio";
        public const string d_sceneviewcamera = "d_sceneviewcamera";
        public const string d_sceneviewfx_on = "d_sceneviewfx on";
        public const string d_sceneviewfx = "d_sceneviewfx";
        public const string d_sceneviewlighting_on = "d_sceneviewlighting on";
        public const string d_sceneviewlighting = "d_sceneviewlighting";
        public const string d_sceneviewortho = "d_sceneviewortho";
        public const string d_sceneviewrgb = "d_sceneviewrgb";
        public const string d_sceneviewtools = "d_sceneviewtools";
        public const string d_sceneviewvisibility_on = "d_sceneviewvisibility on";
        public const string d_sceneviewvisibility = "d_sceneviewvisibility";
        public const string d_scenevis_hidden_mixed = "d_scenevis_hidden-mixed";
        public const string d_scenevis_hidden_mixed_hover = "d_scenevis_hidden-mixed_hover";
        public const string d_scenevis_hidden = "d_scenevis_hidden";
        public const string d_scenevis_hidden_hover = "d_scenevis_hidden_hover";
        public const string d_scenevis_scene_hover = "d_scenevis_scene_hover";
        public const string d_scenevis_visible_mixed = "d_scenevis_visible-mixed";
        public const string d_scenevis_visible_mixed_hover = "d_scenevis_visible-mixed_hover";
        public const string d_scenevis_visible = "d_scenevis_visible";
        public const string d_scenevis_visible_hover = "d_scenevis_visible_hover";
        public const string d_scrollshadow = "d_scrollshadow";
        public const string d_settings = "d_settings";
        public const string d_settingsicon = "d_settingsicon";
        public const string d_showpanels = "d_showpanels";
        public const string d_socialnetworks_facebookshare = "d_socialnetworks.facebookshare";
        public const string d_socialnetworks_linkedinshare = "d_socialnetworks.linkedinshare";
        public const string d_socialnetworks_tweet = "d_socialnetworks.tweet";
        public const string d_socialnetworks_udnopen = "d_socialnetworks.udnopen";
        public const string d_speedscale = "d_speedscale";
        public const string d_stepbutton_on = "d_stepbutton on";
        public const string d_stepbutton = "d_stepbutton";
        public const string d_stepleftbutton_on = "d_stepleftbutton-on";
        public const string d_stepleftbutton = "d_stepleftbutton";
        public const string d_tab_next = "d_tab_next";
        public const string d_tab_prev = "d_tab_prev";
        public const string d_terraininspector_terraintooladd = "d_terraininspector.terraintooladd";
        public const string d_terraininspector_terraintoollower_on = "d_terraininspector.terraintoollower on";
        public const string d_terraininspector_terraintoolloweralt = "d_terraininspector.terraintoolloweralt";
        public const string d_terraininspector_terraintoolplants_on = "d_terraininspector.terraintoolplants on";
        public const string d_terraininspector_terraintoolplants = "d_terraininspector.terraintoolplants";
        public const string d_terraininspector_terraintoolplantsalt_on = "d_terraininspector.terraintoolplantsalt on";
        public const string d_terraininspector_terraintoolplantsalt = "d_terraininspector.terraintoolplantsalt";
        public const string d_terraininspector_terraintoolraise_on = "d_terraininspector.terraintoolraise on";
        public const string d_terraininspector_terraintoolraise = "d_terraininspector.terraintoolraise";
        public const string d_terraininspector_terraintoolsetheight_on = "d_terraininspector.terraintoolsetheight on";
        public const string d_terraininspector_terraintoolsetheight = "d_terraininspector.terraintoolsetheight";
        public const string d_terraininspector_terraintoolsetheightalt_on = "d_terraininspector.terraintoolsetheightalt on";
        public const string d_terraininspector_terraintoolsetheightalt = "d_terraininspector.terraintoolsetheightalt";
        public const string d_terraininspector_terraintoolsettings_on = "d_terraininspector.terraintoolsettings on";
        public const string d_terraininspector_terraintoolsettings = "d_terraininspector.terraintoolsettings";
        public const string d_terraininspector_terraintoolsmoothheight_on = "d_terraininspector.terraintoolsmoothheight on";
        public const string d_terraininspector_terraintoolsmoothheight = "d_terraininspector.terraintoolsmoothheight";
        public const string d_terraininspector_terraintoolsplat_on = "d_terraininspector.terraintoolsplat on";
        public const string d_terraininspector_terraintoolsplat = "d_terraininspector.terraintoolsplat";
        public const string d_terraininspector_terraintoolsplatalt_on = "d_terraininspector.terraintoolsplatalt on";
        public const string d_terraininspector_terraintoolsplatalt = "d_terraininspector.terraintoolsplatalt";
        public const string d_terraininspector_terraintooltrees_on = "d_terraininspector.terraintooltrees on";
        public const string d_terraininspector_terraintooltrees = "d_terraininspector.terraintooltrees";
        public const string d_terraininspector_terraintooltreesalt_on = "d_terraininspector.terraintooltreesalt on";
        public const string d_terraininspector_terraintooltreesalt = "d_terraininspector.terraintooltreesalt";
        public const string d_toggleuvoverlay = "d_toggleuvoverlay";
        public const string d_toolbar_minus = "d_toolbar minus";
        public const string d_toolbar_plus_more = "d_toolbar plus more";
        public const string d_toolbar_plus = "d_toolbar plus";
        public const string d_toolhandlecenter = "d_toolhandlecenter";
        public const string d_toolhandleglobal = "d_toolhandleglobal";
        public const string d_toolhandlelocal = "d_toolhandlelocal";
        public const string d_toolhandlepivot = "d_toolhandlepivot";
        public const string d_toolsicon = "d_toolsicon";
        public const string d_tranp = "d_tranp";
        public const string d_transformtool_on = "d_transformtool on";
        public const string d_transformtool = "d_transformtool";
        public const string d_tree_icon = "d_tree_icon";
        public const string d_tree_icon_branch = "d_tree_icon_branch";
        public const string d_tree_icon_branch_frond = "d_tree_icon_branch_frond";
        public const string d_tree_icon_frond = "d_tree_icon_frond";
        public const string d_tree_icon_leaf = "d_tree_icon_leaf";
        public const string d_treeeditor_addbranches = "d_treeeditor.addbranches";
        public const string d_treeeditor_addleaves = "d_treeeditor.addleaves";
        public const string d_treeeditor_branch_on = "d_treeeditor.branch on";
        public const string d_treeeditor_branch = "d_treeeditor.branch";
        public const string d_treeeditor_branchfreehand_on = "d_treeeditor.branchfreehand on";
        public const string d_treeeditor_branchfreehand = "d_treeeditor.branchfreehand";
        public const string d_treeeditor_branchrotate_on = "d_treeeditor.branchrotate on";
        public const string d_treeeditor_branchrotate = "d_treeeditor.branchrotate";
        public const string d_treeeditor_branchscale_on = "d_treeeditor.branchscale on";
        public const string d_treeeditor_branchscale = "d_treeeditor.branchscale";
        public const string d_treeeditor_branchtranslate_on = "d_treeeditor.branchtranslate on";
        public const string d_treeeditor_branchtranslate = "d_treeeditor.branchtranslate";
        public const string d_treeeditor_distribution_on = "d_treeeditor.distribution on";
        public const string d_treeeditor_distribution = "d_treeeditor.distribution";
        public const string d_treeeditor_duplicate = "d_treeeditor.duplicate";
        public const string d_treeeditor_geometry_on = "d_treeeditor.geometry on";
        public const string d_treeeditor_geometry = "d_treeeditor.geometry";
        public const string d_treeeditor_leaf_on = "d_treeeditor.leaf on";
        public const string d_treeeditor_leaf = "d_treeeditor.leaf";
        public const string d_treeeditor_leaffreehand_on = "d_treeeditor.leaffreehand on";
        public const string d_treeeditor_leaffreehand = "d_treeeditor.leaffreehand";
        public const string d_treeeditor_leafrotate_on = "d_treeeditor.leafrotate on";
        public const string d_treeeditor_leafrotate = "d_treeeditor.leafrotate";
        public const string d_treeeditor_leafscale_on = "d_treeeditor.leafscale on";
        public const string d_treeeditor_leafscale = "d_treeeditor.leafscale";
        public const string d_treeeditor_leaftranslate_on = "d_treeeditor.leaftranslate on";
        public const string d_treeeditor_leaftranslate = "d_treeeditor.leaftranslate";
        public const string d_treeeditor_material_on = "d_treeeditor.material on";
        public const string d_treeeditor_material = "d_treeeditor.material";
        public const string d_treeeditor_refresh = "d_treeeditor.refresh";
        public const string d_treeeditor_trash = "d_treeeditor.trash";
        public const string d_treeeditor_wind_on = "d_treeeditor.wind on";
        public const string d_treeeditor_wind = "d_treeeditor.wind";
        public const string d_unityeditor_animationwindow = "d_unityeditor.animationwindow";
        public const string d_unityeditor_consolewindow = "d_unityeditor.consolewindow";
        public const string d_unityeditor_debuginspectorwindow = "d_unityeditor.debuginspectorwindow";
        public const string d_unityeditor_devicesimulation_simulatorwindow = "d_unityeditor.devicesimulation.simulatorwindow";
        public const string d_unityeditor_finddependencies = "d_unityeditor.finddependencies";
        public const string d_unityeditor_gameview = "d_unityeditor.gameview";
        public const string d_unityeditor_graphs_animatorcontrollertool = "d_unityeditor.graphs.animatorcontrollertool";
        public const string d_unityeditor_hierarchywindow = "d_unityeditor.hierarchywindow";
        public const string d_unityeditor_inspectorwindow = "d_unityeditor.inspectorwindow";
        public const string d_unityeditor_profilerwindow = "d_unityeditor.profilerwindow";
        public const string d_unityeditor_scenehierarchywindow = "d_unityeditor.scenehierarchywindow";
        public const string d_unityeditor_sceneview = "d_unityeditor.sceneview";
        public const string d_unityeditor_timeline_timelinewindow = "d_unityeditor.timeline.timelinewindow";
        public const string d_unityeditor_versioncontrol = "d_unityeditor.versioncontrol";
        public const string d_unitylogo = "d_unitylogo";
        public const string d_unlinked = "d_unlinked";
        public const string d_valid = "d_valid";
        public const string d_verticalsplit = "d_verticalsplit";
        public const string d_viewtoolmove_on = "d_viewtoolmove on";
        public const string d_viewtoolmove = "d_viewtoolmove";
        public const string d_viewtoolorbit_on = "d_viewtoolorbit on";
        public const string d_viewtoolorbit = "d_viewtoolorbit";
        public const string d_viewtoolzoom_on = "d_viewtoolzoom on";
        public const string d_viewtoolzoom = "d_viewtoolzoom";
        public const string d_visibilityoff = "d_visibilityoff";
        public const string d_visibilityon = "d_visibilityon";
        public const string d_vumetertexturehorizontal = "d_vumetertexturehorizontal";
        public const string d_vumetertexturevertical = "d_vumetertexturevertical";
        public const string d_waitspin00 = "d_waitspin00";
        public const string d_waitspin01 = "d_waitspin01";
        public const string d_waitspin02 = "d_waitspin02";
        public const string d_waitspin03 = "d_waitspin03";
        public const string d_waitspin04 = "d_waitspin04";
        public const string d_waitspin05 = "d_waitspin05";
        public const string d_waitspin06 = "d_waitspin06";
        public const string d_waitspin07 = "d_waitspin07";
        public const string d_waitspin08 = "d_waitspin08";
        public const string d_waitspin09 = "d_waitspin09";
        public const string d_waitspin10 = "d_waitspin10";
        public const string d_waitspin11 = "d_waitspin11";
        public const string d_welcomescreen_assetstorelogo = "d_welcomescreen.assetstorelogo";
        public const string d_winbtn_graph = "d_winbtn_graph";
        public const string d_winbtn_graph_close_h = "d_winbtn_graph_close_h";
        public const string d_winbtn_graph_max_h = "d_winbtn_graph_max_h";
        public const string d_winbtn_graph_min_h = "d_winbtn_graph_min_h";
        public const string d_winbtn_mac_close = "d_winbtn_mac_close";
        public const string d_winbtn_mac_close_a = "d_winbtn_mac_close_a";
        public const string d_winbtn_mac_close_h = "d_winbtn_mac_close_h";
        public const string d_winbtn_mac_inact = "d_winbtn_mac_inact";
        public const string d_winbtn_mac_max = "d_winbtn_mac_max";
        public const string d_winbtn_mac_max_a = "d_winbtn_mac_max_a";
        public const string d_winbtn_mac_max_h = "d_winbtn_mac_max_h";
        public const string d_winbtn_mac_min = "d_winbtn_mac_min";
        public const string d_winbtn_mac_min_a = "d_winbtn_mac_min_a";
        public const string d_winbtn_mac_min_h = "d_winbtn_mac_min_h";
        public const string d_winbtn_win_close = "d_winbtn_win_close";
        public const string d_winbtn_win_close_a = "d_winbtn_win_close_a";
        public const string d_winbtn_win_close_h = "d_winbtn_win_close_h";
        public const string d_winbtn_win_max = "d_winbtn_win_max";
        public const string d_winbtn_win_max_a = "d_winbtn_win_max_a";
        public const string d_winbtn_win_max_h = "d_winbtn_win_max_h";
        public const string d_winbtn_win_min = "d_winbtn_win_min";
        public const string d_winbtn_win_min_a = "d_winbtn_win_min_a";
        public const string d_winbtn_win_min_h = "d_winbtn_win_min_h";
        public const string d_winbtn_win_rest = "d_winbtn_win_rest";
        public const string d_winbtn_win_rest_a = "d_winbtn_win_rest_a";
        public const string d_winbtn_win_rest_h = "d_winbtn_win_rest_h";
        public const string d_winbtn_win_restore = "d_winbtn_win_restore";
        public const string d_winbtn_win_restore_a = "d_winbtn_win_restore_a";
        public const string d_winbtn_win_restore_h = "d_winbtn_win_restore_h";
        public const string debuggerattached = "debuggerattached";
        public const string debuggerdisabled = "debuggerdisabled";
        public const string debuggerenabled = "debuggerenabled";
        public const string defaultsorting = "defaultsorting";
        public const string editcollider = "editcollider";
        public const string editcollision_16 = "editcollision_16";
        public const string editcollision_32 = "editcollision_32";
        public const string editconstraints_16 = "editconstraints_16";
        public const string editconstraints_32 = "editconstraints_32";
        public const string editicon_sml = "editicon.sml";
        public const string endbutton_on = "endbutton-on";
        public const string endbutton = "endbutton";
        public const string exposure = "exposure";
        public const string eyedropper_large = "eyedropper.large";
        public const string eyedropper_sml = "eyedropper.sml";
        public const string favorite = "favorite";
        public const string filterbylabel = "filterbylabel";
        public const string filterbytype = "filterbytype";
        public const string filterselectedonly = "filterselectedonly";
        public const string forward = "forward";
        public const string framecapture_on = "framecapture on";
        public const string framecapture = "framecapture";
        public const string gear = "gear";
        public const string gizmostoggle_on = "gizmostoggle on";
        public const string gizmostoggle = "gizmostoggle";
        public const string grid_boxtool = "grid.boxtool";
        public const string grid_default = "grid.default";
        public const string grid_erasertool = "grid.erasertool";
        public const string grid_filltool = "grid.filltool";
        public const string grid_movetool = "grid.movetool";
        public const string grid_painttool = "grid.painttool";
        public const string grid_pickingtool = "grid.pickingtool";
        public const string groove = "groove";
        public const string align_horizontally = "align_horizontally";
        public const string align_horizontally_center = "align_horizontally_center";
        public const string align_horizontally_center_active = "align_horizontally_center_active";
        public const string align_horizontally_left = "align_horizontally_left";
        public const string align_horizontally_left_active = "align_horizontally_left_active";
        public const string align_horizontally_right = "align_horizontally_right";
        public const string align_horizontally_right_active = "align_horizontally_right_active";
        public const string align_vertically = "align_vertically";
        public const string align_vertically_bottom = "align_vertically_bottom";
        public const string align_vertically_bottom_active = "align_vertically_bottom_active";
        public const string align_vertically_center = "align_vertically_center";
        public const string align_vertically_center_active = "align_vertically_center_active";
        public const string align_vertically_top = "align_vertically_top";
        public const string align_vertically_top_active = "align_vertically_top_active";
        public const string d_align_horizontally = "d_align_horizontally";
        public const string d_align_horizontally_center = "d_align_horizontally_center";
        public const string d_align_horizontally_center_active = "d_align_horizontally_center_active";
        public const string d_align_horizontally_left = "d_align_horizontally_left";
        public const string d_align_horizontally_left_active = "d_align_horizontally_left_active";
        public const string d_align_horizontally_right = "d_align_horizontally_right";
        public const string d_align_horizontally_right_active = "d_align_horizontally_right_active";
        public const string d_align_vertically = "d_align_vertically";
        public const string d_align_vertically_bottom = "d_align_vertically_bottom";
        public const string d_align_vertically_bottom_active = "d_align_vertically_bottom_active";
        public const string d_align_vertically_center = "d_align_vertically_center";
        public const string d_align_vertically_center_active = "d_align_vertically_center_active";
        public const string d_align_vertically_top = "d_align_vertically_top";
        public const string d_align_vertically_top_active = "d_align_vertically_top_active";
        public const string horizontalsplit = "horizontalsplit";
        public const string icon_dropdown = "icon dropdown";
        public const string import = "import";
        public const string inspectorlock = "inspectorlock";
        public const string invalid = "invalid";
        public const string jointangularlimits = "jointangularlimits";
        public const string knobcshape = "knobcshape";
        public const string knobcshapemini = "knobcshapemini";
        public const string leftbracket = "leftbracket";
        public const string lighting = "lighting";
        public const string lightmapeditor_windowtitle = "lightmapeditor.windowtitle";
        public const string lightmapping = "lightmapping";
        public const string d_greenlight = "d_greenlight";
        public const string d_lightoff = "d_lightoff";
        public const string d_lightrim = "d_lightrim";
        public const string d_orangelight = "d_orangelight";
        public const string d_redlight = "d_redlight";
        public const string greenlight = "greenlight";
        public const string lightoff = "lightoff";
        public const string lightrim = "lightrim";
        public const string orangelight = "orangelight";
        public const string redlight = "redlight";
        public const string linked = "linked";
        public const string lockicon_on = "lockicon-on";
        public const string lockicon = "lockicon";
        public const string loop = "loop";
        public const string mainstageview = "mainstageview";
        public const string mirror = "mirror";
        public const string monologo = "monologo";
        public const string moreoptions = "moreoptions";
        public const string movetool_on = "movetool on";
        public const string movetool = "movetool";
        public const string navigation = "navigation";
        public const string occlusion = "occlusion";
        public const string camerapreview = "camerapreview";
        public const string d_camerapreview = "d_camerapreview";
        public const string d_gridandsnap = "d_gridandsnap";
        public const string d_orientationgizmo = "d_orientationgizmo";
        public const string d_searchoverlay = "d_searchoverlay";
        public const string d_standardtools = "d_standardtools";
        public const string d_toolsettings = "d_toolsettings";
        public const string d_toolstoggle = "d_toolstoggle";
        public const string d_viewoptions = "d_viewoptions";
        public const string gridandsnap = "gridandsnap";
        public const string grip_horizontalcontainer = "grip_horizontalcontainer";
        public const string grip_verticalcontainer = "grip_verticalcontainer";
        public const string hoverbar_down = "hoverbar_down";
        public const string hoverbar_leftright = "hoverbar_leftright";
        public const string hoverbar_up = "hoverbar_up";
        public const string locked = "locked";
        public const string orientationgizmo = "orientationgizmo";
        public const string searchoverlay = "searchoverlay";
        public const string standardtools = "standardtools";
        public const string toolsettings = "toolsettings";
        public const string toolstoggle = "toolstoggle";
        public const string unlocked = "unlocked";
        public const string viewoptions = "viewoptions";
        public const string package_manager = "package manager";
        public const string packagebadgedelete = "packagebadgedelete";
        public const string packagebadgenew = "packagebadgenew";
        public const string feature_selected = "feature-selected";
        public const string feature = "feature";
        public const string quickstart = "quickstart";
        public const string add_available = "add-available";
        public const string custom = "custom";
        public const string customized = "customized";
        public const string download_available = "download-available";
        public const string error = "error";
        public const string git = "git";
        public const string import_available = "import-available";
        public const string info = "info";
        public const string installed = "installed";
        public const string link = "link";
        public const string loading = "loading";
        public const string refresh = "refresh";
        public const string update_available = "update-available";
        public const string warning = "warning";
        public const string particle_effect = "particle effect";
        public const string particleshapetool_on = "particleshapetool on";
        public const string particleshapetool = "particleshapetool";
        public const string pausebutton_on = "pausebutton on";
        public const string pausebutton = "pausebutton";
        public const string playbutton_on = "playbutton on";
        public const string playbutton = "playbutton";
        public const string playbuttonprofile_on = "playbuttonprofile on";
        public const string playbuttonprofile = "playbuttonprofile";
        public const string playloopoff = "playloopoff";
        public const string playloopon = "playloopon";
        public const string playspeed = "playspeed";
        public const string preaudioautoplayoff = "preaudioautoplayoff";
        public const string preaudioautoplayon = "preaudioautoplayon";
        public const string preaudioloopoff = "preaudioloopoff";
        public const string preaudioloopon = "preaudioloopon";
        public const string preaudioplayoff = "preaudioplayoff";
        public const string preaudioplayon = "preaudioplayon";
        public const string prematcube = "prematcube";
        public const string prematcylinder = "prematcylinder";
        public const string prematlight0 = "prematlight0";
        public const string prematlight1 = "prematlight1";
        public const string prematquad = "prematquad";
        public const string prematsphere = "prematsphere";
        public const string premattorus = "premattorus";
        public const string preset_context = "preset.context";
        public const string pretexa = "pretexa";
        public const string pretexb = "pretexb";
        public const string pretexg = "pretexg";
        public const string pretexr = "pretexr";
        public const string pretexrgb = "pretexrgb";
        public const string pretexturealpha = "pretexturealpha";
        public const string pretexturearrayfirstslice = "pretexturearrayfirstslice";
        public const string pretexturearraylastslice = "pretexturearraylastslice";
        public const string pretexturemipmaphigh = "pretexturemipmaphigh";
        public const string pretexturemipmaplow = "pretexturemipmaplow";
        public const string pretexturergb = "pretexturergb";
        public const string previewpackageinuse = "previewpackageinuse";
        public const string arealight_gizmo = "arealight gizmo";
        public const string arealight_icon = "arealight icon";
        public const string assembly_icon = "assembly icon";
        public const string assetstore_icon = "assetstore icon";
        public const string audiomixerview_icon = "audiomixerview icon";
        public const string audiosource_gizmo = "audiosource gizmo";
        public const string boo_script_icon = "boo script icon";
        public const string camera_gizmo = "camera gizmo";
        public const string chorusfilter_icon = "chorusfilter icon";
        public const string collabchanges_icon = "collabchanges icon";
        public const string collabchangesconflict_icon = "collabchangesconflict icon";
        public const string collabchangesdeleted_icon = "collabchangesdeleted icon";
        public const string collabconflict_icon = "collabconflict icon";
        public const string collabcreate_icon = "collabcreate icon";
        public const string collabdeleted_icon = "collabdeleted icon";
        public const string collabedit_icon = "collabedit icon";
        public const string collabexclude_icon = "collabexclude icon";
        public const string collabmoved_icon = "collabmoved icon";
        public const string cs_script_icon = "cs script icon";
        public const string d_arealight_icon = "d_arealight icon";
        public const string d_assembly_icon = "d_assembly icon";
        public const string d_assetstore_icon = "d_assetstore icon";
        public const string d_audiomixerview_icon = "d_audiomixerview icon";
        public const string d_boo_script_icon = "d_boo script icon";
        public const string d_collabchanges_icon = "d_collabchanges icon";
        public const string d_collabchangesconflict_icon = "d_collabchangesconflict icon";
        public const string d_collabchangesdeleted_icon = "d_collabchangesdeleted icon";
        public const string d_collabconflict_icon = "d_collabconflict icon";
        public const string d_collabcreate_icon = "d_collabcreate icon";
        public const string d_collabdeleted_icon = "d_collabdeleted icon";
        public const string d_collabedit_icon = "d_collabedit icon";
        public const string d_collabexclude_icon = "d_collabexclude icon";
        public const string d_collabmoved_icon = "d_collabmoved icon";
        public const string d_cs_script_icon = "d_cs script icon";
        public const string d_directionallight_icon = "d_directionallight icon";
        public const string d_favorite_icon = "d_favorite icon";
        public const string d_favorite_on_icon = "d_favorite on icon";
        public const string d_folder_icon = "d_folder icon";
        public const string d_folder_on_icon = "d_folder on icon";
        public const string d_folderempty_icon = "d_folderempty icon";
        public const string d_folderempty_on_icon = "d_folderempty on icon";
        public const string d_folderfavorite_icon = "d_folderfavorite icon";
        public const string d_folderfavorite_on_icon = "d_folderfavorite on icon";
        public const string d_folderopened_icon = "d_folderopened icon";
        public const string d_gridlayoutgroup_icon = "d_gridlayoutgroup icon";
        public const string d_horizontallayoutgroup_icon = "d_horizontallayoutgroup icon";
        public const string d_js_script_icon = "d_js script icon";
        public const string d_lightingdataassetparent_icon = "d_lightingdataassetparent icon";
        public const string d_microphone_icon = "d_microphone icon";
        public const string d_prefab_icon = "d_prefab icon";
        public const string d_prefab_on_icon = "d_prefab on icon";
        public const string d_prefabmodel_icon = "d_prefabmodel icon";
        public const string d_prefabmodel_on_icon = "d_prefabmodel on icon";
        public const string d_prefabvariant_icon = "d_prefabvariant icon";
        public const string d_prefabvariant_on_icon = "d_prefabvariant on icon";
        public const string d_raycastcollider_icon = "d_raycastcollider icon";
        public const string d_search_icon = "d_search icon";
        public const string d_search_on_icon = "d_search on icon";
        public const string d_searchjump_icon = "d_searchjump icon";
        public const string d_settings_icon = "d_settings icon";
        public const string d_shortcut_icon = "d_shortcut icon";
        public const string d_spotlight_icon = "d_spotlight icon";
        public const string d_verticallayoutgroup_icon = "d_verticallayoutgroup icon";
        public const string defaultslate_icon = "defaultslate icon";
        public const string directionallight_gizmo = "directionallight gizmo";
        public const string directionallight_icon = "directionallight icon";
        public const string disclight_gizmo = "disclight gizmo";
        public const string disclight_icon = "disclight icon";
        public const string dll_script_icon = "dll script icon";
        public const string echofilter_icon = "echofilter icon";
        public const string favorite_icon = "favorite icon";
        public const string favorite_on_icon = "favorite on icon";
        public const string folder_icon = "folder icon";
        public const string folder_on_icon = "folder on icon";
        public const string folderempty_icon = "folderempty icon";
        public const string folderempty_on_icon = "folderempty on icon";
        public const string folderfavorite_icon = "folderfavorite icon";
        public const string folderfavorite_on_icon = "folderfavorite on icon";
        public const string folderopened_icon = "folderopened icon";
        public const string folderopened_on_icon = "folderopened on icon";
        public const string gamemanager_icon = "gamemanager icon";
        public const string gridbrush_icon = "gridbrush icon";
        public const string highpassfilter_icon = "highpassfilter icon";
        public const string horizontallayoutgroup_icon = "horizontallayoutgroup icon";
        public const string js_script_icon = "js script icon";
        public const string lensflare_gizmo = "lensflare gizmo";
        public const string lightingdataassetparent_icon = "lightingdataassetparent icon";
        public const string lightprobegroup_gizmo = "lightprobegroup gizmo";
        public const string lightprobeproxyvolume_gizmo = "lightprobeproxyvolume gizmo";
        public const string lowpassfilter_icon = "lowpassfilter icon";
        public const string main_light_gizmo = "main light gizmo";
        public const string metafile_icon = "metafile icon";
        public const string microphone_icon = "microphone icon";
        public const string muscleclip_icon = "muscleclip icon";
        public const string particlesystem_gizmo = "particlesystem gizmo";
        public const string particlesystemforcefield_gizmo = "particlesystemforcefield gizmo";
        public const string pointlight_gizmo = "pointlight gizmo";
        public const string prefab_icon = "prefab icon";
        public const string prefab_on_icon = "prefab on icon";
        public const string prefabmodel_icon = "prefabmodel icon";
        public const string prefabmodel_on_icon = "prefabmodel on icon";
        public const string prefaboverlayadded_icon = "prefaboverlayadded icon";
        public const string prefaboverlaymodified_icon = "prefaboverlaymodified icon";
        public const string prefaboverlayremoved_icon = "prefaboverlayremoved icon";
        public const string prefabvariant_icon = "prefabvariant icon";
        public const string prefabvariant_on_icon = "prefabvariant on icon";
        public const string projector_gizmo = "projector gizmo";
        public const string raycastcollider_icon = "raycastcollider icon";
        public const string reflectionprobe_gizmo = "reflectionprobe gizmo";
        public const string reverbfilter_icon = "reverbfilter icon";
        public const string sceneset_icon = "sceneset icon";
        public const string search_icon = "search icon";
        public const string search_on_icon = "search on icon";
        public const string searchjump_icon = "searchjump icon";
        public const string settings_icon = "settings icon";
        public const string shortcut_icon = "shortcut icon";
        public const string softlockprojectbrowser_icon = "softlockprojectbrowser icon";
        public const string speedtreemodel_icon = "speedtreemodel icon";
        public const string spotlight_gizmo = "spotlight gizmo";
        public const string spotlight_icon = "spotlight icon";
        public const string spritecollider_icon = "spritecollider icon";
        public const string sv_icon_dot0_pix16_gizmo = "sv_icon_dot0_pix16_gizmo";
        public const string sv_icon_dot10_pix16_gizmo = "sv_icon_dot10_pix16_gizmo";
        public const string sv_icon_dot11_pix16_gizmo = "sv_icon_dot11_pix16_gizmo";
        public const string sv_icon_dot12_pix16_gizmo = "sv_icon_dot12_pix16_gizmo";
        public const string sv_icon_dot13_pix16_gizmo = "sv_icon_dot13_pix16_gizmo";
        public const string sv_icon_dot14_pix16_gizmo = "sv_icon_dot14_pix16_gizmo";
        public const string sv_icon_dot15_pix16_gizmo = "sv_icon_dot15_pix16_gizmo";
        public const string sv_icon_dot1_pix16_gizmo = "sv_icon_dot1_pix16_gizmo";
        public const string sv_icon_dot2_pix16_gizmo = "sv_icon_dot2_pix16_gizmo";
        public const string sv_icon_dot3_pix16_gizmo = "sv_icon_dot3_pix16_gizmo";
        public const string sv_icon_dot4_pix16_gizmo = "sv_icon_dot4_pix16_gizmo";
        public const string sv_icon_dot5_pix16_gizmo = "sv_icon_dot5_pix16_gizmo";
        public const string sv_icon_dot6_pix16_gizmo = "sv_icon_dot6_pix16_gizmo";
        public const string sv_icon_dot7_pix16_gizmo = "sv_icon_dot7_pix16_gizmo";
        public const string sv_icon_dot8_pix16_gizmo = "sv_icon_dot8_pix16_gizmo";
        public const string sv_icon_dot9_pix16_gizmo = "sv_icon_dot9_pix16_gizmo";
        public const string animatorcontroller_icon = "animatorcontroller icon";
        public const string animatorcontroller_on_icon = "animatorcontroller on icon";
        public const string animatorstate_icon = "animatorstate icon";
        public const string animatorstatemachine_icon = "animatorstatemachine icon";
        public const string animatorstatetransition_icon = "animatorstatetransition icon";
        public const string blendtree_icon = "blendtree icon";
        public const string d_animatorcontroller_icon = "d_animatorcontroller icon";
        public const string d_animatorcontroller_on_icon = "d_animatorcontroller on icon";
        public const string d_animatorstate_icon = "d_animatorstate icon";
        public const string d_animatorstatemachine_icon = "d_animatorstatemachine icon";
        public const string d_animatorstatetransition_icon = "d_animatorstatetransition icon";
        public const string d_blendtree_icon = "d_blendtree icon";
        public const string animationwindowevent_icon = "animationwindowevent icon";
        public const string audiomixercontroller_icon = "audiomixercontroller icon";
        public const string audiomixercontroller_on_icon = "audiomixercontroller on icon";
        public const string d_audiomixercontroller_icon = "d_audiomixercontroller icon";
        public const string d_audiomixercontroller_on_icon = "d_audiomixercontroller on icon";
        public const string audioimporter_icon = "audioimporter icon";
        public const string d_audioimporter_icon = "d_audioimporter icon";
        public const string d_defaultasset_icon = "d_defaultasset icon";
        public const string d_filter_icon = "d_filter icon";
        public const string d_ihvimageformatimporter_icon = "d_ihvimageformatimporter icon";
        public const string d_lightingdataasset_icon = "d_lightingdataasset icon";
        public const string d_lightmapparameters_icon = "d_lightmapparameters icon";
        public const string d_lightmapparameters_on_icon = "d_lightmapparameters on icon";
        public const string d_modelimporter_icon = "d_modelimporter icon";
        public const string d_sceneasset_icon = "d_sceneasset icon";
        public const string d_shaderimporter_icon = "d_shaderimporter icon";
        public const string d_shaderinclude_icon = "d_shaderinclude icon";
        public const string d_textscriptimporter_icon = "d_textscriptimporter icon";
        public const string d_textureimporter_icon = "d_textureimporter icon";
        public const string d_truetypefontimporter_icon = "d_truetypefontimporter icon";
        public const string defaultasset_icon = "defaultasset icon";
        public const string editorsettings_icon = "editorsettings icon";
        public const string filter_icon = "filter icon";
        public const string anystatenode_icon = "anystatenode icon";
        public const string d_anystatenode_icon = "d_anystatenode icon";
        public const string humantemplate_icon = "humantemplate icon";
        public const string ihvimageformatimporter_icon = "ihvimageformatimporter icon";
        public const string lightingdataasset_icon = "lightingdataasset icon";
        public const string lightmapparameters_icon = "lightmapparameters icon";
        public const string lightmapparameters_on_icon = "lightmapparameters on icon";
        public const string modelimporter_icon = "modelimporter icon";
        public const string preset_icon = "preset icon";
        public const string sceneasset_icon = "sceneasset icon";
        public const string sceneasset_on_icon = "sceneasset on icon";
        public const string scenetemplateasset_icon = "scenetemplateasset icon";
        public const string d_searchdatabase_icon = "d_searchdatabase icon";
        public const string d_searchquery_icon = "d_searchquery icon";
        public const string d_searchqueryasset_icon = "d_searchqueryasset icon";
        public const string searchdatabase_icon = "searchdatabase icon";
        public const string searchquery_icon = "searchquery icon";
        public const string searchqueryasset_icon = "searchqueryasset icon";
        public const string shaderimporter_icon = "shaderimporter icon";
        public const string shaderinclude_icon = "shaderinclude icon";
        public const string speedtreeimporter_icon = "speedtreeimporter icon";
        public const string substancearchive_icon = "substancearchive icon";
        public const string textscriptimporter_icon = "textscriptimporter icon";
        public const string textureimporter_icon = "textureimporter icon";
        public const string truetypefontimporter_icon = "truetypefontimporter icon";
        public const string d_spriteatlasasset_icon = "d_spriteatlasasset icon";
        public const string d_spriteatlasimporter_icon = "d_spriteatlasimporter icon";
        public const string spriteatlasasset_icon = "spriteatlasasset icon";
        public const string spriteatlasimporter_icon = "spriteatlasimporter icon";
        public const string d_visualeffectsubgraphblock_icon = "d_visualeffectsubgraphblock icon";
        public const string d_visualeffectsubgraphoperator_icon = "d_visualeffectsubgraphoperator icon";
        public const string visualeffectsubgraphblock_icon = "visualeffectsubgraphblock icon";
        public const string visualeffectsubgraphoperator_icon = "visualeffectsubgraphoperator icon";
        public const string videoclipimporter_icon = "videoclipimporter icon";
        public const string assemblydefinitionasset_icon = "assemblydefinitionasset icon";
        public const string assemblydefinitionreferenceasset_icon = "assemblydefinitionreferenceasset icon";
        public const string d_assemblydefinitionasset_icon = "d_assemblydefinitionasset icon";
        public const string d_assemblydefinitionreferenceasset_icon = "d_assemblydefinitionreferenceasset icon";
        public const string d_navmeshagent_icon = "d_navmeshagent icon";
        public const string d_navmeshdata_icon = "d_navmeshdata icon";
        public const string d_navmeshobstacle_icon = "d_navmeshobstacle icon";
        public const string d_offmeshlink_icon = "d_offmeshlink icon";
        public const string navmeshagent_icon = "navmeshagent icon";
        public const string navmeshdata_icon = "navmeshdata icon";
        public const string navmeshobstacle_icon = "navmeshobstacle icon";
        public const string offmeshlink_icon = "offmeshlink icon";
        public const string analyticstracker_icon = "analyticstracker icon";
        public const string d_analyticstracker_icon = "d_analyticstracker icon";
        public const string animation_icon = "animation icon";
        public const string animationclip_icon = "animationclip icon";
        public const string animationclip_on_icon = "animationclip on icon";
        public const string aimconstraint_icon = "aimconstraint icon";
        public const string d_aimconstraint_icon = "d_aimconstraint icon";
        public const string d_lookatconstraint_icon = "d_lookatconstraint icon";
        public const string d_parentconstraint_icon = "d_parentconstraint icon";
        public const string d_positionconstraint_icon = "d_positionconstraint icon";
        public const string d_rotationconstraint_icon = "d_rotationconstraint icon";
        public const string d_scaleconstraint_icon = "d_scaleconstraint icon";
        public const string lookatconstraint_icon = "lookatconstraint icon";
        public const string parentconstraint_icon = "parentconstraint icon";
        public const string positionconstraint_icon = "positionconstraint icon";
        public const string rotationconstraint_icon = "rotationconstraint icon";
        public const string scaleconstraint_icon = "scaleconstraint icon";
        public const string animator_icon = "animator icon";
        public const string animatoroverridecontroller_icon = "animatoroverridecontroller icon";
        public const string animatoroverridecontroller_on_icon = "animatoroverridecontroller on icon";
        public const string areaeffector2d_icon = "areaeffector2d icon";
        public const string articulationbody_icon = "articulationbody icon";
        public const string audiomixergroup_icon = "audiomixergroup icon";
        public const string audiomixersnapshot_icon = "audiomixersnapshot icon";
        public const string audiospatializermicrosoft_icon = "audiospatializermicrosoft icon";
        public const string d_audiomixergroup_icon = "d_audiomixergroup icon";
        public const string d_audiomixersnapshot_icon = "d_audiomixersnapshot icon";
        public const string d_audiospatializermicrosoft_icon = "d_audiospatializermicrosoft icon";
        public const string audiochorusfilter_icon = "audiochorusfilter icon";
        public const string audioclip_icon = "audioclip icon";
        public const string audioclip_on_icon = "audioclip on icon";
        public const string audiodistortionfilter_icon = "audiodistortionfilter icon";
        public const string audioechofilter_icon = "audioechofilter icon";
        public const string audiohighpassfilter_icon = "audiohighpassfilter icon";
        public const string audiolistener_icon = "audiolistener icon";
        public const string audiolowpassfilter_icon = "audiolowpassfilter icon";
        public const string audioreverbfilter_icon = "audioreverbfilter icon";
        public const string audioreverbzone_icon = "audioreverbzone icon";
        public const string audiosource_icon = "audiosource icon";
        public const string avatar_icon = "avatar icon";
        public const string avatarmask_icon = "avatarmask icon";
        public const string avatarmask_on_icon = "avatarmask on icon";
        public const string billboardasset_icon = "billboardasset icon";
        public const string billboardrenderer_icon = "billboardrenderer icon";
        public const string boxcollider_icon = "boxcollider icon";
        public const string boxcollider2d_icon = "boxcollider2d icon";
        public const string buoyancyeffector2d_icon = "buoyancyeffector2d icon";
        public const string camera_icon = "camera icon";
        public const string canvas_icon = "canvas icon";
        public const string canvasgroup_icon = "canvasgroup icon";
        public const string canvasrenderer_icon = "canvasrenderer icon";
        public const string capsulecollider_icon = "capsulecollider icon";
        public const string capsulecollider2d_icon = "capsulecollider2d icon";
        public const string charactercontroller_icon = "charactercontroller icon";
        public const string characterjoint_icon = "characterjoint icon";
        public const string circlecollider2d_icon = "circlecollider2d icon";
        public const string cloth_icon = "cloth icon";
        public const string compositecollider2d_icon = "compositecollider2d icon";
        public const string computeshader_icon = "computeshader icon";
        public const string configurablejoint_icon = "configurablejoint icon";
        public const string constantforce_icon = "constantforce icon";
        public const string constantforce2d_icon = "constantforce2d icon";
        public const string cubemap_icon = "cubemap icon";
        public const string customcollider2d_icon = "customcollider2d icon";
        public const string d_animation_icon = "d_animation icon";
        public const string d_animationclip_icon = "d_animationclip icon";
        public const string d_animationclip_on_icon = "d_animationclip on icon";
        public const string d_animator_icon = "d_animator icon";
        public const string d_animatoroverridecontroller_icon = "d_animatoroverridecontroller icon";
        public const string d_animatoroverridecontroller_on_icon = "d_animatoroverridecontroller on icon";
        public const string d_areaeffector2d_icon = "d_areaeffector2d icon";
        public const string d_articulationbody_icon = "d_articulationbody icon";
        public const string d_audiochorusfilter_icon = "d_audiochorusfilter icon";
        public const string d_audioclip_icon = "d_audioclip icon";
        public const string d_audioclip_on_icon = "d_audioclip on icon";
        public const string d_audiodistortionfilter_icon = "d_audiodistortionfilter icon";
        public const string d_audioechofilter_icon = "d_audioechofilter icon";
        public const string d_audiohighpassfilter_icon = "d_audiohighpassfilter icon";
        public const string d_audiolistener_icon = "d_audiolistener icon";
        public const string d_audiolowpassfilter_icon = "d_audiolowpassfilter icon";
        public const string d_audioreverbfilter_icon = "d_audioreverbfilter icon";
        public const string d_audioreverbzone_icon = "d_audioreverbzone icon";
        public const string d_audiosource_icon = "d_audiosource icon";
        public const string d_avatar_icon = "d_avatar icon";
        public const string d_avatarmask_icon = "d_avatarmask icon";
        public const string d_avatarmask_on_icon = "d_avatarmask on icon";
        public const string d_billboardasset_icon = "d_billboardasset icon";
        public const string d_billboardrenderer_icon = "d_billboardrenderer icon";
        public const string d_boxcollider_icon = "d_boxcollider icon";
        public const string d_boxcollider2d_icon = "d_boxcollider2d icon";
        public const string d_buoyancyeffector2d_icon = "d_buoyancyeffector2d icon";
        public const string d_camera_icon = "d_camera icon";
        public const string d_canvas_icon = "d_canvas icon";
        public const string d_canvasgroup_icon = "d_canvasgroup icon";
        public const string d_canvasrenderer_icon = "d_canvasrenderer icon";
        public const string d_capsulecollider_icon = "d_capsulecollider icon";
        public const string d_capsulecollider2d_icon = "d_capsulecollider2d icon";
        public const string d_charactercontroller_icon = "d_charactercontroller icon";
        public const string d_characterjoint_icon = "d_characterjoint icon";
        public const string d_circlecollider2d_icon = "d_circlecollider2d icon";
        public const string d_cloth_icon = "d_cloth icon";
        public const string d_compositecollider2d_icon = "d_compositecollider2d icon";
        public const string d_computeshader_icon = "d_computeshader icon";
        public const string d_configurablejoint_icon = "d_configurablejoint icon";
        public const string d_constantforce_icon = "d_constantforce icon";
        public const string d_constantforce2d_icon = "d_constantforce2d icon";
        public const string d_cubemap_icon = "d_cubemap icon";
        public const string d_distancejoint2d_icon = "d_distancejoint2d icon";
        public const string d_edgecollider2d_icon = "d_edgecollider2d icon";
        public const string d_fixedjoint_icon = "d_fixedjoint icon";
        public const string d_flare_icon = "d_flare icon";
        public const string d_flare_on_icon = "d_flare on icon";
        public const string d_flarelayer_icon = "d_flarelayer icon";
        public const string d_font_icon = "d_font icon";
        public const string d_font_on_icon = "d_font on icon";
        public const string d_frictionjoint2d_icon = "d_frictionjoint2d icon";
        public const string d_gameobject_icon = "d_gameobject icon";
        public const string d_grid_icon = "d_grid icon";
        public const string d_guiskin_icon = "d_guiskin icon";
        public const string d_guiskin_on_icon = "d_guiskin on icon";
        public const string d_halo_icon = "d_halo icon";
        public const string d_hingejoint_icon = "d_hingejoint icon";
        public const string d_hingejoint2d_icon = "d_hingejoint2d icon";
        public const string d_light_icon = "d_light icon";
        public const string d_lightingsettings_icon = "d_lightingsettings icon";
        public const string d_lightprobegroup_icon = "d_lightprobegroup icon";
        public const string d_lightprobeproxyvolume_icon = "d_lightprobeproxyvolume icon";
        public const string d_lightprobes_icon = "d_lightprobes icon";
        public const string d_linerenderer_icon = "d_linerenderer icon";
        public const string d_lodgroup_icon = "d_lodgroup icon";
        public const string d_material_icon = "d_material icon";
        public const string d_material_on_icon = "d_material on icon";
        public const string d_mesh_icon = "d_mesh icon";
        public const string d_meshcollider_icon = "d_meshcollider icon";
        public const string d_meshfilter_icon = "d_meshfilter icon";
        public const string d_meshrenderer_icon = "d_meshrenderer icon";
        public const string d_motion_icon = "d_motion icon";
        public const string d_occlusionarea_icon = "d_occlusionarea icon";
        public const string d_occlusionportal_icon = "d_occlusionportal icon";
        public const string d_particlesystem_icon = "d_particlesystem icon";
        public const string d_particlesystemforcefield_icon = "d_particlesystemforcefield icon";
        public const string d_physicmaterial_icon = "d_physicmaterial icon";
        public const string d_physicmaterial_on_icon = "d_physicmaterial on icon";
        public const string d_physicsmaterial2d_icon = "d_physicsmaterial2d icon";
        public const string d_physicsmaterial2d_on_icon = "d_physicsmaterial2d on icon";
        public const string d_platformeffector2d_icon = "d_platformeffector2d icon";
        public const string d_pointeffector2d_icon = "d_pointeffector2d icon";
        public const string d_polygoncollider2d_icon = "d_polygoncollider2d icon";
        public const string d_proceduralmaterial_icon = "d_proceduralmaterial icon";
        public const string d_projector_icon = "d_projector icon";
        public const string d_raytracingshader_icon = "d_raytracingshader icon";
        public const string d_recttransform_icon = "d_recttransform icon";
        public const string d_reflectionprobe_icon = "d_reflectionprobe icon";
        public const string d_relativejoint2d_icon = "d_relativejoint2d icon";
        public const string d_rendertexture_icon = "d_rendertexture icon";
        public const string d_rendertexture_on_icon = "d_rendertexture on icon";
        public const string d_rigidbody_icon = "d_rigidbody icon";
        public const string d_rigidbody2d_icon = "d_rigidbody2d icon";
        public const string d_scriptableobject_icon = "d_scriptableobject icon";
        public const string d_scriptableobject_on_icon = "d_scriptableobject on icon";
        public const string d_shader_icon = "d_shader icon";
        public const string d_shadervariantcollection_icon = "d_shadervariantcollection icon";
        public const string d_skinnedmeshrenderer_icon = "d_skinnedmeshrenderer icon";
        public const string d_skybox_icon = "d_skybox icon";
        public const string d_sliderjoint2d_icon = "d_sliderjoint2d icon";
        public const string d_spherecollider_icon = "d_spherecollider icon";
        public const string d_springjoint_icon = "d_springjoint icon";
        public const string d_springjoint2d_icon = "d_springjoint2d icon";
        public const string d_sprite_icon = "d_sprite icon";
        public const string d_spritemask_icon = "d_spritemask icon";
        public const string d_spriterenderer_icon = "d_spriterenderer icon";
        public const string d_streamingcontroller_icon = "d_streamingcontroller icon";
        public const string d_surfaceeffector2d_icon = "d_surfaceeffector2d icon";
        public const string d_targetjoint2d_icon = "d_targetjoint2d icon";
        public const string d_terrain_icon = "d_terrain icon";
        public const string d_terraincollider_icon = "d_terraincollider icon";
        public const string d_terraindata_icon = "d_terraindata icon";
        public const string d_textasset_icon = "d_textasset icon";
        public const string d_texture_icon = "d_texture icon";
        public const string d_texture2d_icon = "d_texture2d icon";
        public const string d_trailrenderer_icon = "d_trailrenderer icon";
        public const string d_transform_icon = "d_transform icon";
        public const string d_wheelcollider_icon = "d_wheelcollider icon";
        public const string d_wheeljoint2d_icon = "d_wheeljoint2d icon";
        public const string d_windzone_icon = "d_windzone icon";
        public const string distancejoint2d_icon = "distancejoint2d icon";
        public const string edgecollider2d_icon = "edgecollider2d icon";
        public const string d_eventsystem_icon = "d_eventsystem icon";
        public const string d_eventtrigger_icon = "d_eventtrigger icon";
        public const string d_hololensinputmodule_icon = "d_hololensinputmodule icon";
        public const string d_physics2draycaster_icon = "d_physics2draycaster icon";
        public const string d_physicsraycaster_icon = "d_physicsraycaster icon";
        public const string d_standaloneinputmodule_icon = "d_standaloneinputmodule icon";
        public const string d_touchinputmodule_icon = "d_touchinputmodule icon";
        public const string eventsystem_icon = "eventsystem icon";
        public const string eventtrigger_icon = "eventtrigger icon";
        public const string hololensinputmodule_icon = "hololensinputmodule icon";
        public const string physics2draycaster_icon = "physics2draycaster icon";
        public const string physicsraycaster_icon = "physicsraycaster icon";
        public const string standaloneinputmodule_icon = "standaloneinputmodule icon";
        public const string touchinputmodule_icon = "touchinputmodule icon";
        public const string raytracingshader_icon = "raytracingshader icon";
        public const string fixedjoint_icon = "fixedjoint icon";
        public const string fixedjoint2d_icon = "fixedjoint2d icon";
        public const string flare_icon = "flare icon";
        public const string flare_on_icon = "flare on icon";
        public const string flarelayer_icon = "flarelayer icon";
        public const string font_icon = "font icon";
        public const string font_on_icon = "font on icon";
        public const string frictionjoint2d_icon = "frictionjoint2d icon";
        public const string gameobject_icon = "gameobject icon";
        public const string gameobject_on_icon = "gameobject on icon";
        public const string grid_icon = "grid icon";
        public const string guilayer_icon = "guilayer icon";
        public const string guiskin_icon = "guiskin icon";
        public const string guiskin_on_icon = "guiskin on icon";
        public const string guitext_icon = "guitext icon";
        public const string guitexture_icon = "guitexture icon";
        public const string halo_icon = "halo icon";
        public const string hingejoint_icon = "hingejoint icon";
        public const string hingejoint2d_icon = "hingejoint2d icon";
        public const string lensflare_icon = "lensflare icon";
        public const string light_icon = "light icon";
        public const string lightingsettings_icon = "lightingsettings icon";
        public const string lightprobegroup_icon = "lightprobegroup icon";
        public const string lightprobeproxyvolume_icon = "lightprobeproxyvolume icon";
        public const string lightprobes_icon = "lightprobes icon";
        public const string linerenderer_icon = "linerenderer icon";
        public const string lodgroup_icon = "lodgroup icon";
        public const string material_icon = "material icon";
        public const string material_on_icon = "material on icon";
        public const string mesh_icon = "mesh icon";
        public const string meshcollider_icon = "meshcollider icon";
        public const string meshfilter_icon = "meshfilter icon";
        public const string meshrenderer_icon = "meshrenderer icon";
        public const string motion_icon = "motion icon";
        public const string movietexture_icon = "movietexture icon";
        public const string d_networkanimator_icon = "d_networkanimator icon";
        public const string d_networkdiscovery_icon = "d_networkdiscovery icon";
        public const string d_networkidentity_icon = "d_networkidentity icon";
        public const string d_networklobbymanager_icon = "d_networklobbymanager icon";
        public const string d_networklobbyplayer_icon = "d_networklobbyplayer icon";
        public const string d_networkmanager_icon = "d_networkmanager icon";
        public const string d_networkmanagerhud_icon = "d_networkmanagerhud icon";
        public const string d_networkmigrationmanager_icon = "d_networkmigrationmanager icon";
        public const string d_networkproximitychecker_icon = "d_networkproximitychecker icon";
        public const string d_networkstartposition_icon = "d_networkstartposition icon";
        public const string d_networktransform_icon = "d_networktransform icon";
        public const string d_networktransformchild_icon = "d_networktransformchild icon";
        public const string d_networktransformvisualizer_icon = "d_networktransformvisualizer icon";
        public const string networkanimator_icon = "networkanimator icon";
        public const string networkdiscovery_icon = "networkdiscovery icon";
        public const string networkidentity_icon = "networkidentity icon";
        public const string networklobbymanager_icon = "networklobbymanager icon";
        public const string networklobbyplayer_icon = "networklobbyplayer icon";
        public const string networkmanager_icon = "networkmanager icon";
        public const string networkmanagerhud_icon = "networkmanagerhud icon";
        public const string networkmigrationmanager_icon = "networkmigrationmanager icon";
        public const string networkproximitychecker_icon = "networkproximitychecker icon";
        public const string networkstartposition_icon = "networkstartposition icon";
        public const string networktransform_icon = "networktransform icon";
        public const string networktransformchild_icon = "networktransformchild icon";
        public const string networktransformvisualizer_icon = "networktransformvisualizer icon";
        public const string networkview_icon = "networkview icon";
        public const string occlusionarea_icon = "occlusionarea icon";
        public const string occlusionportal_icon = "occlusionportal icon";
        public const string particlesystem_icon = "particlesystem icon";
        public const string particlesystemforcefield_icon = "particlesystemforcefield icon";
        public const string physicmaterial_icon = "physicmaterial icon";
        public const string physicmaterial_on_icon = "physicmaterial on icon";
        public const string physicsmaterial2d_icon = "physicsmaterial2d icon";
        public const string physicsmaterial2d_on_icon = "physicsmaterial2d on icon";
        public const string platformeffector2d_icon = "platformeffector2d icon";
        public const string d_playabledirector_icon = "d_playabledirector icon";
        public const string playabledirector_icon = "playabledirector icon";
        public const string pointeffector2d_icon = "pointeffector2d icon";
        public const string polygoncollider2d_icon = "polygoncollider2d icon";
        public const string proceduralmaterial_icon = "proceduralmaterial icon";
        public const string projector_icon = "projector icon";
        public const string recttransform_icon = "recttransform icon";
        public const string reflectionprobe_icon = "reflectionprobe icon";
        public const string relativejoint2d_icon = "relativejoint2d icon";
        public const string d_sortinggroup_icon = "d_sortinggroup icon";
        public const string sortinggroup_icon = "sortinggroup icon";
        public const string rendertexture_icon = "rendertexture icon";
        public const string rendertexture_on_icon = "rendertexture on icon";
        public const string rigidbody_icon = "rigidbody icon";
        public const string rigidbody2d_icon = "rigidbody2d icon";
        public const string scriptableobject_icon = "scriptableobject icon";
        public const string scriptableobject_on_icon = "scriptableobject on icon";
        public const string shader_icon = "shader icon";
        public const string shadervariantcollection_icon = "shadervariantcollection icon";
        public const string skinnedmeshrenderer_icon = "skinnedmeshrenderer icon";
        public const string skybox_icon = "skybox icon";
        public const string sliderjoint2d_icon = "sliderjoint2d icon";
        public const string trackedposedriver_icon = "trackedposedriver icon";
        public const string spherecollider_icon = "spherecollider icon";
        public const string springjoint_icon = "springjoint icon";
        public const string springjoint2d_icon = "springjoint2d icon";
        public const string sprite_icon = "sprite icon";
        public const string spritemask_icon = "spritemask icon";
        public const string spriterenderer_icon = "spriterenderer icon";
        public const string streamingcontroller_icon = "streamingcontroller icon";
        public const string surfaceeffector2d_icon = "surfaceeffector2d icon";
        public const string targetjoint2d_icon = "targetjoint2d icon";
        public const string terrain_icon = "terrain icon";
        public const string terraincollider_icon = "terraincollider icon";
        public const string terraindata_icon = "terraindata icon";
        public const string textasset_icon = "textasset icon";
        public const string textmesh_icon = "textmesh icon";
        public const string texture_icon = "texture icon";
        public const string texture2d_icon = "texture2d icon";
        public const string d_tile_icon = "d_tile icon";
        public const string d_tilemap_icon = "d_tilemap icon";
        public const string d_tilemapcollider2d_icon = "d_tilemapcollider2d icon";
        public const string d_tilemaprenderer_icon = "d_tilemaprenderer icon";
        public const string tile_icon = "tile icon";
        public const string tilemap_icon = "tilemap icon";
        public const string tilemapcollider2d_icon = "tilemapcollider2d icon";
        public const string tilemaprenderer_icon = "tilemaprenderer icon";
        public const string d_signalasset_icon = "d_signalasset icon";
        public const string d_signalemitter_icon = "d_signalemitter icon";
        public const string d_signalreceiver_icon = "d_signalreceiver icon";
        public const string d_timelineasset_icon = "d_timelineasset icon";
        public const string d_timelineasset_on_icon = "d_timelineasset on icon";
        public const string signalasset_icon = "signalasset icon";
        public const string signalemitter_icon = "signalemitter icon";
        public const string signalreceiver_icon = "signalreceiver icon";
        public const string timelineasset_icon = "timelineasset icon";
        public const string timelineasset_on_icon = "timelineasset on icon";
        public const string trailrenderer_icon = "trailrenderer icon";
        public const string transform_icon = "transform icon";
        public const string tree_icon = "tree icon";
        public const string d_spriteatlas_icon = "d_spriteatlas icon";
        public const string d_spriteatlas_on_icon = "d_spriteatlas on icon";
        public const string d_spriteshaperenderer_icon = "d_spriteshaperenderer icon";
        public const string spriteatlas_icon = "spriteatlas icon";
        public const string spriteatlas_on_icon = "spriteatlas on icon";
        public const string spriteshaperenderer_icon = "spriteshaperenderer icon";
        public const string aspectratiofitter_icon = "aspectratiofitter icon";
        public const string button_icon = "button icon";
        public const string canvasscaler_icon = "canvasscaler icon";
        public const string contentsizefitter_icon = "contentsizefitter icon";
        public const string d_aspectratiofitter_icon = "d_aspectratiofitter icon";
        public const string d_button_icon = "d_button icon";
        public const string d_canvasscaler_icon = "d_canvasscaler icon";
        public const string d_contentsizefitter_icon = "d_contentsizefitter icon";
        public const string d_dropdown_icon = "d_dropdown icon";
        public const string d_freeformlayoutgroup_icon = "d_freeformlayoutgroup icon";
        public const string d_graphicraycaster_icon = "d_graphicraycaster icon";
        public const string d_image_icon = "d_image icon";
        public const string d_inputfield_icon = "d_inputfield icon";
        public const string d_layoutelement_icon = "d_layoutelement icon";
        public const string d_mask_icon = "d_mask icon";
        public const string d_outline_icon = "d_outline icon";
        public const string d_physicalresolution_icon = "d_physicalresolution icon";
        public const string d_positionasuv1_icon = "d_positionasuv1 icon";
        public const string d_rawimage_icon = "d_rawimage icon";
        public const string d_rectmask2d_icon = "d_rectmask2d icon";
        public const string d_scrollbar_icon = "d_scrollbar icon";
        public const string d_scrollrect_icon = "d_scrollrect icon";
        public const string d_scrollviewarea_icon = "d_scrollviewarea icon";
        public const string d_selectable_icon = "d_selectable icon";
        public const string d_selectionlist_icon = "d_selectionlist icon";
        public const string d_selectionlistitem_icon = "d_selectionlistitem icon";
        public const string d_selectionlisttemplate_icon = "d_selectionlisttemplate icon";
        public const string d_shadow_icon = "d_shadow icon";
        public const string d_slider_icon = "d_slider icon";
        public const string d_text_icon = "d_text icon";
        public const string d_toggle_icon = "d_toggle icon";
        public const string d_togglegroup_icon = "d_togglegroup icon";
        public const string dropdown_icon = "dropdown icon";
        public const string freeformlayoutgroup_icon = "freeformlayoutgroup icon";
        public const string graphicraycaster_icon = "graphicraycaster icon";
        public const string gridlayoutgroup_icon = "gridlayoutgroup icon";
        public const string image_icon = "image icon";
        public const string inputfield_icon = "inputfield icon";
        public const string layoutelement_icon = "layoutelement icon";
        public const string mask_icon = "mask icon";
        public const string outline_icon = "outline icon";
        public const string positionasuv1_icon = "positionasuv1 icon";
        public const string rawimage_icon = "rawimage icon";
        public const string rectmask2d_icon = "rectmask2d icon";
        public const string scrollbar_icon = "scrollbar icon";
        public const string scrollrect_icon = "scrollrect icon";
        public const string selectable_icon = "selectable icon";
        public const string shadow_icon = "shadow icon";
        public const string slider_icon = "slider icon";
        public const string text_icon = "text icon";
        public const string toggle_icon = "toggle icon";
        public const string togglegroup_icon = "togglegroup icon";
        public const string verticallayoutgroup_icon = "verticallayoutgroup icon";
        public const string d_panelsettings_icon = "d_panelsettings icon";
        public const string d_panelsettings_on_icon = "d_panelsettings on icon";
        public const string d_stylesheet_icon = "d_stylesheet icon";
        public const string d_uidocument_icon = "d_uidocument icon";
        public const string d_visualtreeasset_icon = "d_visualtreeasset icon";
        public const string panelsettings_icon = "panelsettings icon";
        public const string panelsettings_on_icon = "panelsettings on icon";
        public const string stylesheet_icon = "stylesheet icon";
        public const string uidocument_icon = "uidocument icon";
        public const string visualtreeasset_icon = "visualtreeasset icon";
        public const string d_visualeffect_icon = "d_visualeffect icon";
        public const string d_visualeffectasset_icon = "d_visualeffectasset icon";
        public const string visualeffect_icon = "visualeffect icon";
        public const string visualeffectasset_icon = "visualeffectasset icon";
        public const string d_videoplayer_icon = "d_videoplayer icon";
        public const string videoclip_icon = "videoclip icon";
        public const string videoplayer_icon = "videoplayer icon";
        public const string wheelcollider_icon = "wheelcollider icon";
        public const string wheeljoint2d_icon = "wheeljoint2d icon";
        public const string windzone_icon = "windzone icon";
        public const string d_spatialmappingcollider_icon = "d_spatialmappingcollider icon";
        public const string spatialmappingcollider_icon = "spatialmappingcollider icon";
        public const string spatialmappingrenderer_icon = "spatialmappingrenderer icon";
        public const string worldanchor_icon = "worldanchor icon";
        public const string ussscript_icon = "ussscript icon";
        public const string uxmlscript_icon = "uxmlscript icon";
        public const string videoeffect_icon = "videoeffect icon";
        public const string visualeffect_gizmo = "visualeffect gizmo";
        public const string windzone_gizmo = "windzone gizmo";
        public const string profiler_audio = "profiler.audio";
        public const string profiler_cpu = "profiler.cpu";
        public const string profiler_custom = "profiler.custom";
        public const string profiler_firstframe = "profiler.firstframe";
        public const string profiler_globalillumination = "profiler.globalillumination";
        public const string profiler_gpu = "profiler.gpu";
        public const string profiler_instrumentation = "profiler.instrumentation";
        public const string profiler_lastframe = "profiler.lastframe";
        public const string profiler_memory = "profiler.memory";
        public const string profiler_networkmessages = "profiler.networkmessages";
        public const string profiler_networkoperations = "profiler.networkoperations";
        public const string profiler_nextframe = "profiler.nextframe";
        public const string profiler_open = "profiler.open";
        public const string profiler_physics = "profiler.physics";
        public const string profiler_physics2d = "profiler.physics2d";
        public const string profiler_prevframe = "profiler.prevframe";
        public const string profiler_record = "profiler.record";
        public const string profiler_rendering = "profiler.rendering";
        public const string profiler_ui = "profiler.ui";
        public const string profiler_uidetails = "profiler.uidetails";
        public const string profiler_video = "profiler.video";
        public const string profiler_virtualtexturing = "profiler.virtualtexturing";
        public const string profilercolumn_warningcount = "profilercolumn.warningcount";
        public const string progress = "progress";
        public const string project = "project";
        public const string d_dragarrow = "d_dragarrow";
        public const string d_gridview_on = "d_gridview on";
        public const string d_gridview = "d_gridview";
        public const string d_help = "d_help";
        public const string d_listview_on = "d_listview on";
        public const string d_listview = "d_listview";
        public const string d_more = "d_more";
        public const string d_searchwindow = "d_searchwindow";
        public const string d_syncsearch_on = "d_syncsearch on";
        public const string d_syncsearch = "d_syncsearch";
        public const string d_tableview_on = "d_tableview on";
        public const string d_tableview = "d_tableview";
        public const string dragarrow = "dragarrow";
        public const string gridview_on = "gridview on";
        public const string gridview = "gridview";
        public const string help = "help";
        public const string listview_on = "listview on";
        public const string listview = "listview";
        public const string more = "more";
        public const string package_installed = "package_installed";
        public const string package_update = "package_update";
        public const string searchwindow = "searchwindow";
        public const string syncsearch_on = "syncsearch on";
        public const string syncsearch = "syncsearch";
        public const string tableview_on = "tableview on";
        public const string tableview = "tableview";
        public const string record_off = "record off";
        public const string record_on = "record on";
        public const string recttool_on = "recttool on";
        public const string recttool = "recttool";
        public const string recttransformblueprint = "recttransformblueprint";
        public const string recttransformraw = "recttransformraw";
        public const string redgroove = "redgroove";
        public const string reflectionprobeselector = "reflectionprobeselector";
        public const string repaintdot = "repaintdot";
        public const string rightbracket = "rightbracket";
        public const string rotatetool_on = "rotatetool on";
        public const string rotatetool = "rotatetool";
        public const string saveactive = "saveactive";
        public const string saveas = "saveas";
        public const string savefromplay = "savefromplay";
        public const string savepassive = "savepassive";
        public const string scaletool_on = "scaletool on";
        public const string scaletool = "scaletool";
        public const string sceneloadin = "sceneloadin";
        public const string sceneloadout = "sceneloadout";
        public const string scenepicking_notpickable_mixed = "scenepicking_notpickable-mixed";
        public const string scenepicking_notpickable_mixed_hover = "scenepicking_notpickable-mixed_hover";
        public const string scenepicking_notpickable = "scenepicking_notpickable";
        public const string scenepicking_notpickable_hover = "scenepicking_notpickable_hover";
        public const string scenepicking_pickable_mixed = "scenepicking_pickable-mixed";
        public const string scenepicking_pickable_mixed_hover = "scenepicking_pickable-mixed_hover";
        public const string scenepicking_pickable = "scenepicking_pickable";
        public const string scenepicking_pickable_hover = "scenepicking_pickable_hover";
        public const string scenesave = "scenesave";
        public const string scenesavegrey = "scenesavegrey";
        public const string pin = "pin";
        public const string pinned = "pinned";
        public const string scene_template_2d_scene = "scene-template-2d-scene";
        public const string scene_template_3d_scene = "scene-template-3d-scene";
        public const string scene_template_dark = "scene-template-dark";
        public const string scene_template_default_scene = "scene-template-default-scene";
        public const string scene_template_empty_scene = "scene-template-empty-scene";
        public const string scene_template_light = "scene-template-light";
        public const string scene_template = "scene-template";
        public const string sceneview2d_on = "sceneview2d on";
        public const string sceneview2d = "sceneview2d";
        public const string sceneviewalpha = "sceneviewalpha";
        public const string sceneviewaudio_on = "sceneviewaudio on";
        public const string sceneviewaudio = "sceneviewaudio";
        public const string sceneviewcamera_on = "sceneviewcamera on";
        public const string sceneviewcamera = "sceneviewcamera";
        public const string sceneviewfx_on = "sceneviewfx on";
        public const string sceneviewfx = "sceneviewfx";
        public const string sceneviewlighting_on = "sceneviewlighting on";
        public const string sceneviewlighting = "sceneviewlighting";
        public const string sceneviewortho = "sceneviewortho";
        public const string sceneviewrgb = "sceneviewrgb";
        public const string sceneviewtools_on = "sceneviewtools on";
        public const string sceneviewtools = "sceneviewtools";
        public const string sceneviewvisibility_on = "sceneviewvisibility on";
        public const string sceneviewvisibility = "sceneviewvisibility";
        public const string scenevis_hidden_mixed = "scenevis_hidden-mixed";
        public const string scenevis_hidden_mixed_hover = "scenevis_hidden-mixed_hover";
        public const string scenevis_hidden = "scenevis_hidden";
        public const string scenevis_hidden_hover = "scenevis_hidden_hover";
        public const string scenevis_scene_hover = "scenevis_scene_hover";
        public const string scenevis_visible_mixed = "scenevis_visible-mixed";
        public const string scenevis_visible_mixed_hover = "scenevis_visible-mixed_hover";
        public const string scenevis_visible = "scenevis_visible";
        public const string scenevis_visible_hover = "scenevis_visible_hover";
        public const string scrollshadow = "scrollshadow";
        public const string settings = "settings";
        public const string settingsicon = "settingsicon";
        public const string alertdialog = "alertdialog";
        public const string conflict_icon = "conflict-icon";
        public const string showpanels = "showpanels";
        public const string d_gridaxisx_on = "d_gridaxisx on";
        public const string d_gridaxisx = "d_gridaxisx";
        public const string d_gridaxisy_on = "d_gridaxisy on";
        public const string d_gridaxisy = "d_gridaxisy";
        public const string d_gridaxisz_on = "d_gridaxisz on";
        public const string d_gridaxisz = "d_gridaxisz";
        public const string d_sceneviewsnap_on = "d_sceneviewsnap on";
        public const string d_sceneviewsnap = "d_sceneviewsnap";
        public const string d_snapincrement = "d_snapincrement";
        public const string gridaxisx_on = "gridaxisx on";
        public const string gridaxisx = "gridaxisx";
        public const string gridaxisy_on = "gridaxisy on";
        public const string gridaxisy = "gridaxisy";
        public const string gridaxisz_on = "gridaxisz on";
        public const string gridaxisz = "gridaxisz";
        public const string sceneviewsnap_on = "sceneviewsnap on";
        public const string sceneviewsnap = "sceneviewsnap";
        public const string snapincrement = "snapincrement";
        public const string socialnetworks_facebookshare = "socialnetworks.facebookshare";
        public const string socialnetworks_linkedinshare = "socialnetworks.linkedinshare";
        public const string socialnetworks_tweet = "socialnetworks.tweet";
        public const string socialnetworks_udnlogo = "socialnetworks.udnlogo";
        public const string socialnetworks_udnopen = "socialnetworks.udnopen";
        public const string softlockinline = "softlockinline";
        public const string speedscale = "speedscale";
        public const string statemachineeditor_arrowtip = "statemachineeditor.arrowtip";
        public const string statemachineeditor_arrowtipselected = "statemachineeditor.arrowtipselected";
        public const string statemachineeditor_background = "statemachineeditor.background";
        public const string statemachineeditor_state = "statemachineeditor.state";
        public const string statemachineeditor_statehover = "statemachineeditor.statehover";
        public const string statemachineeditor_stateselected = "statemachineeditor.stateselected";
        public const string statemachineeditor_statesub = "statemachineeditor.statesub";
        public const string statemachineeditor_statesubhover = "statemachineeditor.statesubhover";
        public const string statemachineeditor_statesubselected = "statemachineeditor.statesubselected";
        public const string statemachineeditor_upbutton = "statemachineeditor.upbutton";
        public const string statemachineeditor_upbuttonhover = "statemachineeditor.upbuttonhover";
        public const string stepbutton_on = "stepbutton on";
        public const string stepbutton = "stepbutton";
        public const string stepleftbutton_on = "stepleftbutton-on";
        public const string stepleftbutton = "stepleftbutton";
        public const string sv_icon_dot0_sml = "sv_icon_dot0_sml";
        public const string sv_icon_dot10_sml = "sv_icon_dot10_sml";
        public const string sv_icon_dot11_sml = "sv_icon_dot11_sml";
        public const string sv_icon_dot12_sml = "sv_icon_dot12_sml";
        public const string sv_icon_dot13_sml = "sv_icon_dot13_sml";
        public const string sv_icon_dot14_sml = "sv_icon_dot14_sml";
        public const string sv_icon_dot15_sml = "sv_icon_dot15_sml";
        public const string sv_icon_dot1_sml = "sv_icon_dot1_sml";
        public const string sv_icon_dot2_sml = "sv_icon_dot2_sml";
        public const string sv_icon_dot3_sml = "sv_icon_dot3_sml";
        public const string sv_icon_dot4_sml = "sv_icon_dot4_sml";
        public const string sv_icon_dot5_sml = "sv_icon_dot5_sml";
        public const string sv_icon_dot6_sml = "sv_icon_dot6_sml";
        public const string sv_icon_dot7_sml = "sv_icon_dot7_sml";
        public const string sv_icon_dot8_sml = "sv_icon_dot8_sml";
        public const string sv_icon_dot9_sml = "sv_icon_dot9_sml";
        public const string sv_icon_name0 = "sv_icon_name0";
        public const string sv_icon_name1 = "sv_icon_name1";
        public const string sv_icon_name2 = "sv_icon_name2";
        public const string sv_icon_name3 = "sv_icon_name3";
        public const string sv_icon_name4 = "sv_icon_name4";
        public const string sv_icon_name5 = "sv_icon_name5";
        public const string sv_icon_name6 = "sv_icon_name6";
        public const string sv_icon_name7 = "sv_icon_name7";
        public const string sv_icon_none = "sv_icon_none";
        public const string sv_label_0 = "sv_label_0";
        public const string sv_label_1 = "sv_label_1";
        public const string sv_label_2 = "sv_label_2";
        public const string sv_label_3 = "sv_label_3";
        public const string sv_label_4 = "sv_label_4";
        public const string sv_label_5 = "sv_label_5";
        public const string sv_label_6 = "sv_label_6";
        public const string sv_label_7 = "sv_label_7";
        public const string tab_next = "tab_next";
        public const string tab_prev = "tab_prev";
        public const string tabtofilter = "tabtofilter";
        public const string terraininspector_terraintooladd = "terraininspector.terraintooladd";
        public const string terraininspector_terraintoollower_on = "terraininspector.terraintoollower on";
        public const string terraininspector_terraintoollower = "terraininspector.terraintoollower";
        public const string terraininspector_terraintoolloweralt = "terraininspector.terraintoolloweralt";
        public const string terraininspector_terraintoolplants_on = "terraininspector.terraintoolplants on";
        public const string terraininspector_terraintoolplants = "terraininspector.terraintoolplants";
        public const string terraininspector_terraintoolplantsalt_on = "terraininspector.terraintoolplantsalt on";
        public const string terraininspector_terraintoolplantsalt = "terraininspector.terraintoolplantsalt";
        public const string terraininspector_terraintoolraise_on = "terraininspector.terraintoolraise on";
        public const string terraininspector_terraintoolraise = "terraininspector.terraintoolraise";
        public const string terraininspector_terraintoolsculpt_on = "terraininspector.terraintoolsculpt on";
        public const string terraininspector_terraintoolsculpt = "terraininspector.terraintoolsculpt";
        public const string terraininspector_terraintoolsetheight_on = "terraininspector.terraintoolsetheight on";
        public const string terraininspector_terraintoolsetheight = "terraininspector.terraintoolsetheight";
        public const string terraininspector_terraintoolsetheightalt_on = "terraininspector.terraintoolsetheightalt on";
        public const string terraininspector_terraintoolsetheightalt = "terraininspector.terraintoolsetheightalt";
        public const string terraininspector_terraintoolsettings_on = "terraininspector.terraintoolsettings on";
        public const string terraininspector_terraintoolsettings = "terraininspector.terraintoolsettings";
        public const string terraininspector_terraintoolsmoothheight_on = "terraininspector.terraintoolsmoothheight on";
        public const string terraininspector_terraintoolsmoothheight = "terraininspector.terraintoolsmoothheight";
        public const string terraininspector_terraintoolsplat_on = "terraininspector.terraintoolsplat on";
        public const string terraininspector_terraintoolsplat = "terraininspector.terraintoolsplat";
        public const string terraininspector_terraintoolsplatalt_on = "terraininspector.terraintoolsplatalt on";
        public const string terraininspector_terraintoolsplatalt = "terraininspector.terraintoolsplatalt";
        public const string terraininspector_terraintooltrees_on = "terraininspector.terraintooltrees on";
        public const string terraininspector_terraintooltrees = "terraininspector.terraintooltrees";
        public const string terraininspector_terraintooltreesalt_on = "terraininspector.terraintooltreesalt on";
        public const string terraininspector_terraintooltreesalt = "terraininspector.terraintooltreesalt";
        public const string testfailed = "testfailed";
        public const string testignored = "testignored";
        public const string testinconclusive = "testinconclusive";
        public const string testnormal = "testnormal";
        public const string testpassed = "testpassed";
        public const string teststopwatch = "teststopwatch";
        public const string toggleuvoverlay = "toggleuvoverlay";
        public const string toolbar_minus = "toolbar minus";
        public const string toolbar_plus_more = "toolbar plus more";
        public const string toolbar_plus = "toolbar plus";
        public const string d_debug = "d_debug";
        public const string d_objectmode = "d_objectmode";
        public const string d_sceneviewtools_on = "d_sceneviewtools on";
        public const string d_shaded = "d_shaded";
        public const string d_shadedwireframe = "d_shadedwireframe";
        public const string d_wireframe = "d_wireframe";
        public const string debug_on = "debug on";
        public const string debug = "debug";
        public const string objectmode = "objectmode";
        public const string shaded = "shaded";
        public const string shadedwireframe = "shadedwireframe";
        public const string wireframe = "wireframe";
        public const string toolhandlecenter = "toolhandlecenter";
        public const string toolhandleglobal = "toolhandleglobal";
        public const string toolhandlelocal = "toolhandlelocal";
        public const string toolhandlepivot = "toolhandlepivot";
        public const string toolsicon = "toolsicon";
        public const string tranp = "tranp";
        public const string transformtool_on = "transformtool on";
        public const string transformtool = "transformtool";
        public const string tree_icon_branch = "tree_icon_branch";
        public const string tree_icon_branch_frond = "tree_icon_branch_frond";
        public const string tree_icon_frond = "tree_icon_frond";
        public const string tree_icon_leaf = "tree_icon_leaf";
        public const string treeeditor_addbranches = "treeeditor.addbranches";
        public const string treeeditor_addleaves = "treeeditor.addleaves";
        public const string treeeditor_branch_on = "treeeditor.branch on";
        public const string treeeditor_branch = "treeeditor.branch";
        public const string treeeditor_branchfreehand_on = "treeeditor.branchfreehand on";
        public const string treeeditor_branchfreehand = "treeeditor.branchfreehand";
        public const string treeeditor_branchrotate_on = "treeeditor.branchrotate on";
        public const string treeeditor_branchrotate = "treeeditor.branchrotate";
        public const string treeeditor_branchscale_on = "treeeditor.branchscale on";
        public const string treeeditor_branchscale = "treeeditor.branchscale";
        public const string treeeditor_branchtranslate_on = "treeeditor.branchtranslate on";
        public const string treeeditor_branchtranslate = "treeeditor.branchtranslate";
        public const string treeeditor_distribution_on = "treeeditor.distribution on";
        public const string treeeditor_distribution = "treeeditor.distribution";
        public const string treeeditor_duplicate = "treeeditor.duplicate";
        public const string treeeditor_geometry_on = "treeeditor.geometry on";
        public const string treeeditor_geometry = "treeeditor.geometry";
        public const string treeeditor_leaf_on = "treeeditor.leaf on";
        public const string treeeditor_leaf = "treeeditor.leaf";
        public const string treeeditor_leaffreehand_on = "treeeditor.leaffreehand on";
        public const string treeeditor_leaffreehand = "treeeditor.leaffreehand";
        public const string treeeditor_leafrotate_on = "treeeditor.leafrotate on";
        public const string treeeditor_leafrotate = "treeeditor.leafrotate";
        public const string treeeditor_leafscale_on = "treeeditor.leafscale on";
        public const string treeeditor_leafscale = "treeeditor.leafscale";
        public const string treeeditor_leaftranslate_on = "treeeditor.leaftranslate on";
        public const string treeeditor_leaftranslate = "treeeditor.leaftranslate";
        public const string treeeditor_material_on = "treeeditor.material on";
        public const string treeeditor_material = "treeeditor.material";
        public const string treeeditor_refresh = "treeeditor.refresh";
        public const string treeeditor_trash = "treeeditor.trash";
        public const string treeeditor_wind_on = "treeeditor.wind on";
        public const string treeeditor_wind = "treeeditor.wind";
        public const string unityeditor_animationwindow = "unityeditor.animationwindow";
        public const string unityeditor_consolewindow = "unityeditor.consolewindow";
        public const string unityeditor_debuginspectorwindow = "unityeditor.debuginspectorwindow";
        public const string unityeditor_devicesimulation_simulatorwindow = "unityeditor.devicesimulation.simulatorwindow";
        public const string unityeditor_finddependencies = "unityeditor.finddependencies";
        public const string unityeditor_gameview = "unityeditor.gameview";
        public const string unityeditor_graphs_animatorcontrollertool = "unityeditor.graphs.animatorcontrollertool";
        public const string unityeditor_hierarchywindow = "unityeditor.hierarchywindow";
        public const string unityeditor_inspectorwindow = "unityeditor.inspectorwindow";
        public const string unityeditor_profilerwindow = "unityeditor.profilerwindow";
        public const string unityeditor_scenehierarchywindow = "unityeditor.scenehierarchywindow";
        public const string unityeditor_sceneview = "unityeditor.sceneview";
        public const string unityeditor_timeline_timelinewindow = "unityeditor.timeline.timelinewindow";
        public const string unityeditor_versioncontrol = "unityeditor.versioncontrol";
        public const string unitylogo = "unitylogo";
        public const string unitylogolarge = "unitylogolarge";
        public const string unlinked = "unlinked";
        public const string uparrow = "uparrow";
        public const string valid = "valid";
        public const string d_file = "d_file";
        public const string d_incoming_icon = "d_incoming icon";
        public const string d_p4_addedlocal = "d_p4_addedlocal";
        public const string d_p4_addedremote = "d_p4_addedremote";
        public const string d_p4_blueleftparenthesis = "d_p4_blueleftparenthesis";
        public const string d_p4_bluerightparenthesis = "d_p4_bluerightparenthesis";
        public const string d_p4_checkoutlocal = "d_p4_checkoutlocal";
        public const string d_p4_checkoutremote = "d_p4_checkoutremote";
        public const string d_p4_conflicted = "d_p4_conflicted";
        public const string d_p4_deletedlocal = "d_p4_deletedlocal";
        public const string d_p4_deletedremote = "d_p4_deletedremote";
        public const string d_p4_local = "d_p4_local";
        public const string d_p4_lockedlocal = "d_p4_lockedlocal";
        public const string d_p4_lockedremote = "d_p4_lockedremote";
        public const string d_p4_offline = "d_p4_offline";
        public const string d_p4_outofsync = "d_p4_outofsync";
        public const string d_p4_redleftparenthesis = "d_p4_redleftparenthesis";
        public const string d_p4_redrightparenthesis = "d_p4_redrightparenthesis";
        public const string d_p4_updating = "d_p4_updating";
        public const string file = "file";
        public const string incoming_icon = "incoming icon";
        public const string incoming_on_icon = "incoming on icon";
        public const string outgoing_icon = "outgoing icon";
        public const string p4_addedlocal = "p4_addedlocal";
        public const string p4_addedremote = "p4_addedremote";
        public const string p4_blueleftparenthesis = "p4_blueleftparenthesis";
        public const string p4_bluerightparenthesis = "p4_bluerightparenthesis";
        public const string p4_checkoutlocal = "p4_checkoutlocal";
        public const string p4_checkoutremote = "p4_checkoutremote";
        public const string p4_conflicted = "p4_conflicted";
        public const string p4_deletedlocal = "p4_deletedlocal";
        public const string p4_deletedremote = "p4_deletedremote";
        public const string p4_local = "p4_local";
        public const string p4_lockedlocal = "p4_lockedlocal";
        public const string p4_lockedremote = "p4_lockedremote";
        public const string p4_offline = "p4_offline";
        public const string p4_outofsync = "p4_outofsync";
        public const string p4_redleftparenthesis = "p4_redleftparenthesis";
        public const string p4_redrightparenthesis = "p4_redrightparenthesis";
        public const string p4_updating = "p4_updating";
        public const string verticalsplit = "verticalsplit";
        public const string viewtoolmove_on = "viewtoolmove on";
        public const string viewtoolmove = "viewtoolmove";
        public const string viewtoolorbit_on = "viewtoolorbit on";
        public const string viewtoolorbit = "viewtoolorbit";
        public const string viewtoolzoom_on = "viewtoolzoom on";
        public const string viewtoolzoom = "viewtoolzoom";
        public const string visibilityoff = "visibilityoff";
        public const string visibilityon = "visibilityon";
        public const string vumetertexturehorizontal = "vumetertexturehorizontal";
        public const string vumetertexturevertical = "vumetertexturevertical";
        public const string waitspin00 = "waitspin00";
        public const string waitspin01 = "waitspin01";
        public const string waitspin02 = "waitspin02";
        public const string waitspin03 = "waitspin03";
        public const string waitspin04 = "waitspin04";
        public const string waitspin05 = "waitspin05";
        public const string waitspin06 = "waitspin06";
        public const string waitspin07 = "waitspin07";
        public const string waitspin08 = "waitspin08";
        public const string waitspin09 = "waitspin09";
        public const string waitspin10 = "waitspin10";
        public const string waitspin11 = "waitspin11";
        public const string welcomescreen_assetstorelogo = "welcomescreen.assetstorelogo";
        public const string winbtn_graph = "winbtn_graph";
        public const string winbtn_graph_close_h = "winbtn_graph_close_h";
        public const string winbtn_graph_max_h = "winbtn_graph_max_h";
        public const string winbtn_graph_min_h = "winbtn_graph_min_h";
        public const string winbtn_mac_close = "winbtn_mac_close";
        public const string winbtn_mac_close_a = "winbtn_mac_close_a";
        public const string winbtn_mac_close_h = "winbtn_mac_close_h";
        public const string winbtn_mac_inact = "winbtn_mac_inact";
        public const string winbtn_mac_max = "winbtn_mac_max";
        public const string winbtn_mac_max_a = "winbtn_mac_max_a";
        public const string winbtn_mac_max_h = "winbtn_mac_max_h";
        public const string winbtn_mac_min = "winbtn_mac_min";
        public const string winbtn_mac_min_a = "winbtn_mac_min_a";
        public const string winbtn_mac_min_h = "winbtn_mac_min_h";
        public const string winbtn_win_close = "winbtn_win_close";
        public const string winbtn_win_close_a = "winbtn_win_close_a";
        public const string winbtn_win_close_h = "winbtn_win_close_h";
        public const string winbtn_win_max = "winbtn_win_max";
        public const string winbtn_win_max_a = "winbtn_win_max_a";
        public const string winbtn_win_max_h = "winbtn_win_max_h";
        public const string winbtn_win_min = "winbtn_win_min";
        public const string winbtn_win_min_a = "winbtn_win_min_a";
        public const string winbtn_win_min_h = "winbtn_win_min_h";
        public const string winbtn_win_rest = "winbtn_win_rest";
        public const string winbtn_win_rest_a = "winbtn_win_rest_a";
        public const string winbtn_win_rest_h = "winbtn_win_rest_h";
        public const string winbtn_win_restore = "winbtn_win_restore";
        public const string winbtn_win_restore_a = "winbtn_win_restore_a";
        public const string winbtn_win_restore_h = "winbtn_win_restore_h";


#endregion

#region Initialization

#if UNITY_EDITOR
        public static readonly Dictionary<Enum, string> _iconLookup;
        public static readonly Dictionary<string, Enum> _reverseIconLookup;

        static EditorGUIIcons()
        {
            _iconLookup = new Dictionary<Enum, string>();
            _reverseIconLookup = new Dictionary<string, Enum>();

            _iconLookup.Add(Enum.None, "None");
            _reverseIconLookup.Add("None", Enum.None);

            _iconLookup.Add(Enum._help, _help);
            _reverseIconLookup.Add(_help, Enum._help);
            _iconLookup.Add(Enum._menu, _menu);
            _reverseIconLookup.Add(_menu, Enum._menu);
            _iconLookup.Add(Enum._popup, _popup);
            _reverseIconLookup.Add(_popup, Enum._popup);
            _iconLookup.Add(Enum.aboutwindow_mainheader, aboutwindow_mainheader);
            _reverseIconLookup.Add(aboutwindow_mainheader, Enum.aboutwindow_mainheader);
            _iconLookup.Add(Enum.ageialogo, ageialogo);
            _reverseIconLookup.Add(ageialogo, Enum.ageialogo);
            _iconLookup.Add(Enum.alphabeticalsorting, alphabeticalsorting);
            _reverseIconLookup.Add(alphabeticalsorting, Enum.alphabeticalsorting);
            _iconLookup.Add(Enum.anchortransformtool_on, anchortransformtool_on);
            _reverseIconLookup.Add(anchortransformtool_on, Enum.anchortransformtool_on);
            _iconLookup.Add(Enum.anchortransformtool, anchortransformtool);
            _reverseIconLookup.Add(anchortransformtool, Enum.anchortransformtool);
            _iconLookup.Add(Enum.animation_addevent, animation_addevent);
            _reverseIconLookup.Add(animation_addevent, Enum.animation_addevent);
            _iconLookup.Add(Enum.animation_addkeyframe, animation_addkeyframe);
            _reverseIconLookup.Add(animation_addkeyframe, Enum.animation_addkeyframe);
            _iconLookup.Add(Enum.animation_eventmarker, animation_eventmarker);
            _reverseIconLookup.Add(animation_eventmarker, Enum.animation_eventmarker);
            _iconLookup.Add(Enum.animation_filterbyselection, animation_filterbyselection);
            _reverseIconLookup.Add(animation_filterbyselection, Enum.animation_filterbyselection);
            _iconLookup.Add(Enum.animation_firstkey, animation_firstkey);
            _reverseIconLookup.Add(animation_firstkey, Enum.animation_firstkey);
            _iconLookup.Add(Enum.animation_lastkey, animation_lastkey);
            _reverseIconLookup.Add(animation_lastkey, Enum.animation_lastkey);
            _iconLookup.Add(Enum.animation_nextkey, animation_nextkey);
            _reverseIconLookup.Add(animation_nextkey, Enum.animation_nextkey);
            _iconLookup.Add(Enum.animation_play, animation_play);
            _reverseIconLookup.Add(animation_play, Enum.animation_play);
            _iconLookup.Add(Enum.animation_prevkey, animation_prevkey);
            _reverseIconLookup.Add(animation_prevkey, Enum.animation_prevkey);
            _iconLookup.Add(Enum.animation_record, animation_record);
            _reverseIconLookup.Add(animation_record, Enum.animation_record);
            _iconLookup.Add(Enum.animation_sequencerlink, animation_sequencerlink);
            _reverseIconLookup.Add(animation_sequencerlink, Enum.animation_sequencerlink);
            _iconLookup.Add(Enum.animationanimated, animationanimated);
            _reverseIconLookup.Add(animationanimated, Enum.animationanimated);
            _iconLookup.Add(Enum.animationdopesheetkeyframe, animationdopesheetkeyframe);
            _reverseIconLookup.Add(animationdopesheetkeyframe, Enum.animationdopesheetkeyframe);
            _iconLookup.Add(Enum.animationkeyframe, animationkeyframe);
            _reverseIconLookup.Add(animationkeyframe, Enum.animationkeyframe);
            _iconLookup.Add(Enum.animationnocurve, animationnocurve);
            _reverseIconLookup.Add(animationnocurve, Enum.animationnocurve);
            _iconLookup.Add(Enum.animationvisibilitytoggleoff, animationvisibilitytoggleoff);
            _reverseIconLookup.Add(animationvisibilitytoggleoff, Enum.animationvisibilitytoggleoff);
            _iconLookup.Add(Enum.animationvisibilitytoggleon, animationvisibilitytoggleon);
            _reverseIconLookup.Add(animationvisibilitytoggleon, Enum.animationvisibilitytoggleon);
            _iconLookup.Add(Enum.animationwrapmodemenu, animationwrapmodemenu);
            _reverseIconLookup.Add(animationwrapmodemenu, Enum.animationwrapmodemenu);
            _iconLookup.Add(Enum.assemblylock, assemblylock);
            _reverseIconLookup.Add(assemblylock, Enum.assemblylock);
            _iconLookup.Add(Enum.asset_store, asset_store);
            _reverseIconLookup.Add(asset_store, Enum.asset_store);
            _iconLookup.Add(Enum.unity_assetstore_originals_logo_white, unity_assetstore_originals_logo_white);
            _reverseIconLookup.Add(unity_assetstore_originals_logo_white, Enum.unity_assetstore_originals_logo_white);
            _iconLookup.Add(Enum.audio_mixer, audio_mixer);
            _reverseIconLookup.Add(audio_mixer, Enum.audio_mixer);
            _iconLookup.Add(Enum.autolightbakingoff, autolightbakingoff);
            _reverseIconLookup.Add(autolightbakingoff, Enum.autolightbakingoff);
            _iconLookup.Add(Enum.autolightbakingon, autolightbakingon);
            _reverseIconLookup.Add(autolightbakingon, Enum.autolightbakingon);
            _iconLookup.Add(Enum.avatarcompass, avatarcompass);
            _reverseIconLookup.Add(avatarcompass, Enum.avatarcompass);
            _iconLookup.Add(Enum.avatarcontroller_layer, avatarcontroller_layer);
            _reverseIconLookup.Add(avatarcontroller_layer, Enum.avatarcontroller_layer);
            _iconLookup.Add(Enum.avatarcontroller_layerhover, avatarcontroller_layerhover);
            _reverseIconLookup.Add(avatarcontroller_layerhover, Enum.avatarcontroller_layerhover);
            _iconLookup.Add(Enum.avatarcontroller_layerselected, avatarcontroller_layerselected);
            _reverseIconLookup.Add(avatarcontroller_layerselected, Enum.avatarcontroller_layerselected);
            _iconLookup.Add(Enum.bodypartpicker, bodypartpicker);
            _reverseIconLookup.Add(bodypartpicker, Enum.bodypartpicker);
            _iconLookup.Add(Enum.bodysilhouette, bodysilhouette);
            _reverseIconLookup.Add(bodysilhouette, Enum.bodysilhouette);
            _iconLookup.Add(Enum.dotfill, dotfill);
            _reverseIconLookup.Add(dotfill, Enum.dotfill);
            _iconLookup.Add(Enum.dotframe, dotframe);
            _reverseIconLookup.Add(dotframe, Enum.dotframe);
            _iconLookup.Add(Enum.dotframedotted, dotframedotted);
            _reverseIconLookup.Add(dotframedotted, Enum.dotframedotted);
            _iconLookup.Add(Enum.dotselection, dotselection);
            _reverseIconLookup.Add(dotselection, Enum.dotselection);
            _iconLookup.Add(Enum.head, head);
            _reverseIconLookup.Add(head, Enum.head);
            _iconLookup.Add(Enum.headik, headik);
            _reverseIconLookup.Add(headik, Enum.headik);
            _iconLookup.Add(Enum.headzoom, headzoom);
            _reverseIconLookup.Add(headzoom, Enum.headzoom);
            _iconLookup.Add(Enum.headzoomsilhouette, headzoomsilhouette);
            _reverseIconLookup.Add(headzoomsilhouette, Enum.headzoomsilhouette);
            _iconLookup.Add(Enum.leftarm, leftarm);
            _reverseIconLookup.Add(leftarm, Enum.leftarm);
            _iconLookup.Add(Enum.leftfeetik, leftfeetik);
            _reverseIconLookup.Add(leftfeetik, Enum.leftfeetik);
            _iconLookup.Add(Enum.leftfingers, leftfingers);
            _reverseIconLookup.Add(leftfingers, Enum.leftfingers);
            _iconLookup.Add(Enum.leftfingersik, leftfingersik);
            _reverseIconLookup.Add(leftfingersik, Enum.leftfingersik);
            _iconLookup.Add(Enum.lefthandzoom, lefthandzoom);
            _reverseIconLookup.Add(lefthandzoom, Enum.lefthandzoom);
            _iconLookup.Add(Enum.lefthandzoomsilhouette, lefthandzoomsilhouette);
            _reverseIconLookup.Add(lefthandzoomsilhouette, Enum.lefthandzoomsilhouette);
            _iconLookup.Add(Enum.leftleg, leftleg);
            _reverseIconLookup.Add(leftleg, Enum.leftleg);
            _iconLookup.Add(Enum.maskeditor_root, maskeditor_root);
            _reverseIconLookup.Add(maskeditor_root, Enum.maskeditor_root);
            _iconLookup.Add(Enum.rightarm, rightarm);
            _reverseIconLookup.Add(rightarm, Enum.rightarm);
            _iconLookup.Add(Enum.rightfeetik, rightfeetik);
            _reverseIconLookup.Add(rightfeetik, Enum.rightfeetik);
            _iconLookup.Add(Enum.rightfingers, rightfingers);
            _reverseIconLookup.Add(rightfingers, Enum.rightfingers);
            _iconLookup.Add(Enum.rightfingersik, rightfingersik);
            _reverseIconLookup.Add(rightfingersik, Enum.rightfingersik);
            _iconLookup.Add(Enum.righthandzoom, righthandzoom);
            _reverseIconLookup.Add(righthandzoom, Enum.righthandzoom);
            _iconLookup.Add(Enum.righthandzoomsilhouette, righthandzoomsilhouette);
            _reverseIconLookup.Add(righthandzoomsilhouette, Enum.righthandzoomsilhouette);
            _iconLookup.Add(Enum.rightleg, rightleg);
            _reverseIconLookup.Add(rightleg, Enum.rightleg);
            _iconLookup.Add(Enum.torso, torso);
            _reverseIconLookup.Add(torso, Enum.torso);
            _iconLookup.Add(Enum.avatarpivot, avatarpivot);
            _reverseIconLookup.Add(avatarpivot, Enum.avatarpivot);
            _iconLookup.Add(Enum.avatarselector, avatarselector);
            _reverseIconLookup.Add(avatarselector, Enum.avatarselector);
            _iconLookup.Add(Enum.back, back);
            _reverseIconLookup.Add(back, Enum.back);
            _iconLookup.Add(Enum.beginbutton_on, beginbutton_on);
            _reverseIconLookup.Add(beginbutton_on, Enum.beginbutton_on);
            _iconLookup.Add(Enum.beginbutton, beginbutton);
            _reverseIconLookup.Add(beginbutton, Enum.beginbutton);
            _iconLookup.Add(Enum.blendkey, blendkey);
            _reverseIconLookup.Add(blendkey, Enum.blendkey);
            _iconLookup.Add(Enum.blendkeyoverlay, blendkeyoverlay);
            _reverseIconLookup.Add(blendkeyoverlay, Enum.blendkeyoverlay);
            _iconLookup.Add(Enum.blendkeyselected, blendkeyselected);
            _reverseIconLookup.Add(blendkeyselected, Enum.blendkeyselected);
            _iconLookup.Add(Enum.blendsampler, blendsampler);
            _reverseIconLookup.Add(blendsampler, Enum.blendsampler);
            _iconLookup.Add(Enum.bluegroove, bluegroove);
            _reverseIconLookup.Add(bluegroove, Enum.bluegroove);
            _iconLookup.Add(Enum.buildsettings_android_on, buildsettings_android_on);
            _reverseIconLookup.Add(buildsettings_android_on, Enum.buildsettings_android_on);
            _iconLookup.Add(Enum.buildsettings_android, buildsettings_android);
            _reverseIconLookup.Add(buildsettings_android, Enum.buildsettings_android);
            _iconLookup.Add(Enum.buildsettings_android_small, buildsettings_android_small);
            _reverseIconLookup.Add(buildsettings_android_small, Enum.buildsettings_android_small);
            _iconLookup.Add(Enum.buildsettings_broadcom, buildsettings_broadcom);
            _reverseIconLookup.Add(buildsettings_broadcom, Enum.buildsettings_broadcom);
            _iconLookup.Add(Enum.buildsettings_editor, buildsettings_editor);
            _reverseIconLookup.Add(buildsettings_editor, Enum.buildsettings_editor);
            _iconLookup.Add(Enum.buildsettings_editor_small, buildsettings_editor_small);
            _reverseIconLookup.Add(buildsettings_editor_small, Enum.buildsettings_editor_small);
            _iconLookup.Add(Enum.buildsettings_embeddedlinux_on, buildsettings_embeddedlinux_on);
            _reverseIconLookup.Add(buildsettings_embeddedlinux_on, Enum.buildsettings_embeddedlinux_on);
            _iconLookup.Add(Enum.buildsettings_embeddedlinux, buildsettings_embeddedlinux);
            _reverseIconLookup.Add(buildsettings_embeddedlinux, Enum.buildsettings_embeddedlinux);
            _iconLookup.Add(Enum.buildsettings_embeddedlinux_small, buildsettings_embeddedlinux_small);
            _reverseIconLookup.Add(buildsettings_embeddedlinux_small, Enum.buildsettings_embeddedlinux_small);
            _iconLookup.Add(Enum.buildsettings_facebook_on, buildsettings_facebook_on);
            _reverseIconLookup.Add(buildsettings_facebook_on, Enum.buildsettings_facebook_on);
            _iconLookup.Add(Enum.buildsettings_facebook, buildsettings_facebook);
            _reverseIconLookup.Add(buildsettings_facebook, Enum.buildsettings_facebook);
            _iconLookup.Add(Enum.buildsettings_facebook_small, buildsettings_facebook_small);
            _reverseIconLookup.Add(buildsettings_facebook_small, Enum.buildsettings_facebook_small);
            _iconLookup.Add(Enum.buildsettings_flashplayer, buildsettings_flashplayer);
            _reverseIconLookup.Add(buildsettings_flashplayer, Enum.buildsettings_flashplayer);
            _iconLookup.Add(Enum.buildsettings_flashplayer_small, buildsettings_flashplayer_small);
            _reverseIconLookup.Add(buildsettings_flashplayer_small, Enum.buildsettings_flashplayer_small);
            _iconLookup.Add(Enum.buildsettings_gamecorescarlett_on, buildsettings_gamecorescarlett_on);
            _reverseIconLookup.Add(buildsettings_gamecorescarlett_on, Enum.buildsettings_gamecorescarlett_on);
            _iconLookup.Add(Enum.buildsettings_gamecorescarlett, buildsettings_gamecorescarlett);
            _reverseIconLookup.Add(buildsettings_gamecorescarlett, Enum.buildsettings_gamecorescarlett);
            _iconLookup.Add(Enum.buildsettings_gamecorescarlett_small, buildsettings_gamecorescarlett_small);
            _reverseIconLookup.Add(buildsettings_gamecorescarlett_small, Enum.buildsettings_gamecorescarlett_small);
            _iconLookup.Add(Enum.buildsettings_gamecorexboxone_on, buildsettings_gamecorexboxone_on);
            _reverseIconLookup.Add(buildsettings_gamecorexboxone_on, Enum.buildsettings_gamecorexboxone_on);
            _iconLookup.Add(Enum.buildsettings_gamecorexboxone, buildsettings_gamecorexboxone);
            _reverseIconLookup.Add(buildsettings_gamecorexboxone, Enum.buildsettings_gamecorexboxone);
            _iconLookup.Add(Enum.buildsettings_gamecorexboxone_small, buildsettings_gamecorexboxone_small);
            _reverseIconLookup.Add(buildsettings_gamecorexboxone_small, Enum.buildsettings_gamecorexboxone_small);
            _iconLookup.Add(Enum.buildsettings_iphone_on, buildsettings_iphone_on);
            _reverseIconLookup.Add(buildsettings_iphone_on, Enum.buildsettings_iphone_on);
            _iconLookup.Add(Enum.buildsettings_iphone, buildsettings_iphone);
            _reverseIconLookup.Add(buildsettings_iphone, Enum.buildsettings_iphone);
            _iconLookup.Add(Enum.buildsettings_iphone_small, buildsettings_iphone_small);
            _reverseIconLookup.Add(buildsettings_iphone_small, Enum.buildsettings_iphone_small);
            _iconLookup.Add(Enum.buildsettings_lumin_on, buildsettings_lumin_on);
            _reverseIconLookup.Add(buildsettings_lumin_on, Enum.buildsettings_lumin_on);
            _iconLookup.Add(Enum.buildsettings_lumin, buildsettings_lumin);
            _reverseIconLookup.Add(buildsettings_lumin, Enum.buildsettings_lumin);
            _iconLookup.Add(Enum.buildsettings_lumin_small, buildsettings_lumin_small);
            _reverseIconLookup.Add(buildsettings_lumin_small, Enum.buildsettings_lumin_small);
            _iconLookup.Add(Enum.buildsettings_metro_on, buildsettings_metro_on);
            _reverseIconLookup.Add(buildsettings_metro_on, Enum.buildsettings_metro_on);
            _iconLookup.Add(Enum.buildsettings_metro, buildsettings_metro);
            _reverseIconLookup.Add(buildsettings_metro, Enum.buildsettings_metro);
            _iconLookup.Add(Enum.buildsettings_metro_small, buildsettings_metro_small);
            _reverseIconLookup.Add(buildsettings_metro_small, Enum.buildsettings_metro_small);
            _iconLookup.Add(Enum.buildsettings_n3ds_on, buildsettings_n3ds_on);
            _reverseIconLookup.Add(buildsettings_n3ds_on, Enum.buildsettings_n3ds_on);
            _iconLookup.Add(Enum.buildsettings_n3ds, buildsettings_n3ds);
            _reverseIconLookup.Add(buildsettings_n3ds, Enum.buildsettings_n3ds);
            _iconLookup.Add(Enum.buildsettings_n3ds_small, buildsettings_n3ds_small);
            _reverseIconLookup.Add(buildsettings_n3ds_small, Enum.buildsettings_n3ds_small);
            _iconLookup.Add(Enum.buildsettings_ps4_on, buildsettings_ps4_on);
            _reverseIconLookup.Add(buildsettings_ps4_on, Enum.buildsettings_ps4_on);
            _iconLookup.Add(Enum.buildsettings_ps4, buildsettings_ps4);
            _reverseIconLookup.Add(buildsettings_ps4, Enum.buildsettings_ps4);
            _iconLookup.Add(Enum.buildsettings_ps4_small, buildsettings_ps4_small);
            _reverseIconLookup.Add(buildsettings_ps4_small, Enum.buildsettings_ps4_small);
            _iconLookup.Add(Enum.buildsettings_ps5_on, buildsettings_ps5_on);
            _reverseIconLookup.Add(buildsettings_ps5_on, Enum.buildsettings_ps5_on);
            _iconLookup.Add(Enum.buildsettings_ps5, buildsettings_ps5);
            _reverseIconLookup.Add(buildsettings_ps5, Enum.buildsettings_ps5);
            _iconLookup.Add(Enum.buildsettings_ps5_small, buildsettings_ps5_small);
            _reverseIconLookup.Add(buildsettings_ps5_small, Enum.buildsettings_ps5_small);
            _iconLookup.Add(Enum.buildsettings_psm, buildsettings_psm);
            _reverseIconLookup.Add(buildsettings_psm, Enum.buildsettings_psm);
            _iconLookup.Add(Enum.buildsettings_psm_small, buildsettings_psm_small);
            _reverseIconLookup.Add(buildsettings_psm_small, Enum.buildsettings_psm_small);
            _iconLookup.Add(Enum.buildsettings_psp2, buildsettings_psp2);
            _reverseIconLookup.Add(buildsettings_psp2, Enum.buildsettings_psp2);
            _iconLookup.Add(Enum.buildsettings_psp2_small, buildsettings_psp2_small);
            _reverseIconLookup.Add(buildsettings_psp2_small, Enum.buildsettings_psp2_small);
            _iconLookup.Add(Enum.buildsettings_selectedicon, buildsettings_selectedicon);
            _reverseIconLookup.Add(buildsettings_selectedicon, Enum.buildsettings_selectedicon);
            _iconLookup.Add(Enum.buildsettings_stadia_on, buildsettings_stadia_on);
            _reverseIconLookup.Add(buildsettings_stadia_on, Enum.buildsettings_stadia_on);
            _iconLookup.Add(Enum.buildsettings_stadia, buildsettings_stadia);
            _reverseIconLookup.Add(buildsettings_stadia, Enum.buildsettings_stadia);
            _iconLookup.Add(Enum.buildsettings_stadia_small, buildsettings_stadia_small);
            _reverseIconLookup.Add(buildsettings_stadia_small, Enum.buildsettings_stadia_small);
            _iconLookup.Add(Enum.buildsettings_standalone_on, buildsettings_standalone_on);
            _reverseIconLookup.Add(buildsettings_standalone_on, Enum.buildsettings_standalone_on);
            _iconLookup.Add(Enum.buildsettings_standalone, buildsettings_standalone);
            _reverseIconLookup.Add(buildsettings_standalone, Enum.buildsettings_standalone);
            _iconLookup.Add(Enum.buildsettings_standalone_small, buildsettings_standalone_small);
            _reverseIconLookup.Add(buildsettings_standalone_small, Enum.buildsettings_standalone_small);
            _iconLookup.Add(Enum.buildsettings_standalonebroadcom_small, buildsettings_standalonebroadcom_small);
            _reverseIconLookup.Add(buildsettings_standalonebroadcom_small, Enum.buildsettings_standalonebroadcom_small);
            _iconLookup.Add(Enum.buildsettings_standalonegles20emu_small, buildsettings_standalonegles20emu_small);
            _reverseIconLookup.Add(buildsettings_standalonegles20emu_small, Enum.buildsettings_standalonegles20emu_small);
            _iconLookup.Add(Enum.buildsettings_standaloneglesemu, buildsettings_standaloneglesemu);
            _reverseIconLookup.Add(buildsettings_standaloneglesemu, Enum.buildsettings_standaloneglesemu);
            _iconLookup.Add(Enum.buildsettings_standaloneglesemu_small, buildsettings_standaloneglesemu_small);
            _reverseIconLookup.Add(buildsettings_standaloneglesemu_small, Enum.buildsettings_standaloneglesemu_small);
            _iconLookup.Add(Enum.buildsettings_switch_on, buildsettings_switch_on);
            _reverseIconLookup.Add(buildsettings_switch_on, Enum.buildsettings_switch_on);
            _iconLookup.Add(Enum.buildsettings_switch, buildsettings_switch);
            _reverseIconLookup.Add(buildsettings_switch, Enum.buildsettings_switch);
            _iconLookup.Add(Enum.buildsettings_switch_small, buildsettings_switch_small);
            _reverseIconLookup.Add(buildsettings_switch_small, Enum.buildsettings_switch_small);
            _iconLookup.Add(Enum.buildsettings_tvos_on, buildsettings_tvos_on);
            _reverseIconLookup.Add(buildsettings_tvos_on, Enum.buildsettings_tvos_on);
            _iconLookup.Add(Enum.buildsettings_tvos, buildsettings_tvos);
            _reverseIconLookup.Add(buildsettings_tvos, Enum.buildsettings_tvos);
            _iconLookup.Add(Enum.buildsettings_tvos_small, buildsettings_tvos_small);
            _reverseIconLookup.Add(buildsettings_tvos_small, Enum.buildsettings_tvos_small);
            _iconLookup.Add(Enum.buildsettings_web, buildsettings_web);
            _reverseIconLookup.Add(buildsettings_web, Enum.buildsettings_web);
            _iconLookup.Add(Enum.buildsettings_web_small, buildsettings_web_small);
            _reverseIconLookup.Add(buildsettings_web_small, Enum.buildsettings_web_small);
            _iconLookup.Add(Enum.buildsettings_webgl_on, buildsettings_webgl_on);
            _reverseIconLookup.Add(buildsettings_webgl_on, Enum.buildsettings_webgl_on);
            _iconLookup.Add(Enum.buildsettings_webgl, buildsettings_webgl);
            _reverseIconLookup.Add(buildsettings_webgl, Enum.buildsettings_webgl);
            _iconLookup.Add(Enum.buildsettings_webgl_small, buildsettings_webgl_small);
            _reverseIconLookup.Add(buildsettings_webgl_small, Enum.buildsettings_webgl_small);
            _iconLookup.Add(Enum.buildsettings_wp8, buildsettings_wp8);
            _reverseIconLookup.Add(buildsettings_wp8, Enum.buildsettings_wp8);
            _iconLookup.Add(Enum.buildsettings_wp8_small, buildsettings_wp8_small);
            _reverseIconLookup.Add(buildsettings_wp8_small, Enum.buildsettings_wp8_small);
            _iconLookup.Add(Enum.buildsettings_xbox360, buildsettings_xbox360);
            _reverseIconLookup.Add(buildsettings_xbox360, Enum.buildsettings_xbox360);
            _iconLookup.Add(Enum.buildsettings_xbox360_small, buildsettings_xbox360_small);
            _reverseIconLookup.Add(buildsettings_xbox360_small, Enum.buildsettings_xbox360_small);
            _iconLookup.Add(Enum.buildsettings_xboxone_on, buildsettings_xboxone_on);
            _reverseIconLookup.Add(buildsettings_xboxone_on, Enum.buildsettings_xboxone_on);
            _iconLookup.Add(Enum.buildsettings_xboxone, buildsettings_xboxone);
            _reverseIconLookup.Add(buildsettings_xboxone, Enum.buildsettings_xboxone);
            _iconLookup.Add(Enum.buildsettings_xboxone_small, buildsettings_xboxone_small);
            _reverseIconLookup.Add(buildsettings_xboxone_small, Enum.buildsettings_xboxone_small);
            _iconLookup.Add(Enum.cacheserverconnected, cacheserverconnected);
            _reverseIconLookup.Add(cacheserverconnected, Enum.cacheserverconnected);
            _iconLookup.Add(Enum.cacheserverdisabled, cacheserverdisabled);
            _reverseIconLookup.Add(cacheserverdisabled, Enum.cacheserverdisabled);
            _iconLookup.Add(Enum.cacheserverdisconnected, cacheserverdisconnected);
            _reverseIconLookup.Add(cacheserverdisconnected, Enum.cacheserverdisconnected);
            _iconLookup.Add(Enum.checkerfloor, checkerfloor);
            _reverseIconLookup.Add(checkerfloor, Enum.checkerfloor);
            _iconLookup.Add(Enum.clipboard, clipboard);
            _reverseIconLookup.Add(clipboard, Enum.clipboard);
            _iconLookup.Add(Enum.clothinspector_painttool, clothinspector_painttool);
            _reverseIconLookup.Add(clothinspector_painttool, Enum.clothinspector_painttool);
            _iconLookup.Add(Enum.clothinspector_paintvalue, clothinspector_paintvalue);
            _reverseIconLookup.Add(clothinspector_paintvalue, Enum.clothinspector_paintvalue);
            _iconLookup.Add(Enum.clothinspector_selecttool, clothinspector_selecttool);
            _reverseIconLookup.Add(clothinspector_selecttool, Enum.clothinspector_selecttool);
            _iconLookup.Add(Enum.clothinspector_settingstool, clothinspector_settingstool);
            _reverseIconLookup.Add(clothinspector_settingstool, Enum.clothinspector_settingstool);
            _iconLookup.Add(Enum.clothinspector_viewvalue, clothinspector_viewvalue);
            _reverseIconLookup.Add(clothinspector_viewvalue, Enum.clothinspector_viewvalue);
            _iconLookup.Add(Enum.cloudconnect, cloudconnect);
            _reverseIconLookup.Add(cloudconnect, Enum.cloudconnect);
            _iconLookup.Add(Enum.collab_build, collab_build);
            _reverseIconLookup.Add(collab_build, Enum.collab_build);
            _iconLookup.Add(Enum.collab_buildfailed, collab_buildfailed);
            _reverseIconLookup.Add(collab_buildfailed, Enum.collab_buildfailed);
            _iconLookup.Add(Enum.collab_buildsucceeded, collab_buildsucceeded);
            _reverseIconLookup.Add(collab_buildsucceeded, Enum.collab_buildsucceeded);
            _iconLookup.Add(Enum.collab_fileadded, collab_fileadded);
            _reverseIconLookup.Add(collab_fileadded, Enum.collab_fileadded);
            _iconLookup.Add(Enum.collab_fileconflict, collab_fileconflict);
            _reverseIconLookup.Add(collab_fileconflict, Enum.collab_fileconflict);
            _iconLookup.Add(Enum.collab_filedeleted, collab_filedeleted);
            _reverseIconLookup.Add(collab_filedeleted, Enum.collab_filedeleted);
            _iconLookup.Add(Enum.collab_fileignored, collab_fileignored);
            _reverseIconLookup.Add(collab_fileignored, Enum.collab_fileignored);
            _iconLookup.Add(Enum.collab_filemoved, collab_filemoved);
            _reverseIconLookup.Add(collab_filemoved, Enum.collab_filemoved);
            _iconLookup.Add(Enum.collab_fileupdated, collab_fileupdated);
            _reverseIconLookup.Add(collab_fileupdated, Enum.collab_fileupdated);
            _iconLookup.Add(Enum.collab_folderadded, collab_folderadded);
            _reverseIconLookup.Add(collab_folderadded, Enum.collab_folderadded);
            _iconLookup.Add(Enum.collab_folderconflict, collab_folderconflict);
            _reverseIconLookup.Add(collab_folderconflict, Enum.collab_folderconflict);
            _iconLookup.Add(Enum.collab_folderdeleted, collab_folderdeleted);
            _reverseIconLookup.Add(collab_folderdeleted, Enum.collab_folderdeleted);
            _iconLookup.Add(Enum.collab_folderignored, collab_folderignored);
            _reverseIconLookup.Add(collab_folderignored, Enum.collab_folderignored);
            _iconLookup.Add(Enum.collab_foldermoved, collab_foldermoved);
            _reverseIconLookup.Add(collab_foldermoved, Enum.collab_foldermoved);
            _iconLookup.Add(Enum.collab_folderupdated, collab_folderupdated);
            _reverseIconLookup.Add(collab_folderupdated, Enum.collab_folderupdated);
            _iconLookup.Add(Enum.collab_nointernet, collab_nointernet);
            _reverseIconLookup.Add(collab_nointernet, Enum.collab_nointernet);
            _iconLookup.Add(Enum.collab, collab);
            _reverseIconLookup.Add(collab, Enum.collab);
            _iconLookup.Add(Enum.collab_warning, collab_warning);
            _reverseIconLookup.Add(collab_warning, Enum.collab_warning);
            _iconLookup.Add(Enum.collabconflict, collabconflict);
            _reverseIconLookup.Add(collabconflict, Enum.collabconflict);
            _iconLookup.Add(Enum.collaberror, collaberror);
            _reverseIconLookup.Add(collaberror, Enum.collaberror);
            _iconLookup.Add(Enum.collabnew, collabnew);
            _reverseIconLookup.Add(collabnew, Enum.collabnew);
            _iconLookup.Add(Enum.collaboffline, collaboffline);
            _reverseIconLookup.Add(collaboffline, Enum.collaboffline);
            _iconLookup.Add(Enum.collabprogress, collabprogress);
            _reverseIconLookup.Add(collabprogress, Enum.collabprogress);
            _iconLookup.Add(Enum.collabpull, collabpull);
            _reverseIconLookup.Add(collabpull, Enum.collabpull);
            _iconLookup.Add(Enum.collabpush, collabpush);
            _reverseIconLookup.Add(collabpush, Enum.collabpush);
            _iconLookup.Add(Enum.colorpicker_colorcycle, colorpicker_colorcycle);
            _reverseIconLookup.Add(colorpicker_colorcycle, Enum.colorpicker_colorcycle);
            _iconLookup.Add(Enum.colorpicker_cyclecolor, colorpicker_cyclecolor);
            _reverseIconLookup.Add(colorpicker_cyclecolor, Enum.colorpicker_cyclecolor);
            _iconLookup.Add(Enum.colorpicker_cycleslider, colorpicker_cycleslider);
            _reverseIconLookup.Add(colorpicker_cycleslider, Enum.colorpicker_cycleslider);
            _iconLookup.Add(Enum.colorpicker_slidercycle, colorpicker_slidercycle);
            _reverseIconLookup.Add(colorpicker_slidercycle, Enum.colorpicker_slidercycle);
            _iconLookup.Add(Enum.console_erroricon_inactive_sml, console_erroricon_inactive_sml);
            _reverseIconLookup.Add(console_erroricon_inactive_sml, Enum.console_erroricon_inactive_sml);
            _iconLookup.Add(Enum.console_erroricon, console_erroricon);
            _reverseIconLookup.Add(console_erroricon, Enum.console_erroricon);
            _iconLookup.Add(Enum.console_erroricon_sml, console_erroricon_sml);
            _reverseIconLookup.Add(console_erroricon_sml, Enum.console_erroricon_sml);
            _iconLookup.Add(Enum.console_infoicon_inactive_sml, console_infoicon_inactive_sml);
            _reverseIconLookup.Add(console_infoicon_inactive_sml, Enum.console_infoicon_inactive_sml);
            _iconLookup.Add(Enum.console_infoicon, console_infoicon);
            _reverseIconLookup.Add(console_infoicon, Enum.console_infoicon);
            _iconLookup.Add(Enum.console_infoicon_sml, console_infoicon_sml);
            _reverseIconLookup.Add(console_infoicon_sml, Enum.console_infoicon_sml);
            _iconLookup.Add(Enum.console_warnicon_inactive_sml, console_warnicon_inactive_sml);
            _reverseIconLookup.Add(console_warnicon_inactive_sml, Enum.console_warnicon_inactive_sml);
            _iconLookup.Add(Enum.console_warnicon, console_warnicon);
            _reverseIconLookup.Add(console_warnicon, Enum.console_warnicon);
            _iconLookup.Add(Enum.console_warnicon_sml, console_warnicon_sml);
            _reverseIconLookup.Add(console_warnicon_sml, Enum.console_warnicon_sml);
            _iconLookup.Add(Enum.createaddnew, createaddnew);
            _reverseIconLookup.Add(createaddnew, Enum.createaddnew);
            _iconLookup.Add(Enum.crossicon, crossicon);
            _reverseIconLookup.Add(crossicon, Enum.crossicon);
            _iconLookup.Add(Enum.curvekeyframe, curvekeyframe);
            _reverseIconLookup.Add(curvekeyframe, Enum.curvekeyframe);
            _iconLookup.Add(Enum.curvekeyframeselected, curvekeyframeselected);
            _reverseIconLookup.Add(curvekeyframeselected, Enum.curvekeyframeselected);
            _iconLookup.Add(Enum.curvekeyframeselectedoverlay, curvekeyframeselectedoverlay);
            _reverseIconLookup.Add(curvekeyframeselectedoverlay, Enum.curvekeyframeselectedoverlay);
            _iconLookup.Add(Enum.curvekeyframesemiselectedoverlay, curvekeyframesemiselectedoverlay);
            _reverseIconLookup.Add(curvekeyframesemiselectedoverlay, Enum.curvekeyframesemiselectedoverlay);
            _iconLookup.Add(Enum.curvekeyframeweighted, curvekeyframeweighted);
            _reverseIconLookup.Add(curvekeyframeweighted, Enum.curvekeyframeweighted);
            _iconLookup.Add(Enum.customsorting, customsorting);
            _reverseIconLookup.Add(customsorting, Enum.customsorting);
            _iconLookup.Add(Enum.customtool, customtool);
            _reverseIconLookup.Add(customtool, Enum.customtool);
            _iconLookup.Add(Enum.d__help, d__help);
            _reverseIconLookup.Add(d__help, Enum.d__help);
            _iconLookup.Add(Enum.d__menu, d__menu);
            _reverseIconLookup.Add(d__menu, Enum.d__menu);
            _iconLookup.Add(Enum.d__popup, d__popup);
            _reverseIconLookup.Add(d__popup, Enum.d__popup);
            _iconLookup.Add(Enum.d_aboutwindow_mainheader, d_aboutwindow_mainheader);
            _reverseIconLookup.Add(d_aboutwindow_mainheader, Enum.d_aboutwindow_mainheader);
            _iconLookup.Add(Enum.d_ageialogo, d_ageialogo);
            _reverseIconLookup.Add(d_ageialogo, Enum.d_ageialogo);
            _iconLookup.Add(Enum.d_alphabeticalsorting, d_alphabeticalsorting);
            _reverseIconLookup.Add(d_alphabeticalsorting, Enum.d_alphabeticalsorting);
            _iconLookup.Add(Enum.d_anchortransformtool_on, d_anchortransformtool_on);
            _reverseIconLookup.Add(d_anchortransformtool_on, Enum.d_anchortransformtool_on);
            _iconLookup.Add(Enum.d_anchortransformtool, d_anchortransformtool);
            _reverseIconLookup.Add(d_anchortransformtool, Enum.d_anchortransformtool);
            _iconLookup.Add(Enum.d_animation_addevent, d_animation_addevent);
            _reverseIconLookup.Add(d_animation_addevent, Enum.d_animation_addevent);
            _iconLookup.Add(Enum.d_animation_addkeyframe, d_animation_addkeyframe);
            _reverseIconLookup.Add(d_animation_addkeyframe, Enum.d_animation_addkeyframe);
            _iconLookup.Add(Enum.d_animation_eventmarker, d_animation_eventmarker);
            _reverseIconLookup.Add(d_animation_eventmarker, Enum.d_animation_eventmarker);
            _iconLookup.Add(Enum.d_animation_filterbyselection, d_animation_filterbyselection);
            _reverseIconLookup.Add(d_animation_filterbyselection, Enum.d_animation_filterbyselection);
            _iconLookup.Add(Enum.d_animation_firstkey, d_animation_firstkey);
            _reverseIconLookup.Add(d_animation_firstkey, Enum.d_animation_firstkey);
            _iconLookup.Add(Enum.d_animation_lastkey, d_animation_lastkey);
            _reverseIconLookup.Add(d_animation_lastkey, Enum.d_animation_lastkey);
            _iconLookup.Add(Enum.d_animation_nextkey, d_animation_nextkey);
            _reverseIconLookup.Add(d_animation_nextkey, Enum.d_animation_nextkey);
            _iconLookup.Add(Enum.d_animation_play, d_animation_play);
            _reverseIconLookup.Add(d_animation_play, Enum.d_animation_play);
            _iconLookup.Add(Enum.d_animation_prevkey, d_animation_prevkey);
            _reverseIconLookup.Add(d_animation_prevkey, Enum.d_animation_prevkey);
            _iconLookup.Add(Enum.d_animation_record, d_animation_record);
            _reverseIconLookup.Add(d_animation_record, Enum.d_animation_record);
            _iconLookup.Add(Enum.d_animation_sequencerlink, d_animation_sequencerlink);
            _reverseIconLookup.Add(d_animation_sequencerlink, Enum.d_animation_sequencerlink);
            _iconLookup.Add(Enum.d_animationanimated, d_animationanimated);
            _reverseIconLookup.Add(d_animationanimated, Enum.d_animationanimated);
            _iconLookup.Add(Enum.d_animationkeyframe, d_animationkeyframe);
            _reverseIconLookup.Add(d_animationkeyframe, Enum.d_animationkeyframe);
            _iconLookup.Add(Enum.d_animationnocurve, d_animationnocurve);
            _reverseIconLookup.Add(d_animationnocurve, Enum.d_animationnocurve);
            _iconLookup.Add(Enum.d_animationvisibilitytoggleoff, d_animationvisibilitytoggleoff);
            _reverseIconLookup.Add(d_animationvisibilitytoggleoff, Enum.d_animationvisibilitytoggleoff);
            _iconLookup.Add(Enum.d_animationvisibilitytoggleon, d_animationvisibilitytoggleon);
            _reverseIconLookup.Add(d_animationvisibilitytoggleon, Enum.d_animationvisibilitytoggleon);
            _iconLookup.Add(Enum.d_animationwrapmodemenu, d_animationwrapmodemenu);
            _reverseIconLookup.Add(d_animationwrapmodemenu, Enum.d_animationwrapmodemenu);
            _iconLookup.Add(Enum.d_as_badge_delete, d_as_badge_delete);
            _reverseIconLookup.Add(d_as_badge_delete, Enum.d_as_badge_delete);
            _iconLookup.Add(Enum.d_as_badge_new, d_as_badge_new);
            _reverseIconLookup.Add(d_as_badge_new, Enum.d_as_badge_new);
            _iconLookup.Add(Enum.d_assemblylock, d_assemblylock);
            _reverseIconLookup.Add(d_assemblylock, Enum.d_assemblylock);
            _iconLookup.Add(Enum.d_asset_store, d_asset_store);
            _reverseIconLookup.Add(d_asset_store, Enum.d_asset_store);
            _iconLookup.Add(Enum.d_audio_mixer, d_audio_mixer);
            _reverseIconLookup.Add(d_audio_mixer, Enum.d_audio_mixer);
            _iconLookup.Add(Enum.d_autolightbakingoff, d_autolightbakingoff);
            _reverseIconLookup.Add(d_autolightbakingoff, Enum.d_autolightbakingoff);
            _iconLookup.Add(Enum.d_autolightbakingon, d_autolightbakingon);
            _reverseIconLookup.Add(d_autolightbakingon, Enum.d_autolightbakingon);
            _iconLookup.Add(Enum.d_avatarblendbackground, d_avatarblendbackground);
            _reverseIconLookup.Add(d_avatarblendbackground, Enum.d_avatarblendbackground);
            _iconLookup.Add(Enum.d_avatarblendleft, d_avatarblendleft);
            _reverseIconLookup.Add(d_avatarblendleft, Enum.d_avatarblendleft);
            _iconLookup.Add(Enum.d_avatarblendlefta, d_avatarblendlefta);
            _reverseIconLookup.Add(d_avatarblendlefta, Enum.d_avatarblendlefta);
            _iconLookup.Add(Enum.d_avatarblendright, d_avatarblendright);
            _reverseIconLookup.Add(d_avatarblendright, Enum.d_avatarblendright);
            _iconLookup.Add(Enum.d_avatarblendrighta, d_avatarblendrighta);
            _reverseIconLookup.Add(d_avatarblendrighta, Enum.d_avatarblendrighta);
            _iconLookup.Add(Enum.d_avatarcompass, d_avatarcompass);
            _reverseIconLookup.Add(d_avatarcompass, Enum.d_avatarcompass);
            _iconLookup.Add(Enum.d_avatarpivot, d_avatarpivot);
            _reverseIconLookup.Add(d_avatarpivot, Enum.d_avatarpivot);
            _iconLookup.Add(Enum.d_avatarselector, d_avatarselector);
            _reverseIconLookup.Add(d_avatarselector, Enum.d_avatarselector);
            _iconLookup.Add(Enum.d_back, d_back);
            _reverseIconLookup.Add(d_back, Enum.d_back);
            _iconLookup.Add(Enum.d_beginbutton_on, d_beginbutton_on);
            _reverseIconLookup.Add(d_beginbutton_on, Enum.d_beginbutton_on);
            _iconLookup.Add(Enum.d_beginbutton, d_beginbutton);
            _reverseIconLookup.Add(d_beginbutton, Enum.d_beginbutton);
            _iconLookup.Add(Enum.d_bluegroove, d_bluegroove);
            _reverseIconLookup.Add(d_bluegroove, Enum.d_bluegroove);
            _iconLookup.Add(Enum.d_buildsettings_android, d_buildsettings_android);
            _reverseIconLookup.Add(d_buildsettings_android, Enum.d_buildsettings_android);
            _iconLookup.Add(Enum.d_buildsettings_android_small, d_buildsettings_android_small);
            _reverseIconLookup.Add(d_buildsettings_android_small, Enum.d_buildsettings_android_small);
            _iconLookup.Add(Enum.d_buildsettings_broadcom, d_buildsettings_broadcom);
            _reverseIconLookup.Add(d_buildsettings_broadcom, Enum.d_buildsettings_broadcom);
            _iconLookup.Add(Enum.d_buildsettings_facebook, d_buildsettings_facebook);
            _reverseIconLookup.Add(d_buildsettings_facebook, Enum.d_buildsettings_facebook);
            _iconLookup.Add(Enum.d_buildsettings_facebook_small, d_buildsettings_facebook_small);
            _reverseIconLookup.Add(d_buildsettings_facebook_small, Enum.d_buildsettings_facebook_small);
            _iconLookup.Add(Enum.d_buildsettings_flashplayer, d_buildsettings_flashplayer);
            _reverseIconLookup.Add(d_buildsettings_flashplayer, Enum.d_buildsettings_flashplayer);
            _iconLookup.Add(Enum.d_buildsettings_flashplayer_small, d_buildsettings_flashplayer_small);
            _reverseIconLookup.Add(d_buildsettings_flashplayer_small, Enum.d_buildsettings_flashplayer_small);
            _iconLookup.Add(Enum.d_buildsettings_gamecorescarlett, d_buildsettings_gamecorescarlett);
            _reverseIconLookup.Add(d_buildsettings_gamecorescarlett, Enum.d_buildsettings_gamecorescarlett);
            _iconLookup.Add(Enum.d_buildsettings_gamecorescarlett_small, d_buildsettings_gamecorescarlett_small);
            _reverseIconLookup.Add(d_buildsettings_gamecorescarlett_small, Enum.d_buildsettings_gamecorescarlett_small);
            _iconLookup.Add(Enum.d_buildsettings_gamecorexboxone, d_buildsettings_gamecorexboxone);
            _reverseIconLookup.Add(d_buildsettings_gamecorexboxone, Enum.d_buildsettings_gamecorexboxone);
            _iconLookup.Add(Enum.d_buildsettings_gamecorexboxone_small, d_buildsettings_gamecorexboxone_small);
            _reverseIconLookup.Add(d_buildsettings_gamecorexboxone_small, Enum.d_buildsettings_gamecorexboxone_small);
            _iconLookup.Add(Enum.d_buildsettings_iphone, d_buildsettings_iphone);
            _reverseIconLookup.Add(d_buildsettings_iphone, Enum.d_buildsettings_iphone);
            _iconLookup.Add(Enum.d_buildsettings_iphone_small, d_buildsettings_iphone_small);
            _reverseIconLookup.Add(d_buildsettings_iphone_small, Enum.d_buildsettings_iphone_small);
            _iconLookup.Add(Enum.d_buildsettings_lumin, d_buildsettings_lumin);
            _reverseIconLookup.Add(d_buildsettings_lumin, Enum.d_buildsettings_lumin);
            _iconLookup.Add(Enum.d_buildsettings_lumin_small, d_buildsettings_lumin_small);
            _reverseIconLookup.Add(d_buildsettings_lumin_small, Enum.d_buildsettings_lumin_small);
            _iconLookup.Add(Enum.d_buildsettings_metro, d_buildsettings_metro);
            _reverseIconLookup.Add(d_buildsettings_metro, Enum.d_buildsettings_metro);
            _iconLookup.Add(Enum.d_buildsettings_metro_small, d_buildsettings_metro_small);
            _reverseIconLookup.Add(d_buildsettings_metro_small, Enum.d_buildsettings_metro_small);
            _iconLookup.Add(Enum.d_buildsettings_n3ds, d_buildsettings_n3ds);
            _reverseIconLookup.Add(d_buildsettings_n3ds, Enum.d_buildsettings_n3ds);
            _iconLookup.Add(Enum.d_buildsettings_n3ds_small, d_buildsettings_n3ds_small);
            _reverseIconLookup.Add(d_buildsettings_n3ds_small, Enum.d_buildsettings_n3ds_small);
            _iconLookup.Add(Enum.d_buildsettings_ps4, d_buildsettings_ps4);
            _reverseIconLookup.Add(d_buildsettings_ps4, Enum.d_buildsettings_ps4);
            _iconLookup.Add(Enum.d_buildsettings_ps4_small, d_buildsettings_ps4_small);
            _reverseIconLookup.Add(d_buildsettings_ps4_small, Enum.d_buildsettings_ps4_small);
            _iconLookup.Add(Enum.d_buildsettings_ps5, d_buildsettings_ps5);
            _reverseIconLookup.Add(d_buildsettings_ps5, Enum.d_buildsettings_ps5);
            _iconLookup.Add(Enum.d_buildsettings_ps5_small, d_buildsettings_ps5_small);
            _reverseIconLookup.Add(d_buildsettings_ps5_small, Enum.d_buildsettings_ps5_small);
            _iconLookup.Add(Enum.d_buildsettings_psp2, d_buildsettings_psp2);
            _reverseIconLookup.Add(d_buildsettings_psp2, Enum.d_buildsettings_psp2);
            _iconLookup.Add(Enum.d_buildsettings_psp2_small, d_buildsettings_psp2_small);
            _reverseIconLookup.Add(d_buildsettings_psp2_small, Enum.d_buildsettings_psp2_small);
            _iconLookup.Add(Enum.d_buildsettings_selectedicon, d_buildsettings_selectedicon);
            _reverseIconLookup.Add(d_buildsettings_selectedicon, Enum.d_buildsettings_selectedicon);
            _iconLookup.Add(Enum.d_buildsettings_stadia, d_buildsettings_stadia);
            _reverseIconLookup.Add(d_buildsettings_stadia, Enum.d_buildsettings_stadia);
            _iconLookup.Add(Enum.d_buildsettings_stadia_small, d_buildsettings_stadia_small);
            _reverseIconLookup.Add(d_buildsettings_stadia_small, Enum.d_buildsettings_stadia_small);
            _iconLookup.Add(Enum.d_buildsettings_standalone, d_buildsettings_standalone);
            _reverseIconLookup.Add(d_buildsettings_standalone, Enum.d_buildsettings_standalone);
            _iconLookup.Add(Enum.d_buildsettings_standalone_small, d_buildsettings_standalone_small);
            _reverseIconLookup.Add(d_buildsettings_standalone_small, Enum.d_buildsettings_standalone_small);
            _iconLookup.Add(Enum.d_buildsettings_switch, d_buildsettings_switch);
            _reverseIconLookup.Add(d_buildsettings_switch, Enum.d_buildsettings_switch);
            _iconLookup.Add(Enum.d_buildsettings_switch_small, d_buildsettings_switch_small);
            _reverseIconLookup.Add(d_buildsettings_switch_small, Enum.d_buildsettings_switch_small);
            _iconLookup.Add(Enum.d_buildsettings_tvos, d_buildsettings_tvos);
            _reverseIconLookup.Add(d_buildsettings_tvos, Enum.d_buildsettings_tvos);
            _iconLookup.Add(Enum.d_buildsettings_tvos_small, d_buildsettings_tvos_small);
            _reverseIconLookup.Add(d_buildsettings_tvos_small, Enum.d_buildsettings_tvos_small);
            _iconLookup.Add(Enum.d_buildsettings_web, d_buildsettings_web);
            _reverseIconLookup.Add(d_buildsettings_web, Enum.d_buildsettings_web);
            _iconLookup.Add(Enum.d_buildsettings_web_small, d_buildsettings_web_small);
            _reverseIconLookup.Add(d_buildsettings_web_small, Enum.d_buildsettings_web_small);
            _iconLookup.Add(Enum.d_buildsettings_webgl, d_buildsettings_webgl);
            _reverseIconLookup.Add(d_buildsettings_webgl, Enum.d_buildsettings_webgl);
            _iconLookup.Add(Enum.d_buildsettings_webgl_small, d_buildsettings_webgl_small);
            _reverseIconLookup.Add(d_buildsettings_webgl_small, Enum.d_buildsettings_webgl_small);
            _iconLookup.Add(Enum.d_buildsettings_xbox360, d_buildsettings_xbox360);
            _reverseIconLookup.Add(d_buildsettings_xbox360, Enum.d_buildsettings_xbox360);
            _iconLookup.Add(Enum.d_buildsettings_xbox360_small, d_buildsettings_xbox360_small);
            _reverseIconLookup.Add(d_buildsettings_xbox360_small, Enum.d_buildsettings_xbox360_small);
            _iconLookup.Add(Enum.d_buildsettings_xboxone, d_buildsettings_xboxone);
            _reverseIconLookup.Add(d_buildsettings_xboxone, Enum.d_buildsettings_xboxone);
            _iconLookup.Add(Enum.d_buildsettings_xboxone_small, d_buildsettings_xboxone_small);
            _reverseIconLookup.Add(d_buildsettings_xboxone_small, Enum.d_buildsettings_xboxone_small);
            _iconLookup.Add(Enum.d_buildsettings_xiaomi, d_buildsettings_xiaomi);
            _reverseIconLookup.Add(d_buildsettings_xiaomi, Enum.d_buildsettings_xiaomi);
            _iconLookup.Add(Enum.d_buildsettings_xiaomi_small, d_buildsettings_xiaomi_small);
            _reverseIconLookup.Add(d_buildsettings_xiaomi_small, Enum.d_buildsettings_xiaomi_small);
            _iconLookup.Add(Enum.d_cacheserverconnected, d_cacheserverconnected);
            _reverseIconLookup.Add(d_cacheserverconnected, Enum.d_cacheserverconnected);
            _iconLookup.Add(Enum.d_cacheserverdisabled, d_cacheserverdisabled);
            _reverseIconLookup.Add(d_cacheserverdisabled, Enum.d_cacheserverdisabled);
            _iconLookup.Add(Enum.d_cacheserverdisconnected, d_cacheserverdisconnected);
            _reverseIconLookup.Add(d_cacheserverdisconnected, Enum.d_cacheserverdisconnected);
            _iconLookup.Add(Enum.d_checkerfloor, d_checkerfloor);
            _reverseIconLookup.Add(d_checkerfloor, Enum.d_checkerfloor);
            _iconLookup.Add(Enum.d_cloudconnect, d_cloudconnect);
            _reverseIconLookup.Add(d_cloudconnect, Enum.d_cloudconnect);
            _iconLookup.Add(Enum.d_collab_fileadded, d_collab_fileadded);
            _reverseIconLookup.Add(d_collab_fileadded, Enum.d_collab_fileadded);
            _iconLookup.Add(Enum.d_collab_fileconflict, d_collab_fileconflict);
            _reverseIconLookup.Add(d_collab_fileconflict, Enum.d_collab_fileconflict);
            _iconLookup.Add(Enum.d_collab_filedeleted, d_collab_filedeleted);
            _reverseIconLookup.Add(d_collab_filedeleted, Enum.d_collab_filedeleted);
            _iconLookup.Add(Enum.d_collab_fileignored, d_collab_fileignored);
            _reverseIconLookup.Add(d_collab_fileignored, Enum.d_collab_fileignored);
            _iconLookup.Add(Enum.d_collab_filemoved, d_collab_filemoved);
            _reverseIconLookup.Add(d_collab_filemoved, Enum.d_collab_filemoved);
            _iconLookup.Add(Enum.d_collab_fileupdated, d_collab_fileupdated);
            _reverseIconLookup.Add(d_collab_fileupdated, Enum.d_collab_fileupdated);
            _iconLookup.Add(Enum.d_collab_folderadded, d_collab_folderadded);
            _reverseIconLookup.Add(d_collab_folderadded, Enum.d_collab_folderadded);
            _iconLookup.Add(Enum.d_collab_folderconflict, d_collab_folderconflict);
            _reverseIconLookup.Add(d_collab_folderconflict, Enum.d_collab_folderconflict);
            _iconLookup.Add(Enum.d_collab_folderdeleted, d_collab_folderdeleted);
            _reverseIconLookup.Add(d_collab_folderdeleted, Enum.d_collab_folderdeleted);
            _iconLookup.Add(Enum.d_collab_folderignored, d_collab_folderignored);
            _reverseIconLookup.Add(d_collab_folderignored, Enum.d_collab_folderignored);
            _iconLookup.Add(Enum.d_collab_foldermoved, d_collab_foldermoved);
            _reverseIconLookup.Add(d_collab_foldermoved, Enum.d_collab_foldermoved);
            _iconLookup.Add(Enum.d_collab_folderupdated, d_collab_folderupdated);
            _reverseIconLookup.Add(d_collab_folderupdated, Enum.d_collab_folderupdated);
            _iconLookup.Add(Enum.d_collab, d_collab);
            _reverseIconLookup.Add(d_collab, Enum.d_collab);
            _iconLookup.Add(Enum.d_colorpicker_cyclecolor, d_colorpicker_cyclecolor);
            _reverseIconLookup.Add(d_colorpicker_cyclecolor, Enum.d_colorpicker_cyclecolor);
            _iconLookup.Add(Enum.d_colorpicker_cycleslider, d_colorpicker_cycleslider);
            _reverseIconLookup.Add(d_colorpicker_cycleslider, Enum.d_colorpicker_cycleslider);
            _iconLookup.Add(Enum.d_console_erroricon_inactive_sml, d_console_erroricon_inactive_sml);
            _reverseIconLookup.Add(d_console_erroricon_inactive_sml, Enum.d_console_erroricon_inactive_sml);
            _iconLookup.Add(Enum.d_console_erroricon, d_console_erroricon);
            _reverseIconLookup.Add(d_console_erroricon, Enum.d_console_erroricon);
            _iconLookup.Add(Enum.d_console_erroricon_sml, d_console_erroricon_sml);
            _reverseIconLookup.Add(d_console_erroricon_sml, Enum.d_console_erroricon_sml);
            _iconLookup.Add(Enum.d_console_infoicon_inactive_sml, d_console_infoicon_inactive_sml);
            _reverseIconLookup.Add(d_console_infoicon_inactive_sml, Enum.d_console_infoicon_inactive_sml);
            _iconLookup.Add(Enum.d_console_infoicon, d_console_infoicon);
            _reverseIconLookup.Add(d_console_infoicon, Enum.d_console_infoicon);
            _iconLookup.Add(Enum.d_console_infoicon_sml, d_console_infoicon_sml);
            _reverseIconLookup.Add(d_console_infoicon_sml, Enum.d_console_infoicon_sml);
            _iconLookup.Add(Enum.d_console_warnicon_inactive_sml, d_console_warnicon_inactive_sml);
            _reverseIconLookup.Add(d_console_warnicon_inactive_sml, Enum.d_console_warnicon_inactive_sml);
            _iconLookup.Add(Enum.d_console_warnicon, d_console_warnicon);
            _reverseIconLookup.Add(d_console_warnicon, Enum.d_console_warnicon);
            _iconLookup.Add(Enum.d_console_warnicon_sml, d_console_warnicon_sml);
            _reverseIconLookup.Add(d_console_warnicon_sml, Enum.d_console_warnicon_sml);
            _iconLookup.Add(Enum.d_createaddnew, d_createaddnew);
            _reverseIconLookup.Add(d_createaddnew, Enum.d_createaddnew);
            _iconLookup.Add(Enum.d_curvekeyframe, d_curvekeyframe);
            _reverseIconLookup.Add(d_curvekeyframe, Enum.d_curvekeyframe);
            _iconLookup.Add(Enum.d_curvekeyframeselected, d_curvekeyframeselected);
            _reverseIconLookup.Add(d_curvekeyframeselected, Enum.d_curvekeyframeselected);
            _iconLookup.Add(Enum.d_curvekeyframeselectedoverlay, d_curvekeyframeselectedoverlay);
            _reverseIconLookup.Add(d_curvekeyframeselectedoverlay, Enum.d_curvekeyframeselectedoverlay);
            _iconLookup.Add(Enum.d_curvekeyframesemiselectedoverlay, d_curvekeyframesemiselectedoverlay);
            _reverseIconLookup.Add(d_curvekeyframesemiselectedoverlay, Enum.d_curvekeyframesemiselectedoverlay);
            _iconLookup.Add(Enum.d_curvekeyframeweighted, d_curvekeyframeweighted);
            _reverseIconLookup.Add(d_curvekeyframeweighted, Enum.d_curvekeyframeweighted);
            _iconLookup.Add(Enum.d_customsorting, d_customsorting);
            _reverseIconLookup.Add(d_customsorting, Enum.d_customsorting);
            _iconLookup.Add(Enum.d_customtool, d_customtool);
            _reverseIconLookup.Add(d_customtool, Enum.d_customtool);
            _iconLookup.Add(Enum.d_debuggerattached, d_debuggerattached);
            _reverseIconLookup.Add(d_debuggerattached, Enum.d_debuggerattached);
            _iconLookup.Add(Enum.d_debuggerdisabled, d_debuggerdisabled);
            _reverseIconLookup.Add(d_debuggerdisabled, Enum.d_debuggerdisabled);
            _iconLookup.Add(Enum.d_debuggerenabled, d_debuggerenabled);
            _reverseIconLookup.Add(d_debuggerenabled, Enum.d_debuggerenabled);
            _iconLookup.Add(Enum.d_defaultsorting, d_defaultsorting);
            _reverseIconLookup.Add(d_defaultsorting, Enum.d_defaultsorting);
            _iconLookup.Add(Enum.d_editcollider, d_editcollider);
            _reverseIconLookup.Add(d_editcollider, Enum.d_editcollider);
            _iconLookup.Add(Enum.d_editcollision_16, d_editcollision_16);
            _reverseIconLookup.Add(d_editcollision_16, Enum.d_editcollision_16);
            _iconLookup.Add(Enum.d_editcollision_32, d_editcollision_32);
            _reverseIconLookup.Add(d_editcollision_32, Enum.d_editcollision_32);
            _iconLookup.Add(Enum.d_editconstraints_16, d_editconstraints_16);
            _reverseIconLookup.Add(d_editconstraints_16, Enum.d_editconstraints_16);
            _iconLookup.Add(Enum.d_editconstraints_32, d_editconstraints_32);
            _reverseIconLookup.Add(d_editconstraints_32, Enum.d_editconstraints_32);
            _iconLookup.Add(Enum.d_editicon_sml, d_editicon_sml);
            _reverseIconLookup.Add(d_editicon_sml, Enum.d_editicon_sml);
            _iconLookup.Add(Enum.d_endbutton_on, d_endbutton_on);
            _reverseIconLookup.Add(d_endbutton_on, Enum.d_endbutton_on);
            _iconLookup.Add(Enum.d_endbutton, d_endbutton);
            _reverseIconLookup.Add(d_endbutton, Enum.d_endbutton);
            _iconLookup.Add(Enum.d_exposure, d_exposure);
            _reverseIconLookup.Add(d_exposure, Enum.d_exposure);
            _iconLookup.Add(Enum.d_eyedropper_large, d_eyedropper_large);
            _reverseIconLookup.Add(d_eyedropper_large, Enum.d_eyedropper_large);
            _iconLookup.Add(Enum.d_eyedropper_sml, d_eyedropper_sml);
            _reverseIconLookup.Add(d_eyedropper_sml, Enum.d_eyedropper_sml);
            _iconLookup.Add(Enum.d_favorite, d_favorite);
            _reverseIconLookup.Add(d_favorite, Enum.d_favorite);
            _iconLookup.Add(Enum.d_filterbylabel, d_filterbylabel);
            _reverseIconLookup.Add(d_filterbylabel, Enum.d_filterbylabel);
            _iconLookup.Add(Enum.d_filterbytype, d_filterbytype);
            _reverseIconLookup.Add(d_filterbytype, Enum.d_filterbytype);
            _iconLookup.Add(Enum.d_filterselectedonly, d_filterselectedonly);
            _reverseIconLookup.Add(d_filterselectedonly, Enum.d_filterselectedonly);
            _iconLookup.Add(Enum.d_forward, d_forward);
            _reverseIconLookup.Add(d_forward, Enum.d_forward);
            _iconLookup.Add(Enum.d_framecapture, d_framecapture);
            _reverseIconLookup.Add(d_framecapture, Enum.d_framecapture);
            _iconLookup.Add(Enum.d_gear, d_gear);
            _reverseIconLookup.Add(d_gear, Enum.d_gear);
            _iconLookup.Add(Enum.d_gizmostoggle_on, d_gizmostoggle_on);
            _reverseIconLookup.Add(d_gizmostoggle_on, Enum.d_gizmostoggle_on);
            _iconLookup.Add(Enum.d_gizmostoggle, d_gizmostoggle);
            _reverseIconLookup.Add(d_gizmostoggle, Enum.d_gizmostoggle);
            _iconLookup.Add(Enum.d_grid_boxtool, d_grid_boxtool);
            _reverseIconLookup.Add(d_grid_boxtool, Enum.d_grid_boxtool);
            _iconLookup.Add(Enum.d_grid_default, d_grid_default);
            _reverseIconLookup.Add(d_grid_default, Enum.d_grid_default);
            _iconLookup.Add(Enum.d_grid_erasertool, d_grid_erasertool);
            _reverseIconLookup.Add(d_grid_erasertool, Enum.d_grid_erasertool);
            _iconLookup.Add(Enum.d_grid_filltool, d_grid_filltool);
            _reverseIconLookup.Add(d_grid_filltool, Enum.d_grid_filltool);
            _iconLookup.Add(Enum.d_grid_movetool, d_grid_movetool);
            _reverseIconLookup.Add(d_grid_movetool, Enum.d_grid_movetool);
            _iconLookup.Add(Enum.d_grid_painttool, d_grid_painttool);
            _reverseIconLookup.Add(d_grid_painttool, Enum.d_grid_painttool);
            _iconLookup.Add(Enum.d_grid_pickingtool, d_grid_pickingtool);
            _reverseIconLookup.Add(d_grid_pickingtool, Enum.d_grid_pickingtool);
            _iconLookup.Add(Enum.d_groove, d_groove);
            _reverseIconLookup.Add(d_groove, Enum.d_groove);
            _iconLookup.Add(Enum.d_horizontalsplit, d_horizontalsplit);
            _reverseIconLookup.Add(d_horizontalsplit, Enum.d_horizontalsplit);
            _iconLookup.Add(Enum.d_icon_dropdown, d_icon_dropdown);
            _reverseIconLookup.Add(d_icon_dropdown, Enum.d_icon_dropdown);
            _iconLookup.Add(Enum.d_import, d_import);
            _reverseIconLookup.Add(d_import, Enum.d_import);
            _iconLookup.Add(Enum.d_inspectorlock, d_inspectorlock);
            _reverseIconLookup.Add(d_inspectorlock, Enum.d_inspectorlock);
            _iconLookup.Add(Enum.d_invalid, d_invalid);
            _reverseIconLookup.Add(d_invalid, Enum.d_invalid);
            _iconLookup.Add(Enum.d_jointangularlimits, d_jointangularlimits);
            _reverseIconLookup.Add(d_jointangularlimits, Enum.d_jointangularlimits);
            _iconLookup.Add(Enum.d_leftbracket, d_leftbracket);
            _reverseIconLookup.Add(d_leftbracket, Enum.d_leftbracket);
            _iconLookup.Add(Enum.d_lighting, d_lighting);
            _reverseIconLookup.Add(d_lighting, Enum.d_lighting);
            _iconLookup.Add(Enum.d_lightmapeditor_windowtitle, d_lightmapeditor_windowtitle);
            _reverseIconLookup.Add(d_lightmapeditor_windowtitle, Enum.d_lightmapeditor_windowtitle);
            _iconLookup.Add(Enum.d_linked, d_linked);
            _reverseIconLookup.Add(d_linked, Enum.d_linked);
            _iconLookup.Add(Enum.d_mainstageview, d_mainstageview);
            _reverseIconLookup.Add(d_mainstageview, Enum.d_mainstageview);
            _iconLookup.Add(Enum.d_mirror, d_mirror);
            _reverseIconLookup.Add(d_mirror, Enum.d_mirror);
            _iconLookup.Add(Enum.d_model_large, d_model_large);
            _reverseIconLookup.Add(d_model_large, Enum.d_model_large);
            _iconLookup.Add(Enum.d_monologo, d_monologo);
            _reverseIconLookup.Add(d_monologo, Enum.d_monologo);
            _iconLookup.Add(Enum.d_moreoptions, d_moreoptions);
            _reverseIconLookup.Add(d_moreoptions, Enum.d_moreoptions);
            _iconLookup.Add(Enum.d_movetool_on, d_movetool_on);
            _reverseIconLookup.Add(d_movetool_on, Enum.d_movetool_on);
            _iconLookup.Add(Enum.d_movetool, d_movetool);
            _reverseIconLookup.Add(d_movetool, Enum.d_movetool);
            _iconLookup.Add(Enum.d_navigation, d_navigation);
            _reverseIconLookup.Add(d_navigation, Enum.d_navigation);
            _iconLookup.Add(Enum.d_occlusion, d_occlusion);
            _reverseIconLookup.Add(d_occlusion, Enum.d_occlusion);
            _iconLookup.Add(Enum.d_package_manager, d_package_manager);
            _reverseIconLookup.Add(d_package_manager, Enum.d_package_manager);
            _iconLookup.Add(Enum.d_particle_effect, d_particle_effect);
            _reverseIconLookup.Add(d_particle_effect, Enum.d_particle_effect);
            _iconLookup.Add(Enum.d_particleshapetool_on, d_particleshapetool_on);
            _reverseIconLookup.Add(d_particleshapetool_on, Enum.d_particleshapetool_on);
            _iconLookup.Add(Enum.d_particleshapetool, d_particleshapetool);
            _reverseIconLookup.Add(d_particleshapetool, Enum.d_particleshapetool);
            _iconLookup.Add(Enum.d_pausebutton_on, d_pausebutton_on);
            _reverseIconLookup.Add(d_pausebutton_on, Enum.d_pausebutton_on);
            _iconLookup.Add(Enum.d_pausebutton, d_pausebutton);
            _reverseIconLookup.Add(d_pausebutton, Enum.d_pausebutton);
            _iconLookup.Add(Enum.d_playbutton_on, d_playbutton_on);
            _reverseIconLookup.Add(d_playbutton_on, Enum.d_playbutton_on);
            _iconLookup.Add(Enum.d_playbutton, d_playbutton);
            _reverseIconLookup.Add(d_playbutton, Enum.d_playbutton);
            _iconLookup.Add(Enum.d_playbuttonprofile_on, d_playbuttonprofile_on);
            _reverseIconLookup.Add(d_playbuttonprofile_on, Enum.d_playbuttonprofile_on);
            _iconLookup.Add(Enum.d_playbuttonprofile, d_playbuttonprofile);
            _reverseIconLookup.Add(d_playbuttonprofile, Enum.d_playbuttonprofile);
            _iconLookup.Add(Enum.d_playloopoff, d_playloopoff);
            _reverseIconLookup.Add(d_playloopoff, Enum.d_playloopoff);
            _iconLookup.Add(Enum.d_playloopon, d_playloopon);
            _reverseIconLookup.Add(d_playloopon, Enum.d_playloopon);
            _iconLookup.Add(Enum.d_preaudioautoplayoff, d_preaudioautoplayoff);
            _reverseIconLookup.Add(d_preaudioautoplayoff, Enum.d_preaudioautoplayoff);
            _iconLookup.Add(Enum.d_preaudioautoplayon, d_preaudioautoplayon);
            _reverseIconLookup.Add(d_preaudioautoplayon, Enum.d_preaudioautoplayon);
            _iconLookup.Add(Enum.d_preaudioloopoff, d_preaudioloopoff);
            _reverseIconLookup.Add(d_preaudioloopoff, Enum.d_preaudioloopoff);
            _iconLookup.Add(Enum.d_preaudioloopon, d_preaudioloopon);
            _reverseIconLookup.Add(d_preaudioloopon, Enum.d_preaudioloopon);
            _iconLookup.Add(Enum.d_preaudioplayoff, d_preaudioplayoff);
            _reverseIconLookup.Add(d_preaudioplayoff, Enum.d_preaudioplayoff);
            _iconLookup.Add(Enum.d_preaudioplayon, d_preaudioplayon);
            _reverseIconLookup.Add(d_preaudioplayon, Enum.d_preaudioplayon);
            _iconLookup.Add(Enum.d_prematcube, d_prematcube);
            _reverseIconLookup.Add(d_prematcube, Enum.d_prematcube);
            _iconLookup.Add(Enum.d_prematcylinder, d_prematcylinder);
            _reverseIconLookup.Add(d_prematcylinder, Enum.d_prematcylinder);
            _iconLookup.Add(Enum.d_prematlight0, d_prematlight0);
            _reverseIconLookup.Add(d_prematlight0, Enum.d_prematlight0);
            _iconLookup.Add(Enum.d_prematlight1, d_prematlight1);
            _reverseIconLookup.Add(d_prematlight1, Enum.d_prematlight1);
            _iconLookup.Add(Enum.d_prematquad, d_prematquad);
            _reverseIconLookup.Add(d_prematquad, Enum.d_prematquad);
            _iconLookup.Add(Enum.d_prematsphere, d_prematsphere);
            _reverseIconLookup.Add(d_prematsphere, Enum.d_prematsphere);
            _iconLookup.Add(Enum.d_premattorus, d_premattorus);
            _reverseIconLookup.Add(d_premattorus, Enum.d_premattorus);
            _iconLookup.Add(Enum.d_preset_context, d_preset_context);
            _reverseIconLookup.Add(d_preset_context, Enum.d_preset_context);
            _iconLookup.Add(Enum.d_pretexa, d_pretexa);
            _reverseIconLookup.Add(d_pretexa, Enum.d_pretexa);
            _iconLookup.Add(Enum.d_pretexb, d_pretexb);
            _reverseIconLookup.Add(d_pretexb, Enum.d_pretexb);
            _iconLookup.Add(Enum.d_pretexg, d_pretexg);
            _reverseIconLookup.Add(d_pretexg, Enum.d_pretexg);
            _iconLookup.Add(Enum.d_pretexr, d_pretexr);
            _reverseIconLookup.Add(d_pretexr, Enum.d_pretexr);
            _iconLookup.Add(Enum.d_pretexrgb, d_pretexrgb);
            _reverseIconLookup.Add(d_pretexrgb, Enum.d_pretexrgb);
            _iconLookup.Add(Enum.d_pretexturealpha, d_pretexturealpha);
            _reverseIconLookup.Add(d_pretexturealpha, Enum.d_pretexturealpha);
            _iconLookup.Add(Enum.d_pretexturemipmaphigh, d_pretexturemipmaphigh);
            _reverseIconLookup.Add(d_pretexturemipmaphigh, Enum.d_pretexturemipmaphigh);
            _iconLookup.Add(Enum.d_pretexturemipmaplow, d_pretexturemipmaplow);
            _reverseIconLookup.Add(d_pretexturemipmaplow, Enum.d_pretexturemipmaplow);
            _iconLookup.Add(Enum.d_pretexturergb, d_pretexturergb);
            _reverseIconLookup.Add(d_pretexturergb, Enum.d_pretexturergb);
            _iconLookup.Add(Enum.d_profiler_audio, d_profiler_audio);
            _reverseIconLookup.Add(d_profiler_audio, Enum.d_profiler_audio);
            _iconLookup.Add(Enum.d_profiler_cpu, d_profiler_cpu);
            _reverseIconLookup.Add(d_profiler_cpu, Enum.d_profiler_cpu);
            _iconLookup.Add(Enum.d_profiler_custom, d_profiler_custom);
            _reverseIconLookup.Add(d_profiler_custom, Enum.d_profiler_custom);
            _iconLookup.Add(Enum.d_profiler_firstframe, d_profiler_firstframe);
            _reverseIconLookup.Add(d_profiler_firstframe, Enum.d_profiler_firstframe);
            _iconLookup.Add(Enum.d_profiler_globalillumination, d_profiler_globalillumination);
            _reverseIconLookup.Add(d_profiler_globalillumination, Enum.d_profiler_globalillumination);
            _iconLookup.Add(Enum.d_profiler_gpu, d_profiler_gpu);
            _reverseIconLookup.Add(d_profiler_gpu, Enum.d_profiler_gpu);
            _iconLookup.Add(Enum.d_profiler_lastframe, d_profiler_lastframe);
            _reverseIconLookup.Add(d_profiler_lastframe, Enum.d_profiler_lastframe);
            _iconLookup.Add(Enum.d_profiler_memory, d_profiler_memory);
            _reverseIconLookup.Add(d_profiler_memory, Enum.d_profiler_memory);
            _iconLookup.Add(Enum.d_profiler_network, d_profiler_network);
            _reverseIconLookup.Add(d_profiler_network, Enum.d_profiler_network);
            _iconLookup.Add(Enum.d_profiler_networkmessages, d_profiler_networkmessages);
            _reverseIconLookup.Add(d_profiler_networkmessages, Enum.d_profiler_networkmessages);
            _iconLookup.Add(Enum.d_profiler_networkoperations, d_profiler_networkoperations);
            _reverseIconLookup.Add(d_profiler_networkoperations, Enum.d_profiler_networkoperations);
            _iconLookup.Add(Enum.d_profiler_nextframe, d_profiler_nextframe);
            _reverseIconLookup.Add(d_profiler_nextframe, Enum.d_profiler_nextframe);
            _iconLookup.Add(Enum.d_profiler_open, d_profiler_open);
            _reverseIconLookup.Add(d_profiler_open, Enum.d_profiler_open);
            _iconLookup.Add(Enum.d_profiler_physics, d_profiler_physics);
            _reverseIconLookup.Add(d_profiler_physics, Enum.d_profiler_physics);
            _iconLookup.Add(Enum.d_profiler_physics2d, d_profiler_physics2d);
            _reverseIconLookup.Add(d_profiler_physics2d, Enum.d_profiler_physics2d);
            _iconLookup.Add(Enum.d_profiler_prevframe, d_profiler_prevframe);
            _reverseIconLookup.Add(d_profiler_prevframe, Enum.d_profiler_prevframe);
            _iconLookup.Add(Enum.d_profiler_record, d_profiler_record);
            _reverseIconLookup.Add(d_profiler_record, Enum.d_profiler_record);
            _iconLookup.Add(Enum.d_profiler_rendering, d_profiler_rendering);
            _reverseIconLookup.Add(d_profiler_rendering, Enum.d_profiler_rendering);
            _iconLookup.Add(Enum.d_profiler_ui, d_profiler_ui);
            _reverseIconLookup.Add(d_profiler_ui, Enum.d_profiler_ui);
            _iconLookup.Add(Enum.d_profiler_uidetails, d_profiler_uidetails);
            _reverseIconLookup.Add(d_profiler_uidetails, Enum.d_profiler_uidetails);
            _iconLookup.Add(Enum.d_profiler_video, d_profiler_video);
            _reverseIconLookup.Add(d_profiler_video, Enum.d_profiler_video);
            _iconLookup.Add(Enum.d_profiler_virtualtexturing, d_profiler_virtualtexturing);
            _reverseIconLookup.Add(d_profiler_virtualtexturing, Enum.d_profiler_virtualtexturing);
            _iconLookup.Add(Enum.d_profilercolumn_warningcount, d_profilercolumn_warningcount);
            _reverseIconLookup.Add(d_profilercolumn_warningcount, Enum.d_profilercolumn_warningcount);
            _iconLookup.Add(Enum.d_progress, d_progress);
            _reverseIconLookup.Add(d_progress, Enum.d_progress);
            _iconLookup.Add(Enum.d_project, d_project);
            _reverseIconLookup.Add(d_project, Enum.d_project);
            _iconLookup.Add(Enum.d_record_off, d_record_off);
            _reverseIconLookup.Add(d_record_off, Enum.d_record_off);
            _iconLookup.Add(Enum.d_record_on, d_record_on);
            _reverseIconLookup.Add(d_record_on, Enum.d_record_on);
            _iconLookup.Add(Enum.d_recttool_on, d_recttool_on);
            _reverseIconLookup.Add(d_recttool_on, Enum.d_recttool_on);
            _iconLookup.Add(Enum.d_recttool, d_recttool);
            _reverseIconLookup.Add(d_recttool, Enum.d_recttool);
            _iconLookup.Add(Enum.d_recttransformblueprint, d_recttransformblueprint);
            _reverseIconLookup.Add(d_recttransformblueprint, Enum.d_recttransformblueprint);
            _iconLookup.Add(Enum.d_recttransformraw, d_recttransformraw);
            _reverseIconLookup.Add(d_recttransformraw, Enum.d_recttransformraw);
            _iconLookup.Add(Enum.d_redgroove, d_redgroove);
            _reverseIconLookup.Add(d_redgroove, Enum.d_redgroove);
            _iconLookup.Add(Enum.d_reflectionprobeselector, d_reflectionprobeselector);
            _reverseIconLookup.Add(d_reflectionprobeselector, Enum.d_reflectionprobeselector);
            _iconLookup.Add(Enum.d_refresh, d_refresh);
            _reverseIconLookup.Add(d_refresh, Enum.d_refresh);
            _iconLookup.Add(Enum.d_rightbracket, d_rightbracket);
            _reverseIconLookup.Add(d_rightbracket, Enum.d_rightbracket);
            _iconLookup.Add(Enum.d_rotatetool_on, d_rotatetool_on);
            _reverseIconLookup.Add(d_rotatetool_on, Enum.d_rotatetool_on);
            _iconLookup.Add(Enum.d_rotatetool, d_rotatetool);
            _reverseIconLookup.Add(d_rotatetool, Enum.d_rotatetool);
            _iconLookup.Add(Enum.d_saveas, d_saveas);
            _reverseIconLookup.Add(d_saveas, Enum.d_saveas);
            _iconLookup.Add(Enum.d_scaletool_on, d_scaletool_on);
            _reverseIconLookup.Add(d_scaletool_on, Enum.d_scaletool_on);
            _iconLookup.Add(Enum.d_scaletool, d_scaletool);
            _reverseIconLookup.Add(d_scaletool, Enum.d_scaletool);
            _iconLookup.Add(Enum.d_scenepicking_notpickable_mixed, d_scenepicking_notpickable_mixed);
            _reverseIconLookup.Add(d_scenepicking_notpickable_mixed, Enum.d_scenepicking_notpickable_mixed);
            _iconLookup.Add(Enum.d_scenepicking_notpickable_mixed_hover, d_scenepicking_notpickable_mixed_hover);
            _reverseIconLookup.Add(d_scenepicking_notpickable_mixed_hover, Enum.d_scenepicking_notpickable_mixed_hover);
            _iconLookup.Add(Enum.d_scenepicking_notpickable, d_scenepicking_notpickable);
            _reverseIconLookup.Add(d_scenepicking_notpickable, Enum.d_scenepicking_notpickable);
            _iconLookup.Add(Enum.d_scenepicking_notpickable_hover, d_scenepicking_notpickable_hover);
            _reverseIconLookup.Add(d_scenepicking_notpickable_hover, Enum.d_scenepicking_notpickable_hover);
            _iconLookup.Add(Enum.d_scenepicking_pickable_mixed, d_scenepicking_pickable_mixed);
            _reverseIconLookup.Add(d_scenepicking_pickable_mixed, Enum.d_scenepicking_pickable_mixed);
            _iconLookup.Add(Enum.d_scenepicking_pickable_mixed_hover, d_scenepicking_pickable_mixed_hover);
            _reverseIconLookup.Add(d_scenepicking_pickable_mixed_hover, Enum.d_scenepicking_pickable_mixed_hover);
            _iconLookup.Add(Enum.d_scenepicking_pickable, d_scenepicking_pickable);
            _reverseIconLookup.Add(d_scenepicking_pickable, Enum.d_scenepicking_pickable);
            _iconLookup.Add(Enum.d_scenepicking_pickable_hover, d_scenepicking_pickable_hover);
            _reverseIconLookup.Add(d_scenepicking_pickable_hover, Enum.d_scenepicking_pickable_hover);
            _iconLookup.Add(Enum.d_sceneview2d_on, d_sceneview2d_on);
            _reverseIconLookup.Add(d_sceneview2d_on, Enum.d_sceneview2d_on);
            _iconLookup.Add(Enum.d_sceneview2d, d_sceneview2d);
            _reverseIconLookup.Add(d_sceneview2d, Enum.d_sceneview2d);
            _iconLookup.Add(Enum.d_sceneviewalpha, d_sceneviewalpha);
            _reverseIconLookup.Add(d_sceneviewalpha, Enum.d_sceneviewalpha);
            _iconLookup.Add(Enum.d_sceneviewaudio_on, d_sceneviewaudio_on);
            _reverseIconLookup.Add(d_sceneviewaudio_on, Enum.d_sceneviewaudio_on);
            _iconLookup.Add(Enum.d_sceneviewaudio, d_sceneviewaudio);
            _reverseIconLookup.Add(d_sceneviewaudio, Enum.d_sceneviewaudio);
            _iconLookup.Add(Enum.d_sceneviewcamera, d_sceneviewcamera);
            _reverseIconLookup.Add(d_sceneviewcamera, Enum.d_sceneviewcamera);
            _iconLookup.Add(Enum.d_sceneviewfx_on, d_sceneviewfx_on);
            _reverseIconLookup.Add(d_sceneviewfx_on, Enum.d_sceneviewfx_on);
            _iconLookup.Add(Enum.d_sceneviewfx, d_sceneviewfx);
            _reverseIconLookup.Add(d_sceneviewfx, Enum.d_sceneviewfx);
            _iconLookup.Add(Enum.d_sceneviewlighting_on, d_sceneviewlighting_on);
            _reverseIconLookup.Add(d_sceneviewlighting_on, Enum.d_sceneviewlighting_on);
            _iconLookup.Add(Enum.d_sceneviewlighting, d_sceneviewlighting);
            _reverseIconLookup.Add(d_sceneviewlighting, Enum.d_sceneviewlighting);
            _iconLookup.Add(Enum.d_sceneviewortho, d_sceneviewortho);
            _reverseIconLookup.Add(d_sceneviewortho, Enum.d_sceneviewortho);
            _iconLookup.Add(Enum.d_sceneviewrgb, d_sceneviewrgb);
            _reverseIconLookup.Add(d_sceneviewrgb, Enum.d_sceneviewrgb);
            _iconLookup.Add(Enum.d_sceneviewtools, d_sceneviewtools);
            _reverseIconLookup.Add(d_sceneviewtools, Enum.d_sceneviewtools);
            _iconLookup.Add(Enum.d_sceneviewvisibility_on, d_sceneviewvisibility_on);
            _reverseIconLookup.Add(d_sceneviewvisibility_on, Enum.d_sceneviewvisibility_on);
            _iconLookup.Add(Enum.d_sceneviewvisibility, d_sceneviewvisibility);
            _reverseIconLookup.Add(d_sceneviewvisibility, Enum.d_sceneviewvisibility);
            _iconLookup.Add(Enum.d_scenevis_hidden_mixed, d_scenevis_hidden_mixed);
            _reverseIconLookup.Add(d_scenevis_hidden_mixed, Enum.d_scenevis_hidden_mixed);
            _iconLookup.Add(Enum.d_scenevis_hidden_mixed_hover, d_scenevis_hidden_mixed_hover);
            _reverseIconLookup.Add(d_scenevis_hidden_mixed_hover, Enum.d_scenevis_hidden_mixed_hover);
            _iconLookup.Add(Enum.d_scenevis_hidden, d_scenevis_hidden);
            _reverseIconLookup.Add(d_scenevis_hidden, Enum.d_scenevis_hidden);
            _iconLookup.Add(Enum.d_scenevis_hidden_hover, d_scenevis_hidden_hover);
            _reverseIconLookup.Add(d_scenevis_hidden_hover, Enum.d_scenevis_hidden_hover);
            _iconLookup.Add(Enum.d_scenevis_scene_hover, d_scenevis_scene_hover);
            _reverseIconLookup.Add(d_scenevis_scene_hover, Enum.d_scenevis_scene_hover);
            _iconLookup.Add(Enum.d_scenevis_visible_mixed, d_scenevis_visible_mixed);
            _reverseIconLookup.Add(d_scenevis_visible_mixed, Enum.d_scenevis_visible_mixed);
            _iconLookup.Add(Enum.d_scenevis_visible_mixed_hover, d_scenevis_visible_mixed_hover);
            _reverseIconLookup.Add(d_scenevis_visible_mixed_hover, Enum.d_scenevis_visible_mixed_hover);
            _iconLookup.Add(Enum.d_scenevis_visible, d_scenevis_visible);
            _reverseIconLookup.Add(d_scenevis_visible, Enum.d_scenevis_visible);
            _iconLookup.Add(Enum.d_scenevis_visible_hover, d_scenevis_visible_hover);
            _reverseIconLookup.Add(d_scenevis_visible_hover, Enum.d_scenevis_visible_hover);
            _iconLookup.Add(Enum.d_scrollshadow, d_scrollshadow);
            _reverseIconLookup.Add(d_scrollshadow, Enum.d_scrollshadow);
            _iconLookup.Add(Enum.d_settings, d_settings);
            _reverseIconLookup.Add(d_settings, Enum.d_settings);
            _iconLookup.Add(Enum.d_settingsicon, d_settingsicon);
            _reverseIconLookup.Add(d_settingsicon, Enum.d_settingsicon);
            _iconLookup.Add(Enum.d_showpanels, d_showpanels);
            _reverseIconLookup.Add(d_showpanels, Enum.d_showpanels);
            _iconLookup.Add(Enum.d_socialnetworks_facebookshare, d_socialnetworks_facebookshare);
            _reverseIconLookup.Add(d_socialnetworks_facebookshare, Enum.d_socialnetworks_facebookshare);
            _iconLookup.Add(Enum.d_socialnetworks_linkedinshare, d_socialnetworks_linkedinshare);
            _reverseIconLookup.Add(d_socialnetworks_linkedinshare, Enum.d_socialnetworks_linkedinshare);
            _iconLookup.Add(Enum.d_socialnetworks_tweet, d_socialnetworks_tweet);
            _reverseIconLookup.Add(d_socialnetworks_tweet, Enum.d_socialnetworks_tweet);
            _iconLookup.Add(Enum.d_socialnetworks_udnopen, d_socialnetworks_udnopen);
            _reverseIconLookup.Add(d_socialnetworks_udnopen, Enum.d_socialnetworks_udnopen);
            _iconLookup.Add(Enum.d_speedscale, d_speedscale);
            _reverseIconLookup.Add(d_speedscale, Enum.d_speedscale);
            _iconLookup.Add(Enum.d_stepbutton_on, d_stepbutton_on);
            _reverseIconLookup.Add(d_stepbutton_on, Enum.d_stepbutton_on);
            _iconLookup.Add(Enum.d_stepbutton, d_stepbutton);
            _reverseIconLookup.Add(d_stepbutton, Enum.d_stepbutton);
            _iconLookup.Add(Enum.d_stepleftbutton_on, d_stepleftbutton_on);
            _reverseIconLookup.Add(d_stepleftbutton_on, Enum.d_stepleftbutton_on);
            _iconLookup.Add(Enum.d_stepleftbutton, d_stepleftbutton);
            _reverseIconLookup.Add(d_stepleftbutton, Enum.d_stepleftbutton);
            _iconLookup.Add(Enum.d_tab_next, d_tab_next);
            _reverseIconLookup.Add(d_tab_next, Enum.d_tab_next);
            _iconLookup.Add(Enum.d_tab_prev, d_tab_prev);
            _reverseIconLookup.Add(d_tab_prev, Enum.d_tab_prev);
            _iconLookup.Add(Enum.d_terraininspector_terraintooladd, d_terraininspector_terraintooladd);
            _reverseIconLookup.Add(d_terraininspector_terraintooladd, Enum.d_terraininspector_terraintooladd);
            _iconLookup.Add(Enum.d_terraininspector_terraintoollower_on, d_terraininspector_terraintoollower_on);
            _reverseIconLookup.Add(d_terraininspector_terraintoollower_on, Enum.d_terraininspector_terraintoollower_on);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolloweralt, d_terraininspector_terraintoolloweralt);
            _reverseIconLookup.Add(d_terraininspector_terraintoolloweralt, Enum.d_terraininspector_terraintoolloweralt);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolplants_on, d_terraininspector_terraintoolplants_on);
            _reverseIconLookup.Add(d_terraininspector_terraintoolplants_on, Enum.d_terraininspector_terraintoolplants_on);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolplants, d_terraininspector_terraintoolplants);
            _reverseIconLookup.Add(d_terraininspector_terraintoolplants, Enum.d_terraininspector_terraintoolplants);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolplantsalt_on, d_terraininspector_terraintoolplantsalt_on);
            _reverseIconLookup.Add(d_terraininspector_terraintoolplantsalt_on, Enum.d_terraininspector_terraintoolplantsalt_on);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolplantsalt, d_terraininspector_terraintoolplantsalt);
            _reverseIconLookup.Add(d_terraininspector_terraintoolplantsalt, Enum.d_terraininspector_terraintoolplantsalt);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolraise_on, d_terraininspector_terraintoolraise_on);
            _reverseIconLookup.Add(d_terraininspector_terraintoolraise_on, Enum.d_terraininspector_terraintoolraise_on);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolraise, d_terraininspector_terraintoolraise);
            _reverseIconLookup.Add(d_terraininspector_terraintoolraise, Enum.d_terraininspector_terraintoolraise);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolsetheight_on, d_terraininspector_terraintoolsetheight_on);
            _reverseIconLookup.Add(d_terraininspector_terraintoolsetheight_on, Enum.d_terraininspector_terraintoolsetheight_on);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolsetheight, d_terraininspector_terraintoolsetheight);
            _reverseIconLookup.Add(d_terraininspector_terraintoolsetheight, Enum.d_terraininspector_terraintoolsetheight);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolsetheightalt_on, d_terraininspector_terraintoolsetheightalt_on);
            _reverseIconLookup.Add(d_terraininspector_terraintoolsetheightalt_on, Enum.d_terraininspector_terraintoolsetheightalt_on);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolsetheightalt, d_terraininspector_terraintoolsetheightalt);
            _reverseIconLookup.Add(d_terraininspector_terraintoolsetheightalt, Enum.d_terraininspector_terraintoolsetheightalt);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolsettings_on, d_terraininspector_terraintoolsettings_on);
            _reverseIconLookup.Add(d_terraininspector_terraintoolsettings_on, Enum.d_terraininspector_terraintoolsettings_on);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolsettings, d_terraininspector_terraintoolsettings);
            _reverseIconLookup.Add(d_terraininspector_terraintoolsettings, Enum.d_terraininspector_terraintoolsettings);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolsmoothheight_on, d_terraininspector_terraintoolsmoothheight_on);
            _reverseIconLookup.Add(d_terraininspector_terraintoolsmoothheight_on, Enum.d_terraininspector_terraintoolsmoothheight_on);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolsmoothheight, d_terraininspector_terraintoolsmoothheight);
            _reverseIconLookup.Add(d_terraininspector_terraintoolsmoothheight, Enum.d_terraininspector_terraintoolsmoothheight);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolsplat_on, d_terraininspector_terraintoolsplat_on);
            _reverseIconLookup.Add(d_terraininspector_terraintoolsplat_on, Enum.d_terraininspector_terraintoolsplat_on);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolsplat, d_terraininspector_terraintoolsplat);
            _reverseIconLookup.Add(d_terraininspector_terraintoolsplat, Enum.d_terraininspector_terraintoolsplat);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolsplatalt_on, d_terraininspector_terraintoolsplatalt_on);
            _reverseIconLookup.Add(d_terraininspector_terraintoolsplatalt_on, Enum.d_terraininspector_terraintoolsplatalt_on);
            _iconLookup.Add(Enum.d_terraininspector_terraintoolsplatalt, d_terraininspector_terraintoolsplatalt);
            _reverseIconLookup.Add(d_terraininspector_terraintoolsplatalt, Enum.d_terraininspector_terraintoolsplatalt);
            _iconLookup.Add(Enum.d_terraininspector_terraintooltrees_on, d_terraininspector_terraintooltrees_on);
            _reverseIconLookup.Add(d_terraininspector_terraintooltrees_on, Enum.d_terraininspector_terraintooltrees_on);
            _iconLookup.Add(Enum.d_terraininspector_terraintooltrees, d_terraininspector_terraintooltrees);
            _reverseIconLookup.Add(d_terraininspector_terraintooltrees, Enum.d_terraininspector_terraintooltrees);
            _iconLookup.Add(Enum.d_terraininspector_terraintooltreesalt_on, d_terraininspector_terraintooltreesalt_on);
            _reverseIconLookup.Add(d_terraininspector_terraintooltreesalt_on, Enum.d_terraininspector_terraintooltreesalt_on);
            _iconLookup.Add(Enum.d_terraininspector_terraintooltreesalt, d_terraininspector_terraintooltreesalt);
            _reverseIconLookup.Add(d_terraininspector_terraintooltreesalt, Enum.d_terraininspector_terraintooltreesalt);
            _iconLookup.Add(Enum.d_toggleuvoverlay, d_toggleuvoverlay);
            _reverseIconLookup.Add(d_toggleuvoverlay, Enum.d_toggleuvoverlay);
            _iconLookup.Add(Enum.d_toolbar_minus, d_toolbar_minus);
            _reverseIconLookup.Add(d_toolbar_minus, Enum.d_toolbar_minus);
            _iconLookup.Add(Enum.d_toolbar_plus_more, d_toolbar_plus_more);
            _reverseIconLookup.Add(d_toolbar_plus_more, Enum.d_toolbar_plus_more);
            _iconLookup.Add(Enum.d_toolbar_plus, d_toolbar_plus);
            _reverseIconLookup.Add(d_toolbar_plus, Enum.d_toolbar_plus);
            _iconLookup.Add(Enum.d_toolhandlecenter, d_toolhandlecenter);
            _reverseIconLookup.Add(d_toolhandlecenter, Enum.d_toolhandlecenter);
            _iconLookup.Add(Enum.d_toolhandleglobal, d_toolhandleglobal);
            _reverseIconLookup.Add(d_toolhandleglobal, Enum.d_toolhandleglobal);
            _iconLookup.Add(Enum.d_toolhandlelocal, d_toolhandlelocal);
            _reverseIconLookup.Add(d_toolhandlelocal, Enum.d_toolhandlelocal);
            _iconLookup.Add(Enum.d_toolhandlepivot, d_toolhandlepivot);
            _reverseIconLookup.Add(d_toolhandlepivot, Enum.d_toolhandlepivot);
            _iconLookup.Add(Enum.d_toolsicon, d_toolsicon);
            _reverseIconLookup.Add(d_toolsicon, Enum.d_toolsicon);
            _iconLookup.Add(Enum.d_tranp, d_tranp);
            _reverseIconLookup.Add(d_tranp, Enum.d_tranp);
            _iconLookup.Add(Enum.d_transformtool_on, d_transformtool_on);
            _reverseIconLookup.Add(d_transformtool_on, Enum.d_transformtool_on);
            _iconLookup.Add(Enum.d_transformtool, d_transformtool);
            _reverseIconLookup.Add(d_transformtool, Enum.d_transformtool);
            _iconLookup.Add(Enum.d_tree_icon, d_tree_icon);
            _reverseIconLookup.Add(d_tree_icon, Enum.d_tree_icon);
            _iconLookup.Add(Enum.d_tree_icon_branch, d_tree_icon_branch);
            _reverseIconLookup.Add(d_tree_icon_branch, Enum.d_tree_icon_branch);
            _iconLookup.Add(Enum.d_tree_icon_branch_frond, d_tree_icon_branch_frond);
            _reverseIconLookup.Add(d_tree_icon_branch_frond, Enum.d_tree_icon_branch_frond);
            _iconLookup.Add(Enum.d_tree_icon_frond, d_tree_icon_frond);
            _reverseIconLookup.Add(d_tree_icon_frond, Enum.d_tree_icon_frond);
            _iconLookup.Add(Enum.d_tree_icon_leaf, d_tree_icon_leaf);
            _reverseIconLookup.Add(d_tree_icon_leaf, Enum.d_tree_icon_leaf);
            _iconLookup.Add(Enum.d_treeeditor_addbranches, d_treeeditor_addbranches);
            _reverseIconLookup.Add(d_treeeditor_addbranches, Enum.d_treeeditor_addbranches);
            _iconLookup.Add(Enum.d_treeeditor_addleaves, d_treeeditor_addleaves);
            _reverseIconLookup.Add(d_treeeditor_addleaves, Enum.d_treeeditor_addleaves);
            _iconLookup.Add(Enum.d_treeeditor_branch_on, d_treeeditor_branch_on);
            _reverseIconLookup.Add(d_treeeditor_branch_on, Enum.d_treeeditor_branch_on);
            _iconLookup.Add(Enum.d_treeeditor_branch, d_treeeditor_branch);
            _reverseIconLookup.Add(d_treeeditor_branch, Enum.d_treeeditor_branch);
            _iconLookup.Add(Enum.d_treeeditor_branchfreehand_on, d_treeeditor_branchfreehand_on);
            _reverseIconLookup.Add(d_treeeditor_branchfreehand_on, Enum.d_treeeditor_branchfreehand_on);
            _iconLookup.Add(Enum.d_treeeditor_branchfreehand, d_treeeditor_branchfreehand);
            _reverseIconLookup.Add(d_treeeditor_branchfreehand, Enum.d_treeeditor_branchfreehand);
            _iconLookup.Add(Enum.d_treeeditor_branchrotate_on, d_treeeditor_branchrotate_on);
            _reverseIconLookup.Add(d_treeeditor_branchrotate_on, Enum.d_treeeditor_branchrotate_on);
            _iconLookup.Add(Enum.d_treeeditor_branchrotate, d_treeeditor_branchrotate);
            _reverseIconLookup.Add(d_treeeditor_branchrotate, Enum.d_treeeditor_branchrotate);
            _iconLookup.Add(Enum.d_treeeditor_branchscale_on, d_treeeditor_branchscale_on);
            _reverseIconLookup.Add(d_treeeditor_branchscale_on, Enum.d_treeeditor_branchscale_on);
            _iconLookup.Add(Enum.d_treeeditor_branchscale, d_treeeditor_branchscale);
            _reverseIconLookup.Add(d_treeeditor_branchscale, Enum.d_treeeditor_branchscale);
            _iconLookup.Add(Enum.d_treeeditor_branchtranslate_on, d_treeeditor_branchtranslate_on);
            _reverseIconLookup.Add(d_treeeditor_branchtranslate_on, Enum.d_treeeditor_branchtranslate_on);
            _iconLookup.Add(Enum.d_treeeditor_branchtranslate, d_treeeditor_branchtranslate);
            _reverseIconLookup.Add(d_treeeditor_branchtranslate, Enum.d_treeeditor_branchtranslate);
            _iconLookup.Add(Enum.d_treeeditor_distribution_on, d_treeeditor_distribution_on);
            _reverseIconLookup.Add(d_treeeditor_distribution_on, Enum.d_treeeditor_distribution_on);
            _iconLookup.Add(Enum.d_treeeditor_distribution, d_treeeditor_distribution);
            _reverseIconLookup.Add(d_treeeditor_distribution, Enum.d_treeeditor_distribution);
            _iconLookup.Add(Enum.d_treeeditor_duplicate, d_treeeditor_duplicate);
            _reverseIconLookup.Add(d_treeeditor_duplicate, Enum.d_treeeditor_duplicate);
            _iconLookup.Add(Enum.d_treeeditor_geometry_on, d_treeeditor_geometry_on);
            _reverseIconLookup.Add(d_treeeditor_geometry_on, Enum.d_treeeditor_geometry_on);
            _iconLookup.Add(Enum.d_treeeditor_geometry, d_treeeditor_geometry);
            _reverseIconLookup.Add(d_treeeditor_geometry, Enum.d_treeeditor_geometry);
            _iconLookup.Add(Enum.d_treeeditor_leaf_on, d_treeeditor_leaf_on);
            _reverseIconLookup.Add(d_treeeditor_leaf_on, Enum.d_treeeditor_leaf_on);
            _iconLookup.Add(Enum.d_treeeditor_leaf, d_treeeditor_leaf);
            _reverseIconLookup.Add(d_treeeditor_leaf, Enum.d_treeeditor_leaf);
            _iconLookup.Add(Enum.d_treeeditor_leaffreehand_on, d_treeeditor_leaffreehand_on);
            _reverseIconLookup.Add(d_treeeditor_leaffreehand_on, Enum.d_treeeditor_leaffreehand_on);
            _iconLookup.Add(Enum.d_treeeditor_leaffreehand, d_treeeditor_leaffreehand);
            _reverseIconLookup.Add(d_treeeditor_leaffreehand, Enum.d_treeeditor_leaffreehand);
            _iconLookup.Add(Enum.d_treeeditor_leafrotate_on, d_treeeditor_leafrotate_on);
            _reverseIconLookup.Add(d_treeeditor_leafrotate_on, Enum.d_treeeditor_leafrotate_on);
            _iconLookup.Add(Enum.d_treeeditor_leafrotate, d_treeeditor_leafrotate);
            _reverseIconLookup.Add(d_treeeditor_leafrotate, Enum.d_treeeditor_leafrotate);
            _iconLookup.Add(Enum.d_treeeditor_leafscale_on, d_treeeditor_leafscale_on);
            _reverseIconLookup.Add(d_treeeditor_leafscale_on, Enum.d_treeeditor_leafscale_on);
            _iconLookup.Add(Enum.d_treeeditor_leafscale, d_treeeditor_leafscale);
            _reverseIconLookup.Add(d_treeeditor_leafscale, Enum.d_treeeditor_leafscale);
            _iconLookup.Add(Enum.d_treeeditor_leaftranslate_on, d_treeeditor_leaftranslate_on);
            _reverseIconLookup.Add(d_treeeditor_leaftranslate_on, Enum.d_treeeditor_leaftranslate_on);
            _iconLookup.Add(Enum.d_treeeditor_leaftranslate, d_treeeditor_leaftranslate);
            _reverseIconLookup.Add(d_treeeditor_leaftranslate, Enum.d_treeeditor_leaftranslate);
            _iconLookup.Add(Enum.d_treeeditor_material_on, d_treeeditor_material_on);
            _reverseIconLookup.Add(d_treeeditor_material_on, Enum.d_treeeditor_material_on);
            _iconLookup.Add(Enum.d_treeeditor_material, d_treeeditor_material);
            _reverseIconLookup.Add(d_treeeditor_material, Enum.d_treeeditor_material);
            _iconLookup.Add(Enum.d_treeeditor_refresh, d_treeeditor_refresh);
            _reverseIconLookup.Add(d_treeeditor_refresh, Enum.d_treeeditor_refresh);
            _iconLookup.Add(Enum.d_treeeditor_trash, d_treeeditor_trash);
            _reverseIconLookup.Add(d_treeeditor_trash, Enum.d_treeeditor_trash);
            _iconLookup.Add(Enum.d_treeeditor_wind_on, d_treeeditor_wind_on);
            _reverseIconLookup.Add(d_treeeditor_wind_on, Enum.d_treeeditor_wind_on);
            _iconLookup.Add(Enum.d_treeeditor_wind, d_treeeditor_wind);
            _reverseIconLookup.Add(d_treeeditor_wind, Enum.d_treeeditor_wind);
            _iconLookup.Add(Enum.d_unityeditor_animationwindow, d_unityeditor_animationwindow);
            _reverseIconLookup.Add(d_unityeditor_animationwindow, Enum.d_unityeditor_animationwindow);
            _iconLookup.Add(Enum.d_unityeditor_consolewindow, d_unityeditor_consolewindow);
            _reverseIconLookup.Add(d_unityeditor_consolewindow, Enum.d_unityeditor_consolewindow);
            _iconLookup.Add(Enum.d_unityeditor_debuginspectorwindow, d_unityeditor_debuginspectorwindow);
            _reverseIconLookup.Add(d_unityeditor_debuginspectorwindow, Enum.d_unityeditor_debuginspectorwindow);
            _iconLookup.Add(Enum.d_unityeditor_devicesimulation_simulatorwindow, d_unityeditor_devicesimulation_simulatorwindow);
            _reverseIconLookup.Add(d_unityeditor_devicesimulation_simulatorwindow, Enum.d_unityeditor_devicesimulation_simulatorwindow);
            _iconLookup.Add(Enum.d_unityeditor_finddependencies, d_unityeditor_finddependencies);
            _reverseIconLookup.Add(d_unityeditor_finddependencies, Enum.d_unityeditor_finddependencies);
            _iconLookup.Add(Enum.d_unityeditor_gameview, d_unityeditor_gameview);
            _reverseIconLookup.Add(d_unityeditor_gameview, Enum.d_unityeditor_gameview);
            _iconLookup.Add(Enum.d_unityeditor_graphs_animatorcontrollertool, d_unityeditor_graphs_animatorcontrollertool);
            _reverseIconLookup.Add(d_unityeditor_graphs_animatorcontrollertool, Enum.d_unityeditor_graphs_animatorcontrollertool);
            _iconLookup.Add(Enum.d_unityeditor_hierarchywindow, d_unityeditor_hierarchywindow);
            _reverseIconLookup.Add(d_unityeditor_hierarchywindow, Enum.d_unityeditor_hierarchywindow);
            _iconLookup.Add(Enum.d_unityeditor_inspectorwindow, d_unityeditor_inspectorwindow);
            _reverseIconLookup.Add(d_unityeditor_inspectorwindow, Enum.d_unityeditor_inspectorwindow);
            _iconLookup.Add(Enum.d_unityeditor_profilerwindow, d_unityeditor_profilerwindow);
            _reverseIconLookup.Add(d_unityeditor_profilerwindow, Enum.d_unityeditor_profilerwindow);
            _iconLookup.Add(Enum.d_unityeditor_scenehierarchywindow, d_unityeditor_scenehierarchywindow);
            _reverseIconLookup.Add(d_unityeditor_scenehierarchywindow, Enum.d_unityeditor_scenehierarchywindow);
            _iconLookup.Add(Enum.d_unityeditor_sceneview, d_unityeditor_sceneview);
            _reverseIconLookup.Add(d_unityeditor_sceneview, Enum.d_unityeditor_sceneview);
            _iconLookup.Add(Enum.d_unityeditor_timeline_timelinewindow, d_unityeditor_timeline_timelinewindow);
            _reverseIconLookup.Add(d_unityeditor_timeline_timelinewindow, Enum.d_unityeditor_timeline_timelinewindow);
            _iconLookup.Add(Enum.d_unityeditor_versioncontrol, d_unityeditor_versioncontrol);
            _reverseIconLookup.Add(d_unityeditor_versioncontrol, Enum.d_unityeditor_versioncontrol);
            _iconLookup.Add(Enum.d_unitylogo, d_unitylogo);
            _reverseIconLookup.Add(d_unitylogo, Enum.d_unitylogo);
            _iconLookup.Add(Enum.d_unlinked, d_unlinked);
            _reverseIconLookup.Add(d_unlinked, Enum.d_unlinked);
            _iconLookup.Add(Enum.d_valid, d_valid);
            _reverseIconLookup.Add(d_valid, Enum.d_valid);
            _iconLookup.Add(Enum.d_verticalsplit, d_verticalsplit);
            _reverseIconLookup.Add(d_verticalsplit, Enum.d_verticalsplit);
            _iconLookup.Add(Enum.d_viewtoolmove_on, d_viewtoolmove_on);
            _reverseIconLookup.Add(d_viewtoolmove_on, Enum.d_viewtoolmove_on);
            _iconLookup.Add(Enum.d_viewtoolmove, d_viewtoolmove);
            _reverseIconLookup.Add(d_viewtoolmove, Enum.d_viewtoolmove);
            _iconLookup.Add(Enum.d_viewtoolorbit_on, d_viewtoolorbit_on);
            _reverseIconLookup.Add(d_viewtoolorbit_on, Enum.d_viewtoolorbit_on);
            _iconLookup.Add(Enum.d_viewtoolorbit, d_viewtoolorbit);
            _reverseIconLookup.Add(d_viewtoolorbit, Enum.d_viewtoolorbit);
            _iconLookup.Add(Enum.d_viewtoolzoom_on, d_viewtoolzoom_on);
            _reverseIconLookup.Add(d_viewtoolzoom_on, Enum.d_viewtoolzoom_on);
            _iconLookup.Add(Enum.d_viewtoolzoom, d_viewtoolzoom);
            _reverseIconLookup.Add(d_viewtoolzoom, Enum.d_viewtoolzoom);
            _iconLookup.Add(Enum.d_visibilityoff, d_visibilityoff);
            _reverseIconLookup.Add(d_visibilityoff, Enum.d_visibilityoff);
            _iconLookup.Add(Enum.d_visibilityon, d_visibilityon);
            _reverseIconLookup.Add(d_visibilityon, Enum.d_visibilityon);
            _iconLookup.Add(Enum.d_vumetertexturehorizontal, d_vumetertexturehorizontal);
            _reverseIconLookup.Add(d_vumetertexturehorizontal, Enum.d_vumetertexturehorizontal);
            _iconLookup.Add(Enum.d_vumetertexturevertical, d_vumetertexturevertical);
            _reverseIconLookup.Add(d_vumetertexturevertical, Enum.d_vumetertexturevertical);
            _iconLookup.Add(Enum.d_waitspin00, d_waitspin00);
            _reverseIconLookup.Add(d_waitspin00, Enum.d_waitspin00);
            _iconLookup.Add(Enum.d_waitspin01, d_waitspin01);
            _reverseIconLookup.Add(d_waitspin01, Enum.d_waitspin01);
            _iconLookup.Add(Enum.d_waitspin02, d_waitspin02);
            _reverseIconLookup.Add(d_waitspin02, Enum.d_waitspin02);
            _iconLookup.Add(Enum.d_waitspin03, d_waitspin03);
            _reverseIconLookup.Add(d_waitspin03, Enum.d_waitspin03);
            _iconLookup.Add(Enum.d_waitspin04, d_waitspin04);
            _reverseIconLookup.Add(d_waitspin04, Enum.d_waitspin04);
            _iconLookup.Add(Enum.d_waitspin05, d_waitspin05);
            _reverseIconLookup.Add(d_waitspin05, Enum.d_waitspin05);
            _iconLookup.Add(Enum.d_waitspin06, d_waitspin06);
            _reverseIconLookup.Add(d_waitspin06, Enum.d_waitspin06);
            _iconLookup.Add(Enum.d_waitspin07, d_waitspin07);
            _reverseIconLookup.Add(d_waitspin07, Enum.d_waitspin07);
            _iconLookup.Add(Enum.d_waitspin08, d_waitspin08);
            _reverseIconLookup.Add(d_waitspin08, Enum.d_waitspin08);
            _iconLookup.Add(Enum.d_waitspin09, d_waitspin09);
            _reverseIconLookup.Add(d_waitspin09, Enum.d_waitspin09);
            _iconLookup.Add(Enum.d_waitspin10, d_waitspin10);
            _reverseIconLookup.Add(d_waitspin10, Enum.d_waitspin10);
            _iconLookup.Add(Enum.d_waitspin11, d_waitspin11);
            _reverseIconLookup.Add(d_waitspin11, Enum.d_waitspin11);
            _iconLookup.Add(Enum.d_welcomescreen_assetstorelogo, d_welcomescreen_assetstorelogo);
            _reverseIconLookup.Add(d_welcomescreen_assetstorelogo, Enum.d_welcomescreen_assetstorelogo);
            _iconLookup.Add(Enum.d_winbtn_graph, d_winbtn_graph);
            _reverseIconLookup.Add(d_winbtn_graph, Enum.d_winbtn_graph);
            _iconLookup.Add(Enum.d_winbtn_graph_close_h, d_winbtn_graph_close_h);
            _reverseIconLookup.Add(d_winbtn_graph_close_h, Enum.d_winbtn_graph_close_h);
            _iconLookup.Add(Enum.d_winbtn_graph_max_h, d_winbtn_graph_max_h);
            _reverseIconLookup.Add(d_winbtn_graph_max_h, Enum.d_winbtn_graph_max_h);
            _iconLookup.Add(Enum.d_winbtn_graph_min_h, d_winbtn_graph_min_h);
            _reverseIconLookup.Add(d_winbtn_graph_min_h, Enum.d_winbtn_graph_min_h);
            _iconLookup.Add(Enum.d_winbtn_mac_close, d_winbtn_mac_close);
            _reverseIconLookup.Add(d_winbtn_mac_close, Enum.d_winbtn_mac_close);
            _iconLookup.Add(Enum.d_winbtn_mac_close_a, d_winbtn_mac_close_a);
            _reverseIconLookup.Add(d_winbtn_mac_close_a, Enum.d_winbtn_mac_close_a);
            _iconLookup.Add(Enum.d_winbtn_mac_close_h, d_winbtn_mac_close_h);
            _reverseIconLookup.Add(d_winbtn_mac_close_h, Enum.d_winbtn_mac_close_h);
            _iconLookup.Add(Enum.d_winbtn_mac_inact, d_winbtn_mac_inact);
            _reverseIconLookup.Add(d_winbtn_mac_inact, Enum.d_winbtn_mac_inact);
            _iconLookup.Add(Enum.d_winbtn_mac_max, d_winbtn_mac_max);
            _reverseIconLookup.Add(d_winbtn_mac_max, Enum.d_winbtn_mac_max);
            _iconLookup.Add(Enum.d_winbtn_mac_max_a, d_winbtn_mac_max_a);
            _reverseIconLookup.Add(d_winbtn_mac_max_a, Enum.d_winbtn_mac_max_a);
            _iconLookup.Add(Enum.d_winbtn_mac_max_h, d_winbtn_mac_max_h);
            _reverseIconLookup.Add(d_winbtn_mac_max_h, Enum.d_winbtn_mac_max_h);
            _iconLookup.Add(Enum.d_winbtn_mac_min, d_winbtn_mac_min);
            _reverseIconLookup.Add(d_winbtn_mac_min, Enum.d_winbtn_mac_min);
            _iconLookup.Add(Enum.d_winbtn_mac_min_a, d_winbtn_mac_min_a);
            _reverseIconLookup.Add(d_winbtn_mac_min_a, Enum.d_winbtn_mac_min_a);
            _iconLookup.Add(Enum.d_winbtn_mac_min_h, d_winbtn_mac_min_h);
            _reverseIconLookup.Add(d_winbtn_mac_min_h, Enum.d_winbtn_mac_min_h);
            _iconLookup.Add(Enum.d_winbtn_win_close, d_winbtn_win_close);
            _reverseIconLookup.Add(d_winbtn_win_close, Enum.d_winbtn_win_close);
            _iconLookup.Add(Enum.d_winbtn_win_close_a, d_winbtn_win_close_a);
            _reverseIconLookup.Add(d_winbtn_win_close_a, Enum.d_winbtn_win_close_a);
            _iconLookup.Add(Enum.d_winbtn_win_close_h, d_winbtn_win_close_h);
            _reverseIconLookup.Add(d_winbtn_win_close_h, Enum.d_winbtn_win_close_h);
            _iconLookup.Add(Enum.d_winbtn_win_max, d_winbtn_win_max);
            _reverseIconLookup.Add(d_winbtn_win_max, Enum.d_winbtn_win_max);
            _iconLookup.Add(Enum.d_winbtn_win_max_a, d_winbtn_win_max_a);
            _reverseIconLookup.Add(d_winbtn_win_max_a, Enum.d_winbtn_win_max_a);
            _iconLookup.Add(Enum.d_winbtn_win_max_h, d_winbtn_win_max_h);
            _reverseIconLookup.Add(d_winbtn_win_max_h, Enum.d_winbtn_win_max_h);
            _iconLookup.Add(Enum.d_winbtn_win_min, d_winbtn_win_min);
            _reverseIconLookup.Add(d_winbtn_win_min, Enum.d_winbtn_win_min);
            _iconLookup.Add(Enum.d_winbtn_win_min_a, d_winbtn_win_min_a);
            _reverseIconLookup.Add(d_winbtn_win_min_a, Enum.d_winbtn_win_min_a);
            _iconLookup.Add(Enum.d_winbtn_win_min_h, d_winbtn_win_min_h);
            _reverseIconLookup.Add(d_winbtn_win_min_h, Enum.d_winbtn_win_min_h);
            _iconLookup.Add(Enum.d_winbtn_win_rest, d_winbtn_win_rest);
            _reverseIconLookup.Add(d_winbtn_win_rest, Enum.d_winbtn_win_rest);
            _iconLookup.Add(Enum.d_winbtn_win_rest_a, d_winbtn_win_rest_a);
            _reverseIconLookup.Add(d_winbtn_win_rest_a, Enum.d_winbtn_win_rest_a);
            _iconLookup.Add(Enum.d_winbtn_win_rest_h, d_winbtn_win_rest_h);
            _reverseIconLookup.Add(d_winbtn_win_rest_h, Enum.d_winbtn_win_rest_h);
            _iconLookup.Add(Enum.d_winbtn_win_restore, d_winbtn_win_restore);
            _reverseIconLookup.Add(d_winbtn_win_restore, Enum.d_winbtn_win_restore);
            _iconLookup.Add(Enum.d_winbtn_win_restore_a, d_winbtn_win_restore_a);
            _reverseIconLookup.Add(d_winbtn_win_restore_a, Enum.d_winbtn_win_restore_a);
            _iconLookup.Add(Enum.d_winbtn_win_restore_h, d_winbtn_win_restore_h);
            _reverseIconLookup.Add(d_winbtn_win_restore_h, Enum.d_winbtn_win_restore_h);
            _iconLookup.Add(Enum.debuggerattached, debuggerattached);
            _reverseIconLookup.Add(debuggerattached, Enum.debuggerattached);
            _iconLookup.Add(Enum.debuggerdisabled, debuggerdisabled);
            _reverseIconLookup.Add(debuggerdisabled, Enum.debuggerdisabled);
            _iconLookup.Add(Enum.debuggerenabled, debuggerenabled);
            _reverseIconLookup.Add(debuggerenabled, Enum.debuggerenabled);
            _iconLookup.Add(Enum.defaultsorting, defaultsorting);
            _reverseIconLookup.Add(defaultsorting, Enum.defaultsorting);
            _iconLookup.Add(Enum.editcollider, editcollider);
            _reverseIconLookup.Add(editcollider, Enum.editcollider);
            _iconLookup.Add(Enum.editcollision_16, editcollision_16);
            _reverseIconLookup.Add(editcollision_16, Enum.editcollision_16);
            _iconLookup.Add(Enum.editcollision_32, editcollision_32);
            _reverseIconLookup.Add(editcollision_32, Enum.editcollision_32);
            _iconLookup.Add(Enum.editconstraints_16, editconstraints_16);
            _reverseIconLookup.Add(editconstraints_16, Enum.editconstraints_16);
            _iconLookup.Add(Enum.editconstraints_32, editconstraints_32);
            _reverseIconLookup.Add(editconstraints_32, Enum.editconstraints_32);
            _iconLookup.Add(Enum.editicon_sml, editicon_sml);
            _reverseIconLookup.Add(editicon_sml, Enum.editicon_sml);
            _iconLookup.Add(Enum.endbutton_on, endbutton_on);
            _reverseIconLookup.Add(endbutton_on, Enum.endbutton_on);
            _iconLookup.Add(Enum.endbutton, endbutton);
            _reverseIconLookup.Add(endbutton, Enum.endbutton);
            _iconLookup.Add(Enum.exposure, exposure);
            _reverseIconLookup.Add(exposure, Enum.exposure);
            _iconLookup.Add(Enum.eyedropper_large, eyedropper_large);
            _reverseIconLookup.Add(eyedropper_large, Enum.eyedropper_large);
            _iconLookup.Add(Enum.eyedropper_sml, eyedropper_sml);
            _reverseIconLookup.Add(eyedropper_sml, Enum.eyedropper_sml);
            _iconLookup.Add(Enum.favorite, favorite);
            _reverseIconLookup.Add(favorite, Enum.favorite);
            _iconLookup.Add(Enum.filterbylabel, filterbylabel);
            _reverseIconLookup.Add(filterbylabel, Enum.filterbylabel);
            _iconLookup.Add(Enum.filterbytype, filterbytype);
            _reverseIconLookup.Add(filterbytype, Enum.filterbytype);
            _iconLookup.Add(Enum.filterselectedonly, filterselectedonly);
            _reverseIconLookup.Add(filterselectedonly, Enum.filterselectedonly);
            _iconLookup.Add(Enum.forward, forward);
            _reverseIconLookup.Add(forward, Enum.forward);
            _iconLookup.Add(Enum.framecapture_on, framecapture_on);
            _reverseIconLookup.Add(framecapture_on, Enum.framecapture_on);
            _iconLookup.Add(Enum.framecapture, framecapture);
            _reverseIconLookup.Add(framecapture, Enum.framecapture);
            _iconLookup.Add(Enum.gear, gear);
            _reverseIconLookup.Add(gear, Enum.gear);
            _iconLookup.Add(Enum.gizmostoggle_on, gizmostoggle_on);
            _reverseIconLookup.Add(gizmostoggle_on, Enum.gizmostoggle_on);
            _iconLookup.Add(Enum.gizmostoggle, gizmostoggle);
            _reverseIconLookup.Add(gizmostoggle, Enum.gizmostoggle);
            _iconLookup.Add(Enum.grid_boxtool, grid_boxtool);
            _reverseIconLookup.Add(grid_boxtool, Enum.grid_boxtool);
            _iconLookup.Add(Enum.grid_default, grid_default);
            _reverseIconLookup.Add(grid_default, Enum.grid_default);
            _iconLookup.Add(Enum.grid_erasertool, grid_erasertool);
            _reverseIconLookup.Add(grid_erasertool, Enum.grid_erasertool);
            _iconLookup.Add(Enum.grid_filltool, grid_filltool);
            _reverseIconLookup.Add(grid_filltool, Enum.grid_filltool);
            _iconLookup.Add(Enum.grid_movetool, grid_movetool);
            _reverseIconLookup.Add(grid_movetool, Enum.grid_movetool);
            _iconLookup.Add(Enum.grid_painttool, grid_painttool);
            _reverseIconLookup.Add(grid_painttool, Enum.grid_painttool);
            _iconLookup.Add(Enum.grid_pickingtool, grid_pickingtool);
            _reverseIconLookup.Add(grid_pickingtool, Enum.grid_pickingtool);
            _iconLookup.Add(Enum.groove, groove);
            _reverseIconLookup.Add(groove, Enum.groove);
            _iconLookup.Add(Enum.align_horizontally, align_horizontally);
            _reverseIconLookup.Add(align_horizontally, Enum.align_horizontally);
            _iconLookup.Add(Enum.align_horizontally_center, align_horizontally_center);
            _reverseIconLookup.Add(align_horizontally_center, Enum.align_horizontally_center);
            _iconLookup.Add(Enum.align_horizontally_center_active, align_horizontally_center_active);
            _reverseIconLookup.Add(align_horizontally_center_active, Enum.align_horizontally_center_active);
            _iconLookup.Add(Enum.align_horizontally_left, align_horizontally_left);
            _reverseIconLookup.Add(align_horizontally_left, Enum.align_horizontally_left);
            _iconLookup.Add(Enum.align_horizontally_left_active, align_horizontally_left_active);
            _reverseIconLookup.Add(align_horizontally_left_active, Enum.align_horizontally_left_active);
            _iconLookup.Add(Enum.align_horizontally_right, align_horizontally_right);
            _reverseIconLookup.Add(align_horizontally_right, Enum.align_horizontally_right);
            _iconLookup.Add(Enum.align_horizontally_right_active, align_horizontally_right_active);
            _reverseIconLookup.Add(align_horizontally_right_active, Enum.align_horizontally_right_active);
            _iconLookup.Add(Enum.align_vertically, align_vertically);
            _reverseIconLookup.Add(align_vertically, Enum.align_vertically);
            _iconLookup.Add(Enum.align_vertically_bottom, align_vertically_bottom);
            _reverseIconLookup.Add(align_vertically_bottom, Enum.align_vertically_bottom);
            _iconLookup.Add(Enum.align_vertically_bottom_active, align_vertically_bottom_active);
            _reverseIconLookup.Add(align_vertically_bottom_active, Enum.align_vertically_bottom_active);
            _iconLookup.Add(Enum.align_vertically_center, align_vertically_center);
            _reverseIconLookup.Add(align_vertically_center, Enum.align_vertically_center);
            _iconLookup.Add(Enum.align_vertically_center_active, align_vertically_center_active);
            _reverseIconLookup.Add(align_vertically_center_active, Enum.align_vertically_center_active);
            _iconLookup.Add(Enum.align_vertically_top, align_vertically_top);
            _reverseIconLookup.Add(align_vertically_top, Enum.align_vertically_top);
            _iconLookup.Add(Enum.align_vertically_top_active, align_vertically_top_active);
            _reverseIconLookup.Add(align_vertically_top_active, Enum.align_vertically_top_active);
            _iconLookup.Add(Enum.d_align_horizontally, d_align_horizontally);
            _reverseIconLookup.Add(d_align_horizontally, Enum.d_align_horizontally);
            _iconLookup.Add(Enum.d_align_horizontally_center, d_align_horizontally_center);
            _reverseIconLookup.Add(d_align_horizontally_center, Enum.d_align_horizontally_center);
            _iconLookup.Add(Enum.d_align_horizontally_center_active, d_align_horizontally_center_active);
            _reverseIconLookup.Add(d_align_horizontally_center_active, Enum.d_align_horizontally_center_active);
            _iconLookup.Add(Enum.d_align_horizontally_left, d_align_horizontally_left);
            _reverseIconLookup.Add(d_align_horizontally_left, Enum.d_align_horizontally_left);
            _iconLookup.Add(Enum.d_align_horizontally_left_active, d_align_horizontally_left_active);
            _reverseIconLookup.Add(d_align_horizontally_left_active, Enum.d_align_horizontally_left_active);
            _iconLookup.Add(Enum.d_align_horizontally_right, d_align_horizontally_right);
            _reverseIconLookup.Add(d_align_horizontally_right, Enum.d_align_horizontally_right);
            _iconLookup.Add(Enum.d_align_horizontally_right_active, d_align_horizontally_right_active);
            _reverseIconLookup.Add(d_align_horizontally_right_active, Enum.d_align_horizontally_right_active);
            _iconLookup.Add(Enum.d_align_vertically, d_align_vertically);
            _reverseIconLookup.Add(d_align_vertically, Enum.d_align_vertically);
            _iconLookup.Add(Enum.d_align_vertically_bottom, d_align_vertically_bottom);
            _reverseIconLookup.Add(d_align_vertically_bottom, Enum.d_align_vertically_bottom);
            _iconLookup.Add(Enum.d_align_vertically_bottom_active, d_align_vertically_bottom_active);
            _reverseIconLookup.Add(d_align_vertically_bottom_active, Enum.d_align_vertically_bottom_active);
            _iconLookup.Add(Enum.d_align_vertically_center, d_align_vertically_center);
            _reverseIconLookup.Add(d_align_vertically_center, Enum.d_align_vertically_center);
            _iconLookup.Add(Enum.d_align_vertically_center_active, d_align_vertically_center_active);
            _reverseIconLookup.Add(d_align_vertically_center_active, Enum.d_align_vertically_center_active);
            _iconLookup.Add(Enum.d_align_vertically_top, d_align_vertically_top);
            _reverseIconLookup.Add(d_align_vertically_top, Enum.d_align_vertically_top);
            _iconLookup.Add(Enum.d_align_vertically_top_active, d_align_vertically_top_active);
            _reverseIconLookup.Add(d_align_vertically_top_active, Enum.d_align_vertically_top_active);
            _iconLookup.Add(Enum.horizontalsplit, horizontalsplit);
            _reverseIconLookup.Add(horizontalsplit, Enum.horizontalsplit);
            _iconLookup.Add(Enum.icon_dropdown, icon_dropdown);
            _reverseIconLookup.Add(icon_dropdown, Enum.icon_dropdown);
            _iconLookup.Add(Enum.import, import);
            _reverseIconLookup.Add(import, Enum.import);
            _iconLookup.Add(Enum.inspectorlock, inspectorlock);
            _reverseIconLookup.Add(inspectorlock, Enum.inspectorlock);
            _iconLookup.Add(Enum.invalid, invalid);
            _reverseIconLookup.Add(invalid, Enum.invalid);
            _iconLookup.Add(Enum.jointangularlimits, jointangularlimits);
            _reverseIconLookup.Add(jointangularlimits, Enum.jointangularlimits);
            _iconLookup.Add(Enum.knobcshape, knobcshape);
            _reverseIconLookup.Add(knobcshape, Enum.knobcshape);
            _iconLookup.Add(Enum.knobcshapemini, knobcshapemini);
            _reverseIconLookup.Add(knobcshapemini, Enum.knobcshapemini);
            _iconLookup.Add(Enum.leftbracket, leftbracket);
            _reverseIconLookup.Add(leftbracket, Enum.leftbracket);
            _iconLookup.Add(Enum.lighting, lighting);
            _reverseIconLookup.Add(lighting, Enum.lighting);
            _iconLookup.Add(Enum.lightmapeditor_windowtitle, lightmapeditor_windowtitle);
            _reverseIconLookup.Add(lightmapeditor_windowtitle, Enum.lightmapeditor_windowtitle);
            _iconLookup.Add(Enum.lightmapping, lightmapping);
            _reverseIconLookup.Add(lightmapping, Enum.lightmapping);
            _iconLookup.Add(Enum.d_greenlight, d_greenlight);
            _reverseIconLookup.Add(d_greenlight, Enum.d_greenlight);
            _iconLookup.Add(Enum.d_lightoff, d_lightoff);
            _reverseIconLookup.Add(d_lightoff, Enum.d_lightoff);
            _iconLookup.Add(Enum.d_lightrim, d_lightrim);
            _reverseIconLookup.Add(d_lightrim, Enum.d_lightrim);
            _iconLookup.Add(Enum.d_orangelight, d_orangelight);
            _reverseIconLookup.Add(d_orangelight, Enum.d_orangelight);
            _iconLookup.Add(Enum.d_redlight, d_redlight);
            _reverseIconLookup.Add(d_redlight, Enum.d_redlight);
            _iconLookup.Add(Enum.greenlight, greenlight);
            _reverseIconLookup.Add(greenlight, Enum.greenlight);
            _iconLookup.Add(Enum.lightoff, lightoff);
            _reverseIconLookup.Add(lightoff, Enum.lightoff);
            _iconLookup.Add(Enum.lightrim, lightrim);
            _reverseIconLookup.Add(lightrim, Enum.lightrim);
            _iconLookup.Add(Enum.orangelight, orangelight);
            _reverseIconLookup.Add(orangelight, Enum.orangelight);
            _iconLookup.Add(Enum.redlight, redlight);
            _reverseIconLookup.Add(redlight, Enum.redlight);
            _iconLookup.Add(Enum.linked, linked);
            _reverseIconLookup.Add(linked, Enum.linked);
            _iconLookup.Add(Enum.lockicon_on, lockicon_on);
            _reverseIconLookup.Add(lockicon_on, Enum.lockicon_on);
            _iconLookup.Add(Enum.lockicon, lockicon);
            _reverseIconLookup.Add(lockicon, Enum.lockicon);
            _iconLookup.Add(Enum.loop, loop);
            _reverseIconLookup.Add(loop, Enum.loop);
            _iconLookup.Add(Enum.mainstageview, mainstageview);
            _reverseIconLookup.Add(mainstageview, Enum.mainstageview);
            _iconLookup.Add(Enum.mirror, mirror);
            _reverseIconLookup.Add(mirror, Enum.mirror);
            _iconLookup.Add(Enum.monologo, monologo);
            _reverseIconLookup.Add(monologo, Enum.monologo);
            _iconLookup.Add(Enum.moreoptions, moreoptions);
            _reverseIconLookup.Add(moreoptions, Enum.moreoptions);
            _iconLookup.Add(Enum.movetool_on, movetool_on);
            _reverseIconLookup.Add(movetool_on, Enum.movetool_on);
            _iconLookup.Add(Enum.movetool, movetool);
            _reverseIconLookup.Add(movetool, Enum.movetool);
            _iconLookup.Add(Enum.navigation, navigation);
            _reverseIconLookup.Add(navigation, Enum.navigation);
            _iconLookup.Add(Enum.occlusion, occlusion);
            _reverseIconLookup.Add(occlusion, Enum.occlusion);
            _iconLookup.Add(Enum.camerapreview, camerapreview);
            _reverseIconLookup.Add(camerapreview, Enum.camerapreview);
            _iconLookup.Add(Enum.d_camerapreview, d_camerapreview);
            _reverseIconLookup.Add(d_camerapreview, Enum.d_camerapreview);
            _iconLookup.Add(Enum.d_gridandsnap, d_gridandsnap);
            _reverseIconLookup.Add(d_gridandsnap, Enum.d_gridandsnap);
            _iconLookup.Add(Enum.d_orientationgizmo, d_orientationgizmo);
            _reverseIconLookup.Add(d_orientationgizmo, Enum.d_orientationgizmo);
            _iconLookup.Add(Enum.d_searchoverlay, d_searchoverlay);
            _reverseIconLookup.Add(d_searchoverlay, Enum.d_searchoverlay);
            _iconLookup.Add(Enum.d_standardtools, d_standardtools);
            _reverseIconLookup.Add(d_standardtools, Enum.d_standardtools);
            _iconLookup.Add(Enum.d_toolsettings, d_toolsettings);
            _reverseIconLookup.Add(d_toolsettings, Enum.d_toolsettings);
            _iconLookup.Add(Enum.d_toolstoggle, d_toolstoggle);
            _reverseIconLookup.Add(d_toolstoggle, Enum.d_toolstoggle);
            _iconLookup.Add(Enum.d_viewoptions, d_viewoptions);
            _reverseIconLookup.Add(d_viewoptions, Enum.d_viewoptions);
            _iconLookup.Add(Enum.gridandsnap, gridandsnap);
            _reverseIconLookup.Add(gridandsnap, Enum.gridandsnap);
            _iconLookup.Add(Enum.grip_horizontalcontainer, grip_horizontalcontainer);
            _reverseIconLookup.Add(grip_horizontalcontainer, Enum.grip_horizontalcontainer);
            _iconLookup.Add(Enum.grip_verticalcontainer, grip_verticalcontainer);
            _reverseIconLookup.Add(grip_verticalcontainer, Enum.grip_verticalcontainer);
            _iconLookup.Add(Enum.hoverbar_down, hoverbar_down);
            _reverseIconLookup.Add(hoverbar_down, Enum.hoverbar_down);
            _iconLookup.Add(Enum.hoverbar_leftright, hoverbar_leftright);
            _reverseIconLookup.Add(hoverbar_leftright, Enum.hoverbar_leftright);
            _iconLookup.Add(Enum.hoverbar_up, hoverbar_up);
            _reverseIconLookup.Add(hoverbar_up, Enum.hoverbar_up);
            _iconLookup.Add(Enum.locked, locked);
            _reverseIconLookup.Add(locked, Enum.locked);
            _iconLookup.Add(Enum.orientationgizmo, orientationgizmo);
            _reverseIconLookup.Add(orientationgizmo, Enum.orientationgizmo);
            _iconLookup.Add(Enum.searchoverlay, searchoverlay);
            _reverseIconLookup.Add(searchoverlay, Enum.searchoverlay);
            _iconLookup.Add(Enum.standardtools, standardtools);
            _reverseIconLookup.Add(standardtools, Enum.standardtools);
            _iconLookup.Add(Enum.toolsettings, toolsettings);
            _reverseIconLookup.Add(toolsettings, Enum.toolsettings);
            _iconLookup.Add(Enum.toolstoggle, toolstoggle);
            _reverseIconLookup.Add(toolstoggle, Enum.toolstoggle);
            _iconLookup.Add(Enum.unlocked, unlocked);
            _reverseIconLookup.Add(unlocked, Enum.unlocked);
            _iconLookup.Add(Enum.viewoptions, viewoptions);
            _reverseIconLookup.Add(viewoptions, Enum.viewoptions);
            _iconLookup.Add(Enum.package_manager, package_manager);
            _reverseIconLookup.Add(package_manager, Enum.package_manager);
            _iconLookup.Add(Enum.packagebadgedelete, packagebadgedelete);
            _reverseIconLookup.Add(packagebadgedelete, Enum.packagebadgedelete);
            _iconLookup.Add(Enum.packagebadgenew, packagebadgenew);
            _reverseIconLookup.Add(packagebadgenew, Enum.packagebadgenew);
            _iconLookup.Add(Enum.feature_selected, feature_selected);
            _reverseIconLookup.Add(feature_selected, Enum.feature_selected);
            _iconLookup.Add(Enum.feature, feature);
            _reverseIconLookup.Add(feature, Enum.feature);
            _iconLookup.Add(Enum.quickstart, quickstart);
            _reverseIconLookup.Add(quickstart, Enum.quickstart);
            _iconLookup.Add(Enum.add_available, add_available);
            _reverseIconLookup.Add(add_available, Enum.add_available);
            _iconLookup.Add(Enum.custom, custom);
            _reverseIconLookup.Add(custom, Enum.custom);
            _iconLookup.Add(Enum.customized, customized);
            _reverseIconLookup.Add(customized, Enum.customized);
            _iconLookup.Add(Enum.download_available, download_available);
            _reverseIconLookup.Add(download_available, Enum.download_available);
            _iconLookup.Add(Enum.error, error);
            _reverseIconLookup.Add(error, Enum.error);
            _iconLookup.Add(Enum.git, git);
            _reverseIconLookup.Add(git, Enum.git);
            _iconLookup.Add(Enum.import_available, import_available);
            _reverseIconLookup.Add(import_available, Enum.import_available);
            _iconLookup.Add(Enum.info, info);
            _reverseIconLookup.Add(info, Enum.info);
            _iconLookup.Add(Enum.installed, installed);
            _reverseIconLookup.Add(installed, Enum.installed);
            _iconLookup.Add(Enum.link, link);
            _reverseIconLookup.Add(link, Enum.link);
            _iconLookup.Add(Enum.loading, loading);
            _reverseIconLookup.Add(loading, Enum.loading);
            _iconLookup.Add(Enum.refresh, refresh);
            _reverseIconLookup.Add(refresh, Enum.refresh);
            _iconLookup.Add(Enum.update_available, update_available);
            _reverseIconLookup.Add(update_available, Enum.update_available);
            _iconLookup.Add(Enum.warning, warning);
            _reverseIconLookup.Add(warning, Enum.warning);
            _iconLookup.Add(Enum.particle_effect, particle_effect);
            _reverseIconLookup.Add(particle_effect, Enum.particle_effect);
            _iconLookup.Add(Enum.particleshapetool_on, particleshapetool_on);
            _reverseIconLookup.Add(particleshapetool_on, Enum.particleshapetool_on);
            _iconLookup.Add(Enum.particleshapetool, particleshapetool);
            _reverseIconLookup.Add(particleshapetool, Enum.particleshapetool);
            _iconLookup.Add(Enum.pausebutton_on, pausebutton_on);
            _reverseIconLookup.Add(pausebutton_on, Enum.pausebutton_on);
            _iconLookup.Add(Enum.pausebutton, pausebutton);
            _reverseIconLookup.Add(pausebutton, Enum.pausebutton);
            _iconLookup.Add(Enum.playbutton_on, playbutton_on);
            _reverseIconLookup.Add(playbutton_on, Enum.playbutton_on);
            _iconLookup.Add(Enum.playbutton, playbutton);
            _reverseIconLookup.Add(playbutton, Enum.playbutton);
            _iconLookup.Add(Enum.playbuttonprofile_on, playbuttonprofile_on);
            _reverseIconLookup.Add(playbuttonprofile_on, Enum.playbuttonprofile_on);
            _iconLookup.Add(Enum.playbuttonprofile, playbuttonprofile);
            _reverseIconLookup.Add(playbuttonprofile, Enum.playbuttonprofile);
            _iconLookup.Add(Enum.playloopoff, playloopoff);
            _reverseIconLookup.Add(playloopoff, Enum.playloopoff);
            _iconLookup.Add(Enum.playloopon, playloopon);
            _reverseIconLookup.Add(playloopon, Enum.playloopon);
            _iconLookup.Add(Enum.playspeed, playspeed);
            _reverseIconLookup.Add(playspeed, Enum.playspeed);
            _iconLookup.Add(Enum.preaudioautoplayoff, preaudioautoplayoff);
            _reverseIconLookup.Add(preaudioautoplayoff, Enum.preaudioautoplayoff);
            _iconLookup.Add(Enum.preaudioautoplayon, preaudioautoplayon);
            _reverseIconLookup.Add(preaudioautoplayon, Enum.preaudioautoplayon);
            _iconLookup.Add(Enum.preaudioloopoff, preaudioloopoff);
            _reverseIconLookup.Add(preaudioloopoff, Enum.preaudioloopoff);
            _iconLookup.Add(Enum.preaudioloopon, preaudioloopon);
            _reverseIconLookup.Add(preaudioloopon, Enum.preaudioloopon);
            _iconLookup.Add(Enum.preaudioplayoff, preaudioplayoff);
            _reverseIconLookup.Add(preaudioplayoff, Enum.preaudioplayoff);
            _iconLookup.Add(Enum.preaudioplayon, preaudioplayon);
            _reverseIconLookup.Add(preaudioplayon, Enum.preaudioplayon);
            _iconLookup.Add(Enum.prematcube, prematcube);
            _reverseIconLookup.Add(prematcube, Enum.prematcube);
            _iconLookup.Add(Enum.prematcylinder, prematcylinder);
            _reverseIconLookup.Add(prematcylinder, Enum.prematcylinder);
            _iconLookup.Add(Enum.prematlight0, prematlight0);
            _reverseIconLookup.Add(prematlight0, Enum.prematlight0);
            _iconLookup.Add(Enum.prematlight1, prematlight1);
            _reverseIconLookup.Add(prematlight1, Enum.prematlight1);
            _iconLookup.Add(Enum.prematquad, prematquad);
            _reverseIconLookup.Add(prematquad, Enum.prematquad);
            _iconLookup.Add(Enum.prematsphere, prematsphere);
            _reverseIconLookup.Add(prematsphere, Enum.prematsphere);
            _iconLookup.Add(Enum.premattorus, premattorus);
            _reverseIconLookup.Add(premattorus, Enum.premattorus);
            _iconLookup.Add(Enum.preset_context, preset_context);
            _reverseIconLookup.Add(preset_context, Enum.preset_context);
            _iconLookup.Add(Enum.pretexa, pretexa);
            _reverseIconLookup.Add(pretexa, Enum.pretexa);
            _iconLookup.Add(Enum.pretexb, pretexb);
            _reverseIconLookup.Add(pretexb, Enum.pretexb);
            _iconLookup.Add(Enum.pretexg, pretexg);
            _reverseIconLookup.Add(pretexg, Enum.pretexg);
            _iconLookup.Add(Enum.pretexr, pretexr);
            _reverseIconLookup.Add(pretexr, Enum.pretexr);
            _iconLookup.Add(Enum.pretexrgb, pretexrgb);
            _reverseIconLookup.Add(pretexrgb, Enum.pretexrgb);
            _iconLookup.Add(Enum.pretexturealpha, pretexturealpha);
            _reverseIconLookup.Add(pretexturealpha, Enum.pretexturealpha);
            _iconLookup.Add(Enum.pretexturearrayfirstslice, pretexturearrayfirstslice);
            _reverseIconLookup.Add(pretexturearrayfirstslice, Enum.pretexturearrayfirstslice);
            _iconLookup.Add(Enum.pretexturearraylastslice, pretexturearraylastslice);
            _reverseIconLookup.Add(pretexturearraylastslice, Enum.pretexturearraylastslice);
            _iconLookup.Add(Enum.pretexturemipmaphigh, pretexturemipmaphigh);
            _reverseIconLookup.Add(pretexturemipmaphigh, Enum.pretexturemipmaphigh);
            _iconLookup.Add(Enum.pretexturemipmaplow, pretexturemipmaplow);
            _reverseIconLookup.Add(pretexturemipmaplow, Enum.pretexturemipmaplow);
            _iconLookup.Add(Enum.pretexturergb, pretexturergb);
            _reverseIconLookup.Add(pretexturergb, Enum.pretexturergb);
            _iconLookup.Add(Enum.previewpackageinuse, previewpackageinuse);
            _reverseIconLookup.Add(previewpackageinuse, Enum.previewpackageinuse);
            _iconLookup.Add(Enum.arealight_gizmo, arealight_gizmo);
            _reverseIconLookup.Add(arealight_gizmo, Enum.arealight_gizmo);
            _iconLookup.Add(Enum.arealight_icon, arealight_icon);
            _reverseIconLookup.Add(arealight_icon, Enum.arealight_icon);
            _iconLookup.Add(Enum.assembly_icon, assembly_icon);
            _reverseIconLookup.Add(assembly_icon, Enum.assembly_icon);
            _iconLookup.Add(Enum.assetstore_icon, assetstore_icon);
            _reverseIconLookup.Add(assetstore_icon, Enum.assetstore_icon);
            _iconLookup.Add(Enum.audiomixerview_icon, audiomixerview_icon);
            _reverseIconLookup.Add(audiomixerview_icon, Enum.audiomixerview_icon);
            _iconLookup.Add(Enum.audiosource_gizmo, audiosource_gizmo);
            _reverseIconLookup.Add(audiosource_gizmo, Enum.audiosource_gizmo);
            _iconLookup.Add(Enum.boo_script_icon, boo_script_icon);
            _reverseIconLookup.Add(boo_script_icon, Enum.boo_script_icon);
            _iconLookup.Add(Enum.camera_gizmo, camera_gizmo);
            _reverseIconLookup.Add(camera_gizmo, Enum.camera_gizmo);
            _iconLookup.Add(Enum.chorusfilter_icon, chorusfilter_icon);
            _reverseIconLookup.Add(chorusfilter_icon, Enum.chorusfilter_icon);
            _iconLookup.Add(Enum.collabchanges_icon, collabchanges_icon);
            _reverseIconLookup.Add(collabchanges_icon, Enum.collabchanges_icon);
            _iconLookup.Add(Enum.collabchangesconflict_icon, collabchangesconflict_icon);
            _reverseIconLookup.Add(collabchangesconflict_icon, Enum.collabchangesconflict_icon);
            _iconLookup.Add(Enum.collabchangesdeleted_icon, collabchangesdeleted_icon);
            _reverseIconLookup.Add(collabchangesdeleted_icon, Enum.collabchangesdeleted_icon);
            _iconLookup.Add(Enum.collabconflict_icon, collabconflict_icon);
            _reverseIconLookup.Add(collabconflict_icon, Enum.collabconflict_icon);
            _iconLookup.Add(Enum.collabcreate_icon, collabcreate_icon);
            _reverseIconLookup.Add(collabcreate_icon, Enum.collabcreate_icon);
            _iconLookup.Add(Enum.collabdeleted_icon, collabdeleted_icon);
            _reverseIconLookup.Add(collabdeleted_icon, Enum.collabdeleted_icon);
            _iconLookup.Add(Enum.collabedit_icon, collabedit_icon);
            _reverseIconLookup.Add(collabedit_icon, Enum.collabedit_icon);
            _iconLookup.Add(Enum.collabexclude_icon, collabexclude_icon);
            _reverseIconLookup.Add(collabexclude_icon, Enum.collabexclude_icon);
            _iconLookup.Add(Enum.collabmoved_icon, collabmoved_icon);
            _reverseIconLookup.Add(collabmoved_icon, Enum.collabmoved_icon);
            _iconLookup.Add(Enum.cs_script_icon, cs_script_icon);
            _reverseIconLookup.Add(cs_script_icon, Enum.cs_script_icon);
            _iconLookup.Add(Enum.d_arealight_icon, d_arealight_icon);
            _reverseIconLookup.Add(d_arealight_icon, Enum.d_arealight_icon);
            _iconLookup.Add(Enum.d_assembly_icon, d_assembly_icon);
            _reverseIconLookup.Add(d_assembly_icon, Enum.d_assembly_icon);
            _iconLookup.Add(Enum.d_assetstore_icon, d_assetstore_icon);
            _reverseIconLookup.Add(d_assetstore_icon, Enum.d_assetstore_icon);
            _iconLookup.Add(Enum.d_audiomixerview_icon, d_audiomixerview_icon);
            _reverseIconLookup.Add(d_audiomixerview_icon, Enum.d_audiomixerview_icon);
            _iconLookup.Add(Enum.d_boo_script_icon, d_boo_script_icon);
            _reverseIconLookup.Add(d_boo_script_icon, Enum.d_boo_script_icon);
            _iconLookup.Add(Enum.d_collabchanges_icon, d_collabchanges_icon);
            _reverseIconLookup.Add(d_collabchanges_icon, Enum.d_collabchanges_icon);
            _iconLookup.Add(Enum.d_collabchangesconflict_icon, d_collabchangesconflict_icon);
            _reverseIconLookup.Add(d_collabchangesconflict_icon, Enum.d_collabchangesconflict_icon);
            _iconLookup.Add(Enum.d_collabchangesdeleted_icon, d_collabchangesdeleted_icon);
            _reverseIconLookup.Add(d_collabchangesdeleted_icon, Enum.d_collabchangesdeleted_icon);
            _iconLookup.Add(Enum.d_collabconflict_icon, d_collabconflict_icon);
            _reverseIconLookup.Add(d_collabconflict_icon, Enum.d_collabconflict_icon);
            _iconLookup.Add(Enum.d_collabcreate_icon, d_collabcreate_icon);
            _reverseIconLookup.Add(d_collabcreate_icon, Enum.d_collabcreate_icon);
            _iconLookup.Add(Enum.d_collabdeleted_icon, d_collabdeleted_icon);
            _reverseIconLookup.Add(d_collabdeleted_icon, Enum.d_collabdeleted_icon);
            _iconLookup.Add(Enum.d_collabedit_icon, d_collabedit_icon);
            _reverseIconLookup.Add(d_collabedit_icon, Enum.d_collabedit_icon);
            _iconLookup.Add(Enum.d_collabexclude_icon, d_collabexclude_icon);
            _reverseIconLookup.Add(d_collabexclude_icon, Enum.d_collabexclude_icon);
            _iconLookup.Add(Enum.d_collabmoved_icon, d_collabmoved_icon);
            _reverseIconLookup.Add(d_collabmoved_icon, Enum.d_collabmoved_icon);
            _iconLookup.Add(Enum.d_cs_script_icon, d_cs_script_icon);
            _reverseIconLookup.Add(d_cs_script_icon, Enum.d_cs_script_icon);
            _iconLookup.Add(Enum.d_directionallight_icon, d_directionallight_icon);
            _reverseIconLookup.Add(d_directionallight_icon, Enum.d_directionallight_icon);
            _iconLookup.Add(Enum.d_favorite_icon, d_favorite_icon);
            _reverseIconLookup.Add(d_favorite_icon, Enum.d_favorite_icon);
            _iconLookup.Add(Enum.d_favorite_on_icon, d_favorite_on_icon);
            _reverseIconLookup.Add(d_favorite_on_icon, Enum.d_favorite_on_icon);
            _iconLookup.Add(Enum.d_folder_icon, d_folder_icon);
            _reverseIconLookup.Add(d_folder_icon, Enum.d_folder_icon);
            _iconLookup.Add(Enum.d_folder_on_icon, d_folder_on_icon);
            _reverseIconLookup.Add(d_folder_on_icon, Enum.d_folder_on_icon);
            _iconLookup.Add(Enum.d_folderempty_icon, d_folderempty_icon);
            _reverseIconLookup.Add(d_folderempty_icon, Enum.d_folderempty_icon);
            _iconLookup.Add(Enum.d_folderempty_on_icon, d_folderempty_on_icon);
            _reverseIconLookup.Add(d_folderempty_on_icon, Enum.d_folderempty_on_icon);
            _iconLookup.Add(Enum.d_folderfavorite_icon, d_folderfavorite_icon);
            _reverseIconLookup.Add(d_folderfavorite_icon, Enum.d_folderfavorite_icon);
            _iconLookup.Add(Enum.d_folderfavorite_on_icon, d_folderfavorite_on_icon);
            _reverseIconLookup.Add(d_folderfavorite_on_icon, Enum.d_folderfavorite_on_icon);
            _iconLookup.Add(Enum.d_folderopened_icon, d_folderopened_icon);
            _reverseIconLookup.Add(d_folderopened_icon, Enum.d_folderopened_icon);
            _iconLookup.Add(Enum.d_gridlayoutgroup_icon, d_gridlayoutgroup_icon);
            _reverseIconLookup.Add(d_gridlayoutgroup_icon, Enum.d_gridlayoutgroup_icon);
            _iconLookup.Add(Enum.d_horizontallayoutgroup_icon, d_horizontallayoutgroup_icon);
            _reverseIconLookup.Add(d_horizontallayoutgroup_icon, Enum.d_horizontallayoutgroup_icon);
            _iconLookup.Add(Enum.d_js_script_icon, d_js_script_icon);
            _reverseIconLookup.Add(d_js_script_icon, Enum.d_js_script_icon);
            _iconLookup.Add(Enum.d_lightingdataassetparent_icon, d_lightingdataassetparent_icon);
            _reverseIconLookup.Add(d_lightingdataassetparent_icon, Enum.d_lightingdataassetparent_icon);
            _iconLookup.Add(Enum.d_microphone_icon, d_microphone_icon);
            _reverseIconLookup.Add(d_microphone_icon, Enum.d_microphone_icon);
            _iconLookup.Add(Enum.d_prefab_icon, d_prefab_icon);
            _reverseIconLookup.Add(d_prefab_icon, Enum.d_prefab_icon);
            _iconLookup.Add(Enum.d_prefab_on_icon, d_prefab_on_icon);
            _reverseIconLookup.Add(d_prefab_on_icon, Enum.d_prefab_on_icon);
            _iconLookup.Add(Enum.d_prefabmodel_icon, d_prefabmodel_icon);
            _reverseIconLookup.Add(d_prefabmodel_icon, Enum.d_prefabmodel_icon);
            _iconLookup.Add(Enum.d_prefabmodel_on_icon, d_prefabmodel_on_icon);
            _reverseIconLookup.Add(d_prefabmodel_on_icon, Enum.d_prefabmodel_on_icon);
            _iconLookup.Add(Enum.d_prefabvariant_icon, d_prefabvariant_icon);
            _reverseIconLookup.Add(d_prefabvariant_icon, Enum.d_prefabvariant_icon);
            _iconLookup.Add(Enum.d_prefabvariant_on_icon, d_prefabvariant_on_icon);
            _reverseIconLookup.Add(d_prefabvariant_on_icon, Enum.d_prefabvariant_on_icon);
            _iconLookup.Add(Enum.d_raycastcollider_icon, d_raycastcollider_icon);
            _reverseIconLookup.Add(d_raycastcollider_icon, Enum.d_raycastcollider_icon);
            _iconLookup.Add(Enum.d_search_icon, d_search_icon);
            _reverseIconLookup.Add(d_search_icon, Enum.d_search_icon);
            _iconLookup.Add(Enum.d_search_on_icon, d_search_on_icon);
            _reverseIconLookup.Add(d_search_on_icon, Enum.d_search_on_icon);
            _iconLookup.Add(Enum.d_searchjump_icon, d_searchjump_icon);
            _reverseIconLookup.Add(d_searchjump_icon, Enum.d_searchjump_icon);
            _iconLookup.Add(Enum.d_settings_icon, d_settings_icon);
            _reverseIconLookup.Add(d_settings_icon, Enum.d_settings_icon);
            _iconLookup.Add(Enum.d_shortcut_icon, d_shortcut_icon);
            _reverseIconLookup.Add(d_shortcut_icon, Enum.d_shortcut_icon);
            _iconLookup.Add(Enum.d_spotlight_icon, d_spotlight_icon);
            _reverseIconLookup.Add(d_spotlight_icon, Enum.d_spotlight_icon);
            _iconLookup.Add(Enum.d_verticallayoutgroup_icon, d_verticallayoutgroup_icon);
            _reverseIconLookup.Add(d_verticallayoutgroup_icon, Enum.d_verticallayoutgroup_icon);
            _iconLookup.Add(Enum.defaultslate_icon, defaultslate_icon);
            _reverseIconLookup.Add(defaultslate_icon, Enum.defaultslate_icon);
            _iconLookup.Add(Enum.directionallight_gizmo, directionallight_gizmo);
            _reverseIconLookup.Add(directionallight_gizmo, Enum.directionallight_gizmo);
            _iconLookup.Add(Enum.directionallight_icon, directionallight_icon);
            _reverseIconLookup.Add(directionallight_icon, Enum.directionallight_icon);
            _iconLookup.Add(Enum.disclight_gizmo, disclight_gizmo);
            _reverseIconLookup.Add(disclight_gizmo, Enum.disclight_gizmo);
            _iconLookup.Add(Enum.disclight_icon, disclight_icon);
            _reverseIconLookup.Add(disclight_icon, Enum.disclight_icon);
            _iconLookup.Add(Enum.dll_script_icon, dll_script_icon);
            _reverseIconLookup.Add(dll_script_icon, Enum.dll_script_icon);
            _iconLookup.Add(Enum.echofilter_icon, echofilter_icon);
            _reverseIconLookup.Add(echofilter_icon, Enum.echofilter_icon);
            _iconLookup.Add(Enum.favorite_icon, favorite_icon);
            _reverseIconLookup.Add(favorite_icon, Enum.favorite_icon);
            _iconLookup.Add(Enum.favorite_on_icon, favorite_on_icon);
            _reverseIconLookup.Add(favorite_on_icon, Enum.favorite_on_icon);
            _iconLookup.Add(Enum.folder_icon, folder_icon);
            _reverseIconLookup.Add(folder_icon, Enum.folder_icon);
            _iconLookup.Add(Enum.folder_on_icon, folder_on_icon);
            _reverseIconLookup.Add(folder_on_icon, Enum.folder_on_icon);
            _iconLookup.Add(Enum.folderempty_icon, folderempty_icon);
            _reverseIconLookup.Add(folderempty_icon, Enum.folderempty_icon);
            _iconLookup.Add(Enum.folderempty_on_icon, folderempty_on_icon);
            _reverseIconLookup.Add(folderempty_on_icon, Enum.folderempty_on_icon);
            _iconLookup.Add(Enum.folderfavorite_icon, folderfavorite_icon);
            _reverseIconLookup.Add(folderfavorite_icon, Enum.folderfavorite_icon);
            _iconLookup.Add(Enum.folderfavorite_on_icon, folderfavorite_on_icon);
            _reverseIconLookup.Add(folderfavorite_on_icon, Enum.folderfavorite_on_icon);
            _iconLookup.Add(Enum.folderopened_icon, folderopened_icon);
            _reverseIconLookup.Add(folderopened_icon, Enum.folderopened_icon);
            _iconLookup.Add(Enum.folderopened_on_icon, folderopened_on_icon);
            _reverseIconLookup.Add(folderopened_on_icon, Enum.folderopened_on_icon);
            _iconLookup.Add(Enum.gamemanager_icon, gamemanager_icon);
            _reverseIconLookup.Add(gamemanager_icon, Enum.gamemanager_icon);
            _iconLookup.Add(Enum.gridbrush_icon, gridbrush_icon);
            _reverseIconLookup.Add(gridbrush_icon, Enum.gridbrush_icon);
            _iconLookup.Add(Enum.highpassfilter_icon, highpassfilter_icon);
            _reverseIconLookup.Add(highpassfilter_icon, Enum.highpassfilter_icon);
            _iconLookup.Add(Enum.horizontallayoutgroup_icon, horizontallayoutgroup_icon);
            _reverseIconLookup.Add(horizontallayoutgroup_icon, Enum.horizontallayoutgroup_icon);
            _iconLookup.Add(Enum.js_script_icon, js_script_icon);
            _reverseIconLookup.Add(js_script_icon, Enum.js_script_icon);
            _iconLookup.Add(Enum.lensflare_gizmo, lensflare_gizmo);
            _reverseIconLookup.Add(lensflare_gizmo, Enum.lensflare_gizmo);
            _iconLookup.Add(Enum.lightingdataassetparent_icon, lightingdataassetparent_icon);
            _reverseIconLookup.Add(lightingdataassetparent_icon, Enum.lightingdataassetparent_icon);
            _iconLookup.Add(Enum.lightprobegroup_gizmo, lightprobegroup_gizmo);
            _reverseIconLookup.Add(lightprobegroup_gizmo, Enum.lightprobegroup_gizmo);
            _iconLookup.Add(Enum.lightprobeproxyvolume_gizmo, lightprobeproxyvolume_gizmo);
            _reverseIconLookup.Add(lightprobeproxyvolume_gizmo, Enum.lightprobeproxyvolume_gizmo);
            _iconLookup.Add(Enum.lowpassfilter_icon, lowpassfilter_icon);
            _reverseIconLookup.Add(lowpassfilter_icon, Enum.lowpassfilter_icon);
            _iconLookup.Add(Enum.main_light_gizmo, main_light_gizmo);
            _reverseIconLookup.Add(main_light_gizmo, Enum.main_light_gizmo);
            _iconLookup.Add(Enum.metafile_icon, metafile_icon);
            _reverseIconLookup.Add(metafile_icon, Enum.metafile_icon);
            _iconLookup.Add(Enum.microphone_icon, microphone_icon);
            _reverseIconLookup.Add(microphone_icon, Enum.microphone_icon);
            _iconLookup.Add(Enum.muscleclip_icon, muscleclip_icon);
            _reverseIconLookup.Add(muscleclip_icon, Enum.muscleclip_icon);
            _iconLookup.Add(Enum.particlesystem_gizmo, particlesystem_gizmo);
            _reverseIconLookup.Add(particlesystem_gizmo, Enum.particlesystem_gizmo);
            _iconLookup.Add(Enum.particlesystemforcefield_gizmo, particlesystemforcefield_gizmo);
            _reverseIconLookup.Add(particlesystemforcefield_gizmo, Enum.particlesystemforcefield_gizmo);
            _iconLookup.Add(Enum.pointlight_gizmo, pointlight_gizmo);
            _reverseIconLookup.Add(pointlight_gizmo, Enum.pointlight_gizmo);
            _iconLookup.Add(Enum.prefab_icon, prefab_icon);
            _reverseIconLookup.Add(prefab_icon, Enum.prefab_icon);
            _iconLookup.Add(Enum.prefab_on_icon, prefab_on_icon);
            _reverseIconLookup.Add(prefab_on_icon, Enum.prefab_on_icon);
            _iconLookup.Add(Enum.prefabmodel_icon, prefabmodel_icon);
            _reverseIconLookup.Add(prefabmodel_icon, Enum.prefabmodel_icon);
            _iconLookup.Add(Enum.prefabmodel_on_icon, prefabmodel_on_icon);
            _reverseIconLookup.Add(prefabmodel_on_icon, Enum.prefabmodel_on_icon);
            _iconLookup.Add(Enum.prefaboverlayadded_icon, prefaboverlayadded_icon);
            _reverseIconLookup.Add(prefaboverlayadded_icon, Enum.prefaboverlayadded_icon);
            _iconLookup.Add(Enum.prefaboverlaymodified_icon, prefaboverlaymodified_icon);
            _reverseIconLookup.Add(prefaboverlaymodified_icon, Enum.prefaboverlaymodified_icon);
            _iconLookup.Add(Enum.prefaboverlayremoved_icon, prefaboverlayremoved_icon);
            _reverseIconLookup.Add(prefaboverlayremoved_icon, Enum.prefaboverlayremoved_icon);
            _iconLookup.Add(Enum.prefabvariant_icon, prefabvariant_icon);
            _reverseIconLookup.Add(prefabvariant_icon, Enum.prefabvariant_icon);
            _iconLookup.Add(Enum.prefabvariant_on_icon, prefabvariant_on_icon);
            _reverseIconLookup.Add(prefabvariant_on_icon, Enum.prefabvariant_on_icon);
            _iconLookup.Add(Enum.projector_gizmo, projector_gizmo);
            _reverseIconLookup.Add(projector_gizmo, Enum.projector_gizmo);
            _iconLookup.Add(Enum.raycastcollider_icon, raycastcollider_icon);
            _reverseIconLookup.Add(raycastcollider_icon, Enum.raycastcollider_icon);
            _iconLookup.Add(Enum.reflectionprobe_gizmo, reflectionprobe_gizmo);
            _reverseIconLookup.Add(reflectionprobe_gizmo, Enum.reflectionprobe_gizmo);
            _iconLookup.Add(Enum.reverbfilter_icon, reverbfilter_icon);
            _reverseIconLookup.Add(reverbfilter_icon, Enum.reverbfilter_icon);
            _iconLookup.Add(Enum.sceneset_icon, sceneset_icon);
            _reverseIconLookup.Add(sceneset_icon, Enum.sceneset_icon);
            _iconLookup.Add(Enum.search_icon, search_icon);
            _reverseIconLookup.Add(search_icon, Enum.search_icon);
            _iconLookup.Add(Enum.search_on_icon, search_on_icon);
            _reverseIconLookup.Add(search_on_icon, Enum.search_on_icon);
            _iconLookup.Add(Enum.searchjump_icon, searchjump_icon);
            _reverseIconLookup.Add(searchjump_icon, Enum.searchjump_icon);
            _iconLookup.Add(Enum.settings_icon, settings_icon);
            _reverseIconLookup.Add(settings_icon, Enum.settings_icon);
            _iconLookup.Add(Enum.shortcut_icon, shortcut_icon);
            _reverseIconLookup.Add(shortcut_icon, Enum.shortcut_icon);
            _iconLookup.Add(Enum.softlockprojectbrowser_icon, softlockprojectbrowser_icon);
            _reverseIconLookup.Add(softlockprojectbrowser_icon, Enum.softlockprojectbrowser_icon);
            _iconLookup.Add(Enum.speedtreemodel_icon, speedtreemodel_icon);
            _reverseIconLookup.Add(speedtreemodel_icon, Enum.speedtreemodel_icon);
            _iconLookup.Add(Enum.spotlight_gizmo, spotlight_gizmo);
            _reverseIconLookup.Add(spotlight_gizmo, Enum.spotlight_gizmo);
            _iconLookup.Add(Enum.spotlight_icon, spotlight_icon);
            _reverseIconLookup.Add(spotlight_icon, Enum.spotlight_icon);
            _iconLookup.Add(Enum.spritecollider_icon, spritecollider_icon);
            _reverseIconLookup.Add(spritecollider_icon, Enum.spritecollider_icon);
            _iconLookup.Add(Enum.sv_icon_dot0_pix16_gizmo, sv_icon_dot0_pix16_gizmo);
            _reverseIconLookup.Add(sv_icon_dot0_pix16_gizmo, Enum.sv_icon_dot0_pix16_gizmo);
            _iconLookup.Add(Enum.sv_icon_dot10_pix16_gizmo, sv_icon_dot10_pix16_gizmo);
            _reverseIconLookup.Add(sv_icon_dot10_pix16_gizmo, Enum.sv_icon_dot10_pix16_gizmo);
            _iconLookup.Add(Enum.sv_icon_dot11_pix16_gizmo, sv_icon_dot11_pix16_gizmo);
            _reverseIconLookup.Add(sv_icon_dot11_pix16_gizmo, Enum.sv_icon_dot11_pix16_gizmo);
            _iconLookup.Add(Enum.sv_icon_dot12_pix16_gizmo, sv_icon_dot12_pix16_gizmo);
            _reverseIconLookup.Add(sv_icon_dot12_pix16_gizmo, Enum.sv_icon_dot12_pix16_gizmo);
            _iconLookup.Add(Enum.sv_icon_dot13_pix16_gizmo, sv_icon_dot13_pix16_gizmo);
            _reverseIconLookup.Add(sv_icon_dot13_pix16_gizmo, Enum.sv_icon_dot13_pix16_gizmo);
            _iconLookup.Add(Enum.sv_icon_dot14_pix16_gizmo, sv_icon_dot14_pix16_gizmo);
            _reverseIconLookup.Add(sv_icon_dot14_pix16_gizmo, Enum.sv_icon_dot14_pix16_gizmo);
            _iconLookup.Add(Enum.sv_icon_dot15_pix16_gizmo, sv_icon_dot15_pix16_gizmo);
            _reverseIconLookup.Add(sv_icon_dot15_pix16_gizmo, Enum.sv_icon_dot15_pix16_gizmo);
            _iconLookup.Add(Enum.sv_icon_dot1_pix16_gizmo, sv_icon_dot1_pix16_gizmo);
            _reverseIconLookup.Add(sv_icon_dot1_pix16_gizmo, Enum.sv_icon_dot1_pix16_gizmo);
            _iconLookup.Add(Enum.sv_icon_dot2_pix16_gizmo, sv_icon_dot2_pix16_gizmo);
            _reverseIconLookup.Add(sv_icon_dot2_pix16_gizmo, Enum.sv_icon_dot2_pix16_gizmo);
            _iconLookup.Add(Enum.sv_icon_dot3_pix16_gizmo, sv_icon_dot3_pix16_gizmo);
            _reverseIconLookup.Add(sv_icon_dot3_pix16_gizmo, Enum.sv_icon_dot3_pix16_gizmo);
            _iconLookup.Add(Enum.sv_icon_dot4_pix16_gizmo, sv_icon_dot4_pix16_gizmo);
            _reverseIconLookup.Add(sv_icon_dot4_pix16_gizmo, Enum.sv_icon_dot4_pix16_gizmo);
            _iconLookup.Add(Enum.sv_icon_dot5_pix16_gizmo, sv_icon_dot5_pix16_gizmo);
            _reverseIconLookup.Add(sv_icon_dot5_pix16_gizmo, Enum.sv_icon_dot5_pix16_gizmo);
            _iconLookup.Add(Enum.sv_icon_dot6_pix16_gizmo, sv_icon_dot6_pix16_gizmo);
            _reverseIconLookup.Add(sv_icon_dot6_pix16_gizmo, Enum.sv_icon_dot6_pix16_gizmo);
            _iconLookup.Add(Enum.sv_icon_dot7_pix16_gizmo, sv_icon_dot7_pix16_gizmo);
            _reverseIconLookup.Add(sv_icon_dot7_pix16_gizmo, Enum.sv_icon_dot7_pix16_gizmo);
            _iconLookup.Add(Enum.sv_icon_dot8_pix16_gizmo, sv_icon_dot8_pix16_gizmo);
            _reverseIconLookup.Add(sv_icon_dot8_pix16_gizmo, Enum.sv_icon_dot8_pix16_gizmo);
            _iconLookup.Add(Enum.sv_icon_dot9_pix16_gizmo, sv_icon_dot9_pix16_gizmo);
            _reverseIconLookup.Add(sv_icon_dot9_pix16_gizmo, Enum.sv_icon_dot9_pix16_gizmo);
            _iconLookup.Add(Enum.animatorcontroller_icon, animatorcontroller_icon);
            _reverseIconLookup.Add(animatorcontroller_icon, Enum.animatorcontroller_icon);
            _iconLookup.Add(Enum.animatorcontroller_on_icon, animatorcontroller_on_icon);
            _reverseIconLookup.Add(animatorcontroller_on_icon, Enum.animatorcontroller_on_icon);
            _iconLookup.Add(Enum.animatorstate_icon, animatorstate_icon);
            _reverseIconLookup.Add(animatorstate_icon, Enum.animatorstate_icon);
            _iconLookup.Add(Enum.animatorstatemachine_icon, animatorstatemachine_icon);
            _reverseIconLookup.Add(animatorstatemachine_icon, Enum.animatorstatemachine_icon);
            _iconLookup.Add(Enum.animatorstatetransition_icon, animatorstatetransition_icon);
            _reverseIconLookup.Add(animatorstatetransition_icon, Enum.animatorstatetransition_icon);
            _iconLookup.Add(Enum.blendtree_icon, blendtree_icon);
            _reverseIconLookup.Add(blendtree_icon, Enum.blendtree_icon);
            _iconLookup.Add(Enum.d_animatorcontroller_icon, d_animatorcontroller_icon);
            _reverseIconLookup.Add(d_animatorcontroller_icon, Enum.d_animatorcontroller_icon);
            _iconLookup.Add(Enum.d_animatorcontroller_on_icon, d_animatorcontroller_on_icon);
            _reverseIconLookup.Add(d_animatorcontroller_on_icon, Enum.d_animatorcontroller_on_icon);
            _iconLookup.Add(Enum.d_animatorstate_icon, d_animatorstate_icon);
            _reverseIconLookup.Add(d_animatorstate_icon, Enum.d_animatorstate_icon);
            _iconLookup.Add(Enum.d_animatorstatemachine_icon, d_animatorstatemachine_icon);
            _reverseIconLookup.Add(d_animatorstatemachine_icon, Enum.d_animatorstatemachine_icon);
            _iconLookup.Add(Enum.d_animatorstatetransition_icon, d_animatorstatetransition_icon);
            _reverseIconLookup.Add(d_animatorstatetransition_icon, Enum.d_animatorstatetransition_icon);
            _iconLookup.Add(Enum.d_blendtree_icon, d_blendtree_icon);
            _reverseIconLookup.Add(d_blendtree_icon, Enum.d_blendtree_icon);
            _iconLookup.Add(Enum.animationwindowevent_icon, animationwindowevent_icon);
            _reverseIconLookup.Add(animationwindowevent_icon, Enum.animationwindowevent_icon);
            _iconLookup.Add(Enum.audiomixercontroller_icon, audiomixercontroller_icon);
            _reverseIconLookup.Add(audiomixercontroller_icon, Enum.audiomixercontroller_icon);
            _iconLookup.Add(Enum.audiomixercontroller_on_icon, audiomixercontroller_on_icon);
            _reverseIconLookup.Add(audiomixercontroller_on_icon, Enum.audiomixercontroller_on_icon);
            _iconLookup.Add(Enum.d_audiomixercontroller_icon, d_audiomixercontroller_icon);
            _reverseIconLookup.Add(d_audiomixercontroller_icon, Enum.d_audiomixercontroller_icon);
            _iconLookup.Add(Enum.d_audiomixercontroller_on_icon, d_audiomixercontroller_on_icon);
            _reverseIconLookup.Add(d_audiomixercontroller_on_icon, Enum.d_audiomixercontroller_on_icon);
            _iconLookup.Add(Enum.audioimporter_icon, audioimporter_icon);
            _reverseIconLookup.Add(audioimporter_icon, Enum.audioimporter_icon);
            _iconLookup.Add(Enum.d_audioimporter_icon, d_audioimporter_icon);
            _reverseIconLookup.Add(d_audioimporter_icon, Enum.d_audioimporter_icon);
            _iconLookup.Add(Enum.d_defaultasset_icon, d_defaultasset_icon);
            _reverseIconLookup.Add(d_defaultasset_icon, Enum.d_defaultasset_icon);
            _iconLookup.Add(Enum.d_filter_icon, d_filter_icon);
            _reverseIconLookup.Add(d_filter_icon, Enum.d_filter_icon);
            _iconLookup.Add(Enum.d_ihvimageformatimporter_icon, d_ihvimageformatimporter_icon);
            _reverseIconLookup.Add(d_ihvimageformatimporter_icon, Enum.d_ihvimageformatimporter_icon);
            _iconLookup.Add(Enum.d_lightingdataasset_icon, d_lightingdataasset_icon);
            _reverseIconLookup.Add(d_lightingdataasset_icon, Enum.d_lightingdataasset_icon);
            _iconLookup.Add(Enum.d_lightmapparameters_icon, d_lightmapparameters_icon);
            _reverseIconLookup.Add(d_lightmapparameters_icon, Enum.d_lightmapparameters_icon);
            _iconLookup.Add(Enum.d_lightmapparameters_on_icon, d_lightmapparameters_on_icon);
            _reverseIconLookup.Add(d_lightmapparameters_on_icon, Enum.d_lightmapparameters_on_icon);
            _iconLookup.Add(Enum.d_modelimporter_icon, d_modelimporter_icon);
            _reverseIconLookup.Add(d_modelimporter_icon, Enum.d_modelimporter_icon);
            _iconLookup.Add(Enum.d_sceneasset_icon, d_sceneasset_icon);
            _reverseIconLookup.Add(d_sceneasset_icon, Enum.d_sceneasset_icon);
            _iconLookup.Add(Enum.d_shaderimporter_icon, d_shaderimporter_icon);
            _reverseIconLookup.Add(d_shaderimporter_icon, Enum.d_shaderimporter_icon);
            _iconLookup.Add(Enum.d_shaderinclude_icon, d_shaderinclude_icon);
            _reverseIconLookup.Add(d_shaderinclude_icon, Enum.d_shaderinclude_icon);
            _iconLookup.Add(Enum.d_textscriptimporter_icon, d_textscriptimporter_icon);
            _reverseIconLookup.Add(d_textscriptimporter_icon, Enum.d_textscriptimporter_icon);
            _iconLookup.Add(Enum.d_textureimporter_icon, d_textureimporter_icon);
            _reverseIconLookup.Add(d_textureimporter_icon, Enum.d_textureimporter_icon);
            _iconLookup.Add(Enum.d_truetypefontimporter_icon, d_truetypefontimporter_icon);
            _reverseIconLookup.Add(d_truetypefontimporter_icon, Enum.d_truetypefontimporter_icon);
            _iconLookup.Add(Enum.defaultasset_icon, defaultasset_icon);
            _reverseIconLookup.Add(defaultasset_icon, Enum.defaultasset_icon);
            _iconLookup.Add(Enum.editorsettings_icon, editorsettings_icon);
            _reverseIconLookup.Add(editorsettings_icon, Enum.editorsettings_icon);
            _iconLookup.Add(Enum.filter_icon, filter_icon);
            _reverseIconLookup.Add(filter_icon, Enum.filter_icon);
            _iconLookup.Add(Enum.anystatenode_icon, anystatenode_icon);
            _reverseIconLookup.Add(anystatenode_icon, Enum.anystatenode_icon);
            _iconLookup.Add(Enum.d_anystatenode_icon, d_anystatenode_icon);
            _reverseIconLookup.Add(d_anystatenode_icon, Enum.d_anystatenode_icon);
            _iconLookup.Add(Enum.humantemplate_icon, humantemplate_icon);
            _reverseIconLookup.Add(humantemplate_icon, Enum.humantemplate_icon);
            _iconLookup.Add(Enum.ihvimageformatimporter_icon, ihvimageformatimporter_icon);
            _reverseIconLookup.Add(ihvimageformatimporter_icon, Enum.ihvimageformatimporter_icon);
            _iconLookup.Add(Enum.lightingdataasset_icon, lightingdataasset_icon);
            _reverseIconLookup.Add(lightingdataasset_icon, Enum.lightingdataasset_icon);
            _iconLookup.Add(Enum.lightmapparameters_icon, lightmapparameters_icon);
            _reverseIconLookup.Add(lightmapparameters_icon, Enum.lightmapparameters_icon);
            _iconLookup.Add(Enum.lightmapparameters_on_icon, lightmapparameters_on_icon);
            _reverseIconLookup.Add(lightmapparameters_on_icon, Enum.lightmapparameters_on_icon);
            _iconLookup.Add(Enum.modelimporter_icon, modelimporter_icon);
            _reverseIconLookup.Add(modelimporter_icon, Enum.modelimporter_icon);
            _iconLookup.Add(Enum.preset_icon, preset_icon);
            _reverseIconLookup.Add(preset_icon, Enum.preset_icon);
            _iconLookup.Add(Enum.sceneasset_icon, sceneasset_icon);
            _reverseIconLookup.Add(sceneasset_icon, Enum.sceneasset_icon);
            _iconLookup.Add(Enum.sceneasset_on_icon, sceneasset_on_icon);
            _reverseIconLookup.Add(sceneasset_on_icon, Enum.sceneasset_on_icon);
            _iconLookup.Add(Enum.scenetemplateasset_icon, scenetemplateasset_icon);
            _reverseIconLookup.Add(scenetemplateasset_icon, Enum.scenetemplateasset_icon);
            _iconLookup.Add(Enum.d_searchdatabase_icon, d_searchdatabase_icon);
            _reverseIconLookup.Add(d_searchdatabase_icon, Enum.d_searchdatabase_icon);
            _iconLookup.Add(Enum.d_searchquery_icon, d_searchquery_icon);
            _reverseIconLookup.Add(d_searchquery_icon, Enum.d_searchquery_icon);
            _iconLookup.Add(Enum.d_searchqueryasset_icon, d_searchqueryasset_icon);
            _reverseIconLookup.Add(d_searchqueryasset_icon, Enum.d_searchqueryasset_icon);
            _iconLookup.Add(Enum.searchdatabase_icon, searchdatabase_icon);
            _reverseIconLookup.Add(searchdatabase_icon, Enum.searchdatabase_icon);
            _iconLookup.Add(Enum.searchquery_icon, searchquery_icon);
            _reverseIconLookup.Add(searchquery_icon, Enum.searchquery_icon);
            _iconLookup.Add(Enum.searchqueryasset_icon, searchqueryasset_icon);
            _reverseIconLookup.Add(searchqueryasset_icon, Enum.searchqueryasset_icon);
            _iconLookup.Add(Enum.shaderimporter_icon, shaderimporter_icon);
            _reverseIconLookup.Add(shaderimporter_icon, Enum.shaderimporter_icon);
            _iconLookup.Add(Enum.shaderinclude_icon, shaderinclude_icon);
            _reverseIconLookup.Add(shaderinclude_icon, Enum.shaderinclude_icon);
            _iconLookup.Add(Enum.speedtreeimporter_icon, speedtreeimporter_icon);
            _reverseIconLookup.Add(speedtreeimporter_icon, Enum.speedtreeimporter_icon);
            _iconLookup.Add(Enum.substancearchive_icon, substancearchive_icon);
            _reverseIconLookup.Add(substancearchive_icon, Enum.substancearchive_icon);
            _iconLookup.Add(Enum.textscriptimporter_icon, textscriptimporter_icon);
            _reverseIconLookup.Add(textscriptimporter_icon, Enum.textscriptimporter_icon);
            _iconLookup.Add(Enum.textureimporter_icon, textureimporter_icon);
            _reverseIconLookup.Add(textureimporter_icon, Enum.textureimporter_icon);
            _iconLookup.Add(Enum.truetypefontimporter_icon, truetypefontimporter_icon);
            _reverseIconLookup.Add(truetypefontimporter_icon, Enum.truetypefontimporter_icon);
            _iconLookup.Add(Enum.d_spriteatlasasset_icon, d_spriteatlasasset_icon);
            _reverseIconLookup.Add(d_spriteatlasasset_icon, Enum.d_spriteatlasasset_icon);
            _iconLookup.Add(Enum.d_spriteatlasimporter_icon, d_spriteatlasimporter_icon);
            _reverseIconLookup.Add(d_spriteatlasimporter_icon, Enum.d_spriteatlasimporter_icon);
            _iconLookup.Add(Enum.spriteatlasasset_icon, spriteatlasasset_icon);
            _reverseIconLookup.Add(spriteatlasasset_icon, Enum.spriteatlasasset_icon);
            _iconLookup.Add(Enum.spriteatlasimporter_icon, spriteatlasimporter_icon);
            _reverseIconLookup.Add(spriteatlasimporter_icon, Enum.spriteatlasimporter_icon);
            _iconLookup.Add(Enum.d_visualeffectsubgraphblock_icon, d_visualeffectsubgraphblock_icon);
            _reverseIconLookup.Add(d_visualeffectsubgraphblock_icon, Enum.d_visualeffectsubgraphblock_icon);
            _iconLookup.Add(Enum.d_visualeffectsubgraphoperator_icon, d_visualeffectsubgraphoperator_icon);
            _reverseIconLookup.Add(d_visualeffectsubgraphoperator_icon, Enum.d_visualeffectsubgraphoperator_icon);
            _iconLookup.Add(Enum.visualeffectsubgraphblock_icon, visualeffectsubgraphblock_icon);
            _reverseIconLookup.Add(visualeffectsubgraphblock_icon, Enum.visualeffectsubgraphblock_icon);
            _iconLookup.Add(Enum.visualeffectsubgraphoperator_icon, visualeffectsubgraphoperator_icon);
            _reverseIconLookup.Add(visualeffectsubgraphoperator_icon, Enum.visualeffectsubgraphoperator_icon);
            _iconLookup.Add(Enum.videoclipimporter_icon, videoclipimporter_icon);
            _reverseIconLookup.Add(videoclipimporter_icon, Enum.videoclipimporter_icon);
            _iconLookup.Add(Enum.assemblydefinitionasset_icon, assemblydefinitionasset_icon);
            _reverseIconLookup.Add(assemblydefinitionasset_icon, Enum.assemblydefinitionasset_icon);
            _iconLookup.Add(Enum.assemblydefinitionreferenceasset_icon, assemblydefinitionreferenceasset_icon);
            _reverseIconLookup.Add(assemblydefinitionreferenceasset_icon, Enum.assemblydefinitionreferenceasset_icon);
            _iconLookup.Add(Enum.d_assemblydefinitionasset_icon, d_assemblydefinitionasset_icon);
            _reverseIconLookup.Add(d_assemblydefinitionasset_icon, Enum.d_assemblydefinitionasset_icon);
            _iconLookup.Add(Enum.d_assemblydefinitionreferenceasset_icon, d_assemblydefinitionreferenceasset_icon);
            _reverseIconLookup.Add(d_assemblydefinitionreferenceasset_icon, Enum.d_assemblydefinitionreferenceasset_icon);
            _iconLookup.Add(Enum.d_navmeshagent_icon, d_navmeshagent_icon);
            _reverseIconLookup.Add(d_navmeshagent_icon, Enum.d_navmeshagent_icon);
            _iconLookup.Add(Enum.d_navmeshdata_icon, d_navmeshdata_icon);
            _reverseIconLookup.Add(d_navmeshdata_icon, Enum.d_navmeshdata_icon);
            _iconLookup.Add(Enum.d_navmeshobstacle_icon, d_navmeshobstacle_icon);
            _reverseIconLookup.Add(d_navmeshobstacle_icon, Enum.d_navmeshobstacle_icon);
            _iconLookup.Add(Enum.d_offmeshlink_icon, d_offmeshlink_icon);
            _reverseIconLookup.Add(d_offmeshlink_icon, Enum.d_offmeshlink_icon);
            _iconLookup.Add(Enum.navmeshagent_icon, navmeshagent_icon);
            _reverseIconLookup.Add(navmeshagent_icon, Enum.navmeshagent_icon);
            _iconLookup.Add(Enum.navmeshdata_icon, navmeshdata_icon);
            _reverseIconLookup.Add(navmeshdata_icon, Enum.navmeshdata_icon);
            _iconLookup.Add(Enum.navmeshobstacle_icon, navmeshobstacle_icon);
            _reverseIconLookup.Add(navmeshobstacle_icon, Enum.navmeshobstacle_icon);
            _iconLookup.Add(Enum.offmeshlink_icon, offmeshlink_icon);
            _reverseIconLookup.Add(offmeshlink_icon, Enum.offmeshlink_icon);
            _iconLookup.Add(Enum.analyticstracker_icon, analyticstracker_icon);
            _reverseIconLookup.Add(analyticstracker_icon, Enum.analyticstracker_icon);
            _iconLookup.Add(Enum.d_analyticstracker_icon, d_analyticstracker_icon);
            _reverseIconLookup.Add(d_analyticstracker_icon, Enum.d_analyticstracker_icon);
            _iconLookup.Add(Enum.animation_icon, animation_icon);
            _reverseIconLookup.Add(animation_icon, Enum.animation_icon);
            _iconLookup.Add(Enum.animationclip_icon, animationclip_icon);
            _reverseIconLookup.Add(animationclip_icon, Enum.animationclip_icon);
            _iconLookup.Add(Enum.animationclip_on_icon, animationclip_on_icon);
            _reverseIconLookup.Add(animationclip_on_icon, Enum.animationclip_on_icon);
            _iconLookup.Add(Enum.aimconstraint_icon, aimconstraint_icon);
            _reverseIconLookup.Add(aimconstraint_icon, Enum.aimconstraint_icon);
            _iconLookup.Add(Enum.d_aimconstraint_icon, d_aimconstraint_icon);
            _reverseIconLookup.Add(d_aimconstraint_icon, Enum.d_aimconstraint_icon);
            _iconLookup.Add(Enum.d_lookatconstraint_icon, d_lookatconstraint_icon);
            _reverseIconLookup.Add(d_lookatconstraint_icon, Enum.d_lookatconstraint_icon);
            _iconLookup.Add(Enum.d_parentconstraint_icon, d_parentconstraint_icon);
            _reverseIconLookup.Add(d_parentconstraint_icon, Enum.d_parentconstraint_icon);
            _iconLookup.Add(Enum.d_positionconstraint_icon, d_positionconstraint_icon);
            _reverseIconLookup.Add(d_positionconstraint_icon, Enum.d_positionconstraint_icon);
            _iconLookup.Add(Enum.d_rotationconstraint_icon, d_rotationconstraint_icon);
            _reverseIconLookup.Add(d_rotationconstraint_icon, Enum.d_rotationconstraint_icon);
            _iconLookup.Add(Enum.d_scaleconstraint_icon, d_scaleconstraint_icon);
            _reverseIconLookup.Add(d_scaleconstraint_icon, Enum.d_scaleconstraint_icon);
            _iconLookup.Add(Enum.lookatconstraint_icon, lookatconstraint_icon);
            _reverseIconLookup.Add(lookatconstraint_icon, Enum.lookatconstraint_icon);
            _iconLookup.Add(Enum.parentconstraint_icon, parentconstraint_icon);
            _reverseIconLookup.Add(parentconstraint_icon, Enum.parentconstraint_icon);
            _iconLookup.Add(Enum.positionconstraint_icon, positionconstraint_icon);
            _reverseIconLookup.Add(positionconstraint_icon, Enum.positionconstraint_icon);
            _iconLookup.Add(Enum.rotationconstraint_icon, rotationconstraint_icon);
            _reverseIconLookup.Add(rotationconstraint_icon, Enum.rotationconstraint_icon);
            _iconLookup.Add(Enum.scaleconstraint_icon, scaleconstraint_icon);
            _reverseIconLookup.Add(scaleconstraint_icon, Enum.scaleconstraint_icon);
            _iconLookup.Add(Enum.animator_icon, animator_icon);
            _reverseIconLookup.Add(animator_icon, Enum.animator_icon);
            _iconLookup.Add(Enum.animatoroverridecontroller_icon, animatoroverridecontroller_icon);
            _reverseIconLookup.Add(animatoroverridecontroller_icon, Enum.animatoroverridecontroller_icon);
            _iconLookup.Add(Enum.animatoroverridecontroller_on_icon, animatoroverridecontroller_on_icon);
            _reverseIconLookup.Add(animatoroverridecontroller_on_icon, Enum.animatoroverridecontroller_on_icon);
            _iconLookup.Add(Enum.areaeffector2d_icon, areaeffector2d_icon);
            _reverseIconLookup.Add(areaeffector2d_icon, Enum.areaeffector2d_icon);
            _iconLookup.Add(Enum.articulationbody_icon, articulationbody_icon);
            _reverseIconLookup.Add(articulationbody_icon, Enum.articulationbody_icon);
            _iconLookup.Add(Enum.audiomixergroup_icon, audiomixergroup_icon);
            _reverseIconLookup.Add(audiomixergroup_icon, Enum.audiomixergroup_icon);
            _iconLookup.Add(Enum.audiomixersnapshot_icon, audiomixersnapshot_icon);
            _reverseIconLookup.Add(audiomixersnapshot_icon, Enum.audiomixersnapshot_icon);
            _iconLookup.Add(Enum.audiospatializermicrosoft_icon, audiospatializermicrosoft_icon);
            _reverseIconLookup.Add(audiospatializermicrosoft_icon, Enum.audiospatializermicrosoft_icon);
            _iconLookup.Add(Enum.d_audiomixergroup_icon, d_audiomixergroup_icon);
            _reverseIconLookup.Add(d_audiomixergroup_icon, Enum.d_audiomixergroup_icon);
            _iconLookup.Add(Enum.d_audiomixersnapshot_icon, d_audiomixersnapshot_icon);
            _reverseIconLookup.Add(d_audiomixersnapshot_icon, Enum.d_audiomixersnapshot_icon);
            _iconLookup.Add(Enum.d_audiospatializermicrosoft_icon, d_audiospatializermicrosoft_icon);
            _reverseIconLookup.Add(d_audiospatializermicrosoft_icon, Enum.d_audiospatializermicrosoft_icon);
            _iconLookup.Add(Enum.audiochorusfilter_icon, audiochorusfilter_icon);
            _reverseIconLookup.Add(audiochorusfilter_icon, Enum.audiochorusfilter_icon);
            _iconLookup.Add(Enum.audioclip_icon, audioclip_icon);
            _reverseIconLookup.Add(audioclip_icon, Enum.audioclip_icon);
            _iconLookup.Add(Enum.audioclip_on_icon, audioclip_on_icon);
            _reverseIconLookup.Add(audioclip_on_icon, Enum.audioclip_on_icon);
            _iconLookup.Add(Enum.audiodistortionfilter_icon, audiodistortionfilter_icon);
            _reverseIconLookup.Add(audiodistortionfilter_icon, Enum.audiodistortionfilter_icon);
            _iconLookup.Add(Enum.audioechofilter_icon, audioechofilter_icon);
            _reverseIconLookup.Add(audioechofilter_icon, Enum.audioechofilter_icon);
            _iconLookup.Add(Enum.audiohighpassfilter_icon, audiohighpassfilter_icon);
            _reverseIconLookup.Add(audiohighpassfilter_icon, Enum.audiohighpassfilter_icon);
            _iconLookup.Add(Enum.audiolistener_icon, audiolistener_icon);
            _reverseIconLookup.Add(audiolistener_icon, Enum.audiolistener_icon);
            _iconLookup.Add(Enum.audiolowpassfilter_icon, audiolowpassfilter_icon);
            _reverseIconLookup.Add(audiolowpassfilter_icon, Enum.audiolowpassfilter_icon);
            _iconLookup.Add(Enum.audioreverbfilter_icon, audioreverbfilter_icon);
            _reverseIconLookup.Add(audioreverbfilter_icon, Enum.audioreverbfilter_icon);
            _iconLookup.Add(Enum.audioreverbzone_icon, audioreverbzone_icon);
            _reverseIconLookup.Add(audioreverbzone_icon, Enum.audioreverbzone_icon);
            _iconLookup.Add(Enum.audiosource_icon, audiosource_icon);
            _reverseIconLookup.Add(audiosource_icon, Enum.audiosource_icon);
            _iconLookup.Add(Enum.avatar_icon, avatar_icon);
            _reverseIconLookup.Add(avatar_icon, Enum.avatar_icon);
            _iconLookup.Add(Enum.avatarmask_icon, avatarmask_icon);
            _reverseIconLookup.Add(avatarmask_icon, Enum.avatarmask_icon);
            _iconLookup.Add(Enum.avatarmask_on_icon, avatarmask_on_icon);
            _reverseIconLookup.Add(avatarmask_on_icon, Enum.avatarmask_on_icon);
            _iconLookup.Add(Enum.billboardasset_icon, billboardasset_icon);
            _reverseIconLookup.Add(billboardasset_icon, Enum.billboardasset_icon);
            _iconLookup.Add(Enum.billboardrenderer_icon, billboardrenderer_icon);
            _reverseIconLookup.Add(billboardrenderer_icon, Enum.billboardrenderer_icon);
            _iconLookup.Add(Enum.boxcollider_icon, boxcollider_icon);
            _reverseIconLookup.Add(boxcollider_icon, Enum.boxcollider_icon);
            _iconLookup.Add(Enum.boxcollider2d_icon, boxcollider2d_icon);
            _reverseIconLookup.Add(boxcollider2d_icon, Enum.boxcollider2d_icon);
            _iconLookup.Add(Enum.buoyancyeffector2d_icon, buoyancyeffector2d_icon);
            _reverseIconLookup.Add(buoyancyeffector2d_icon, Enum.buoyancyeffector2d_icon);
            _iconLookup.Add(Enum.camera_icon, camera_icon);
            _reverseIconLookup.Add(camera_icon, Enum.camera_icon);
            _iconLookup.Add(Enum.canvas_icon, canvas_icon);
            _reverseIconLookup.Add(canvas_icon, Enum.canvas_icon);
            _iconLookup.Add(Enum.canvasgroup_icon, canvasgroup_icon);
            _reverseIconLookup.Add(canvasgroup_icon, Enum.canvasgroup_icon);
            _iconLookup.Add(Enum.canvasrenderer_icon, canvasrenderer_icon);
            _reverseIconLookup.Add(canvasrenderer_icon, Enum.canvasrenderer_icon);
            _iconLookup.Add(Enum.capsulecollider_icon, capsulecollider_icon);
            _reverseIconLookup.Add(capsulecollider_icon, Enum.capsulecollider_icon);
            _iconLookup.Add(Enum.capsulecollider2d_icon, capsulecollider2d_icon);
            _reverseIconLookup.Add(capsulecollider2d_icon, Enum.capsulecollider2d_icon);
            _iconLookup.Add(Enum.charactercontroller_icon, charactercontroller_icon);
            _reverseIconLookup.Add(charactercontroller_icon, Enum.charactercontroller_icon);
            _iconLookup.Add(Enum.characterjoint_icon, characterjoint_icon);
            _reverseIconLookup.Add(characterjoint_icon, Enum.characterjoint_icon);
            _iconLookup.Add(Enum.circlecollider2d_icon, circlecollider2d_icon);
            _reverseIconLookup.Add(circlecollider2d_icon, Enum.circlecollider2d_icon);
            _iconLookup.Add(Enum.cloth_icon, cloth_icon);
            _reverseIconLookup.Add(cloth_icon, Enum.cloth_icon);
            _iconLookup.Add(Enum.compositecollider2d_icon, compositecollider2d_icon);
            _reverseIconLookup.Add(compositecollider2d_icon, Enum.compositecollider2d_icon);
            _iconLookup.Add(Enum.computeshader_icon, computeshader_icon);
            _reverseIconLookup.Add(computeshader_icon, Enum.computeshader_icon);
            _iconLookup.Add(Enum.configurablejoint_icon, configurablejoint_icon);
            _reverseIconLookup.Add(configurablejoint_icon, Enum.configurablejoint_icon);
            _iconLookup.Add(Enum.constantforce_icon, constantforce_icon);
            _reverseIconLookup.Add(constantforce_icon, Enum.constantforce_icon);
            _iconLookup.Add(Enum.constantforce2d_icon, constantforce2d_icon);
            _reverseIconLookup.Add(constantforce2d_icon, Enum.constantforce2d_icon);
            _iconLookup.Add(Enum.cubemap_icon, cubemap_icon);
            _reverseIconLookup.Add(cubemap_icon, Enum.cubemap_icon);
            _iconLookup.Add(Enum.customcollider2d_icon, customcollider2d_icon);
            _reverseIconLookup.Add(customcollider2d_icon, Enum.customcollider2d_icon);
            _iconLookup.Add(Enum.d_animation_icon, d_animation_icon);
            _reverseIconLookup.Add(d_animation_icon, Enum.d_animation_icon);
            _iconLookup.Add(Enum.d_animationclip_icon, d_animationclip_icon);
            _reverseIconLookup.Add(d_animationclip_icon, Enum.d_animationclip_icon);
            _iconLookup.Add(Enum.d_animationclip_on_icon, d_animationclip_on_icon);
            _reverseIconLookup.Add(d_animationclip_on_icon, Enum.d_animationclip_on_icon);
            _iconLookup.Add(Enum.d_animator_icon, d_animator_icon);
            _reverseIconLookup.Add(d_animator_icon, Enum.d_animator_icon);
            _iconLookup.Add(Enum.d_animatoroverridecontroller_icon, d_animatoroverridecontroller_icon);
            _reverseIconLookup.Add(d_animatoroverridecontroller_icon, Enum.d_animatoroverridecontroller_icon);
            _iconLookup.Add(Enum.d_animatoroverridecontroller_on_icon, d_animatoroverridecontroller_on_icon);
            _reverseIconLookup.Add(d_animatoroverridecontroller_on_icon, Enum.d_animatoroverridecontroller_on_icon);
            _iconLookup.Add(Enum.d_areaeffector2d_icon, d_areaeffector2d_icon);
            _reverseIconLookup.Add(d_areaeffector2d_icon, Enum.d_areaeffector2d_icon);
            _iconLookup.Add(Enum.d_articulationbody_icon, d_articulationbody_icon);
            _reverseIconLookup.Add(d_articulationbody_icon, Enum.d_articulationbody_icon);
            _iconLookup.Add(Enum.d_audiochorusfilter_icon, d_audiochorusfilter_icon);
            _reverseIconLookup.Add(d_audiochorusfilter_icon, Enum.d_audiochorusfilter_icon);
            _iconLookup.Add(Enum.d_audioclip_icon, d_audioclip_icon);
            _reverseIconLookup.Add(d_audioclip_icon, Enum.d_audioclip_icon);
            _iconLookup.Add(Enum.d_audioclip_on_icon, d_audioclip_on_icon);
            _reverseIconLookup.Add(d_audioclip_on_icon, Enum.d_audioclip_on_icon);
            _iconLookup.Add(Enum.d_audiodistortionfilter_icon, d_audiodistortionfilter_icon);
            _reverseIconLookup.Add(d_audiodistortionfilter_icon, Enum.d_audiodistortionfilter_icon);
            _iconLookup.Add(Enum.d_audioechofilter_icon, d_audioechofilter_icon);
            _reverseIconLookup.Add(d_audioechofilter_icon, Enum.d_audioechofilter_icon);
            _iconLookup.Add(Enum.d_audiohighpassfilter_icon, d_audiohighpassfilter_icon);
            _reverseIconLookup.Add(d_audiohighpassfilter_icon, Enum.d_audiohighpassfilter_icon);
            _iconLookup.Add(Enum.d_audiolistener_icon, d_audiolistener_icon);
            _reverseIconLookup.Add(d_audiolistener_icon, Enum.d_audiolistener_icon);
            _iconLookup.Add(Enum.d_audiolowpassfilter_icon, d_audiolowpassfilter_icon);
            _reverseIconLookup.Add(d_audiolowpassfilter_icon, Enum.d_audiolowpassfilter_icon);
            _iconLookup.Add(Enum.d_audioreverbfilter_icon, d_audioreverbfilter_icon);
            _reverseIconLookup.Add(d_audioreverbfilter_icon, Enum.d_audioreverbfilter_icon);
            _iconLookup.Add(Enum.d_audioreverbzone_icon, d_audioreverbzone_icon);
            _reverseIconLookup.Add(d_audioreverbzone_icon, Enum.d_audioreverbzone_icon);
            _iconLookup.Add(Enum.d_audiosource_icon, d_audiosource_icon);
            _reverseIconLookup.Add(d_audiosource_icon, Enum.d_audiosource_icon);
            _iconLookup.Add(Enum.d_avatar_icon, d_avatar_icon);
            _reverseIconLookup.Add(d_avatar_icon, Enum.d_avatar_icon);
            _iconLookup.Add(Enum.d_avatarmask_icon, d_avatarmask_icon);
            _reverseIconLookup.Add(d_avatarmask_icon, Enum.d_avatarmask_icon);
            _iconLookup.Add(Enum.d_avatarmask_on_icon, d_avatarmask_on_icon);
            _reverseIconLookup.Add(d_avatarmask_on_icon, Enum.d_avatarmask_on_icon);
            _iconLookup.Add(Enum.d_billboardasset_icon, d_billboardasset_icon);
            _reverseIconLookup.Add(d_billboardasset_icon, Enum.d_billboardasset_icon);
            _iconLookup.Add(Enum.d_billboardrenderer_icon, d_billboardrenderer_icon);
            _reverseIconLookup.Add(d_billboardrenderer_icon, Enum.d_billboardrenderer_icon);
            _iconLookup.Add(Enum.d_boxcollider_icon, d_boxcollider_icon);
            _reverseIconLookup.Add(d_boxcollider_icon, Enum.d_boxcollider_icon);
            _iconLookup.Add(Enum.d_boxcollider2d_icon, d_boxcollider2d_icon);
            _reverseIconLookup.Add(d_boxcollider2d_icon, Enum.d_boxcollider2d_icon);
            _iconLookup.Add(Enum.d_buoyancyeffector2d_icon, d_buoyancyeffector2d_icon);
            _reverseIconLookup.Add(d_buoyancyeffector2d_icon, Enum.d_buoyancyeffector2d_icon);
            _iconLookup.Add(Enum.d_camera_icon, d_camera_icon);
            _reverseIconLookup.Add(d_camera_icon, Enum.d_camera_icon);
            _iconLookup.Add(Enum.d_canvas_icon, d_canvas_icon);
            _reverseIconLookup.Add(d_canvas_icon, Enum.d_canvas_icon);
            _iconLookup.Add(Enum.d_canvasgroup_icon, d_canvasgroup_icon);
            _reverseIconLookup.Add(d_canvasgroup_icon, Enum.d_canvasgroup_icon);
            _iconLookup.Add(Enum.d_canvasrenderer_icon, d_canvasrenderer_icon);
            _reverseIconLookup.Add(d_canvasrenderer_icon, Enum.d_canvasrenderer_icon);
            _iconLookup.Add(Enum.d_capsulecollider_icon, d_capsulecollider_icon);
            _reverseIconLookup.Add(d_capsulecollider_icon, Enum.d_capsulecollider_icon);
            _iconLookup.Add(Enum.d_capsulecollider2d_icon, d_capsulecollider2d_icon);
            _reverseIconLookup.Add(d_capsulecollider2d_icon, Enum.d_capsulecollider2d_icon);
            _iconLookup.Add(Enum.d_charactercontroller_icon, d_charactercontroller_icon);
            _reverseIconLookup.Add(d_charactercontroller_icon, Enum.d_charactercontroller_icon);
            _iconLookup.Add(Enum.d_characterjoint_icon, d_characterjoint_icon);
            _reverseIconLookup.Add(d_characterjoint_icon, Enum.d_characterjoint_icon);
            _iconLookup.Add(Enum.d_circlecollider2d_icon, d_circlecollider2d_icon);
            _reverseIconLookup.Add(d_circlecollider2d_icon, Enum.d_circlecollider2d_icon);
            _iconLookup.Add(Enum.d_cloth_icon, d_cloth_icon);
            _reverseIconLookup.Add(d_cloth_icon, Enum.d_cloth_icon);
            _iconLookup.Add(Enum.d_compositecollider2d_icon, d_compositecollider2d_icon);
            _reverseIconLookup.Add(d_compositecollider2d_icon, Enum.d_compositecollider2d_icon);
            _iconLookup.Add(Enum.d_computeshader_icon, d_computeshader_icon);
            _reverseIconLookup.Add(d_computeshader_icon, Enum.d_computeshader_icon);
            _iconLookup.Add(Enum.d_configurablejoint_icon, d_configurablejoint_icon);
            _reverseIconLookup.Add(d_configurablejoint_icon, Enum.d_configurablejoint_icon);
            _iconLookup.Add(Enum.d_constantforce_icon, d_constantforce_icon);
            _reverseIconLookup.Add(d_constantforce_icon, Enum.d_constantforce_icon);
            _iconLookup.Add(Enum.d_constantforce2d_icon, d_constantforce2d_icon);
            _reverseIconLookup.Add(d_constantforce2d_icon, Enum.d_constantforce2d_icon);
            _iconLookup.Add(Enum.d_cubemap_icon, d_cubemap_icon);
            _reverseIconLookup.Add(d_cubemap_icon, Enum.d_cubemap_icon);
            _iconLookup.Add(Enum.d_distancejoint2d_icon, d_distancejoint2d_icon);
            _reverseIconLookup.Add(d_distancejoint2d_icon, Enum.d_distancejoint2d_icon);
            _iconLookup.Add(Enum.d_edgecollider2d_icon, d_edgecollider2d_icon);
            _reverseIconLookup.Add(d_edgecollider2d_icon, Enum.d_edgecollider2d_icon);
            _iconLookup.Add(Enum.d_fixedjoint_icon, d_fixedjoint_icon);
            _reverseIconLookup.Add(d_fixedjoint_icon, Enum.d_fixedjoint_icon);
            _iconLookup.Add(Enum.d_flare_icon, d_flare_icon);
            _reverseIconLookup.Add(d_flare_icon, Enum.d_flare_icon);
            _iconLookup.Add(Enum.d_flare_on_icon, d_flare_on_icon);
            _reverseIconLookup.Add(d_flare_on_icon, Enum.d_flare_on_icon);
            _iconLookup.Add(Enum.d_flarelayer_icon, d_flarelayer_icon);
            _reverseIconLookup.Add(d_flarelayer_icon, Enum.d_flarelayer_icon);
            _iconLookup.Add(Enum.d_font_icon, d_font_icon);
            _reverseIconLookup.Add(d_font_icon, Enum.d_font_icon);
            _iconLookup.Add(Enum.d_font_on_icon, d_font_on_icon);
            _reverseIconLookup.Add(d_font_on_icon, Enum.d_font_on_icon);
            _iconLookup.Add(Enum.d_frictionjoint2d_icon, d_frictionjoint2d_icon);
            _reverseIconLookup.Add(d_frictionjoint2d_icon, Enum.d_frictionjoint2d_icon);
            _iconLookup.Add(Enum.d_gameobject_icon, d_gameobject_icon);
            _reverseIconLookup.Add(d_gameobject_icon, Enum.d_gameobject_icon);
            _iconLookup.Add(Enum.d_grid_icon, d_grid_icon);
            _reverseIconLookup.Add(d_grid_icon, Enum.d_grid_icon);
            _iconLookup.Add(Enum.d_guiskin_icon, d_guiskin_icon);
            _reverseIconLookup.Add(d_guiskin_icon, Enum.d_guiskin_icon);
            _iconLookup.Add(Enum.d_guiskin_on_icon, d_guiskin_on_icon);
            _reverseIconLookup.Add(d_guiskin_on_icon, Enum.d_guiskin_on_icon);
            _iconLookup.Add(Enum.d_halo_icon, d_halo_icon);
            _reverseIconLookup.Add(d_halo_icon, Enum.d_halo_icon);
            _iconLookup.Add(Enum.d_hingejoint_icon, d_hingejoint_icon);
            _reverseIconLookup.Add(d_hingejoint_icon, Enum.d_hingejoint_icon);
            _iconLookup.Add(Enum.d_hingejoint2d_icon, d_hingejoint2d_icon);
            _reverseIconLookup.Add(d_hingejoint2d_icon, Enum.d_hingejoint2d_icon);
            _iconLookup.Add(Enum.d_light_icon, d_light_icon);
            _reverseIconLookup.Add(d_light_icon, Enum.d_light_icon);
            _iconLookup.Add(Enum.d_lightingsettings_icon, d_lightingsettings_icon);
            _reverseIconLookup.Add(d_lightingsettings_icon, Enum.d_lightingsettings_icon);
            _iconLookup.Add(Enum.d_lightprobegroup_icon, d_lightprobegroup_icon);
            _reverseIconLookup.Add(d_lightprobegroup_icon, Enum.d_lightprobegroup_icon);
            _iconLookup.Add(Enum.d_lightprobeproxyvolume_icon, d_lightprobeproxyvolume_icon);
            _reverseIconLookup.Add(d_lightprobeproxyvolume_icon, Enum.d_lightprobeproxyvolume_icon);
            _iconLookup.Add(Enum.d_lightprobes_icon, d_lightprobes_icon);
            _reverseIconLookup.Add(d_lightprobes_icon, Enum.d_lightprobes_icon);
            _iconLookup.Add(Enum.d_linerenderer_icon, d_linerenderer_icon);
            _reverseIconLookup.Add(d_linerenderer_icon, Enum.d_linerenderer_icon);
            _iconLookup.Add(Enum.d_lodgroup_icon, d_lodgroup_icon);
            _reverseIconLookup.Add(d_lodgroup_icon, Enum.d_lodgroup_icon);
            _iconLookup.Add(Enum.d_material_icon, d_material_icon);
            _reverseIconLookup.Add(d_material_icon, Enum.d_material_icon);
            _iconLookup.Add(Enum.d_material_on_icon, d_material_on_icon);
            _reverseIconLookup.Add(d_material_on_icon, Enum.d_material_on_icon);
            _iconLookup.Add(Enum.d_mesh_icon, d_mesh_icon);
            _reverseIconLookup.Add(d_mesh_icon, Enum.d_mesh_icon);
            _iconLookup.Add(Enum.d_meshcollider_icon, d_meshcollider_icon);
            _reverseIconLookup.Add(d_meshcollider_icon, Enum.d_meshcollider_icon);
            _iconLookup.Add(Enum.d_meshfilter_icon, d_meshfilter_icon);
            _reverseIconLookup.Add(d_meshfilter_icon, Enum.d_meshfilter_icon);
            _iconLookup.Add(Enum.d_meshrenderer_icon, d_meshrenderer_icon);
            _reverseIconLookup.Add(d_meshrenderer_icon, Enum.d_meshrenderer_icon);
            _iconLookup.Add(Enum.d_motion_icon, d_motion_icon);
            _reverseIconLookup.Add(d_motion_icon, Enum.d_motion_icon);
            _iconLookup.Add(Enum.d_occlusionarea_icon, d_occlusionarea_icon);
            _reverseIconLookup.Add(d_occlusionarea_icon, Enum.d_occlusionarea_icon);
            _iconLookup.Add(Enum.d_occlusionportal_icon, d_occlusionportal_icon);
            _reverseIconLookup.Add(d_occlusionportal_icon, Enum.d_occlusionportal_icon);
            _iconLookup.Add(Enum.d_particlesystem_icon, d_particlesystem_icon);
            _reverseIconLookup.Add(d_particlesystem_icon, Enum.d_particlesystem_icon);
            _iconLookup.Add(Enum.d_particlesystemforcefield_icon, d_particlesystemforcefield_icon);
            _reverseIconLookup.Add(d_particlesystemforcefield_icon, Enum.d_particlesystemforcefield_icon);
            _iconLookup.Add(Enum.d_physicmaterial_icon, d_physicmaterial_icon);
            _reverseIconLookup.Add(d_physicmaterial_icon, Enum.d_physicmaterial_icon);
            _iconLookup.Add(Enum.d_physicmaterial_on_icon, d_physicmaterial_on_icon);
            _reverseIconLookup.Add(d_physicmaterial_on_icon, Enum.d_physicmaterial_on_icon);
            _iconLookup.Add(Enum.d_physicsmaterial2d_icon, d_physicsmaterial2d_icon);
            _reverseIconLookup.Add(d_physicsmaterial2d_icon, Enum.d_physicsmaterial2d_icon);
            _iconLookup.Add(Enum.d_physicsmaterial2d_on_icon, d_physicsmaterial2d_on_icon);
            _reverseIconLookup.Add(d_physicsmaterial2d_on_icon, Enum.d_physicsmaterial2d_on_icon);
            _iconLookup.Add(Enum.d_platformeffector2d_icon, d_platformeffector2d_icon);
            _reverseIconLookup.Add(d_platformeffector2d_icon, Enum.d_platformeffector2d_icon);
            _iconLookup.Add(Enum.d_pointeffector2d_icon, d_pointeffector2d_icon);
            _reverseIconLookup.Add(d_pointeffector2d_icon, Enum.d_pointeffector2d_icon);
            _iconLookup.Add(Enum.d_polygoncollider2d_icon, d_polygoncollider2d_icon);
            _reverseIconLookup.Add(d_polygoncollider2d_icon, Enum.d_polygoncollider2d_icon);
            _iconLookup.Add(Enum.d_proceduralmaterial_icon, d_proceduralmaterial_icon);
            _reverseIconLookup.Add(d_proceduralmaterial_icon, Enum.d_proceduralmaterial_icon);
            _iconLookup.Add(Enum.d_projector_icon, d_projector_icon);
            _reverseIconLookup.Add(d_projector_icon, Enum.d_projector_icon);
            _iconLookup.Add(Enum.d_raytracingshader_icon, d_raytracingshader_icon);
            _reverseIconLookup.Add(d_raytracingshader_icon, Enum.d_raytracingshader_icon);
            _iconLookup.Add(Enum.d_recttransform_icon, d_recttransform_icon);
            _reverseIconLookup.Add(d_recttransform_icon, Enum.d_recttransform_icon);
            _iconLookup.Add(Enum.d_reflectionprobe_icon, d_reflectionprobe_icon);
            _reverseIconLookup.Add(d_reflectionprobe_icon, Enum.d_reflectionprobe_icon);
            _iconLookup.Add(Enum.d_relativejoint2d_icon, d_relativejoint2d_icon);
            _reverseIconLookup.Add(d_relativejoint2d_icon, Enum.d_relativejoint2d_icon);
            _iconLookup.Add(Enum.d_rendertexture_icon, d_rendertexture_icon);
            _reverseIconLookup.Add(d_rendertexture_icon, Enum.d_rendertexture_icon);
            _iconLookup.Add(Enum.d_rendertexture_on_icon, d_rendertexture_on_icon);
            _reverseIconLookup.Add(d_rendertexture_on_icon, Enum.d_rendertexture_on_icon);
            _iconLookup.Add(Enum.d_rigidbody_icon, d_rigidbody_icon);
            _reverseIconLookup.Add(d_rigidbody_icon, Enum.d_rigidbody_icon);
            _iconLookup.Add(Enum.d_rigidbody2d_icon, d_rigidbody2d_icon);
            _reverseIconLookup.Add(d_rigidbody2d_icon, Enum.d_rigidbody2d_icon);
            _iconLookup.Add(Enum.d_scriptableobject_icon, d_scriptableobject_icon);
            _reverseIconLookup.Add(d_scriptableobject_icon, Enum.d_scriptableobject_icon);
            _iconLookup.Add(Enum.d_scriptableobject_on_icon, d_scriptableobject_on_icon);
            _reverseIconLookup.Add(d_scriptableobject_on_icon, Enum.d_scriptableobject_on_icon);
            _iconLookup.Add(Enum.d_shader_icon, d_shader_icon);
            _reverseIconLookup.Add(d_shader_icon, Enum.d_shader_icon);
            _iconLookup.Add(Enum.d_shadervariantcollection_icon, d_shadervariantcollection_icon);
            _reverseIconLookup.Add(d_shadervariantcollection_icon, Enum.d_shadervariantcollection_icon);
            _iconLookup.Add(Enum.d_skinnedmeshrenderer_icon, d_skinnedmeshrenderer_icon);
            _reverseIconLookup.Add(d_skinnedmeshrenderer_icon, Enum.d_skinnedmeshrenderer_icon);
            _iconLookup.Add(Enum.d_skybox_icon, d_skybox_icon);
            _reverseIconLookup.Add(d_skybox_icon, Enum.d_skybox_icon);
            _iconLookup.Add(Enum.d_sliderjoint2d_icon, d_sliderjoint2d_icon);
            _reverseIconLookup.Add(d_sliderjoint2d_icon, Enum.d_sliderjoint2d_icon);
            _iconLookup.Add(Enum.d_spherecollider_icon, d_spherecollider_icon);
            _reverseIconLookup.Add(d_spherecollider_icon, Enum.d_spherecollider_icon);
            _iconLookup.Add(Enum.d_springjoint_icon, d_springjoint_icon);
            _reverseIconLookup.Add(d_springjoint_icon, Enum.d_springjoint_icon);
            _iconLookup.Add(Enum.d_springjoint2d_icon, d_springjoint2d_icon);
            _reverseIconLookup.Add(d_springjoint2d_icon, Enum.d_springjoint2d_icon);
            _iconLookup.Add(Enum.d_sprite_icon, d_sprite_icon);
            _reverseIconLookup.Add(d_sprite_icon, Enum.d_sprite_icon);
            _iconLookup.Add(Enum.d_spritemask_icon, d_spritemask_icon);
            _reverseIconLookup.Add(d_spritemask_icon, Enum.d_spritemask_icon);
            _iconLookup.Add(Enum.d_spriterenderer_icon, d_spriterenderer_icon);
            _reverseIconLookup.Add(d_spriterenderer_icon, Enum.d_spriterenderer_icon);
            _iconLookup.Add(Enum.d_streamingcontroller_icon, d_streamingcontroller_icon);
            _reverseIconLookup.Add(d_streamingcontroller_icon, Enum.d_streamingcontroller_icon);
            _iconLookup.Add(Enum.d_surfaceeffector2d_icon, d_surfaceeffector2d_icon);
            _reverseIconLookup.Add(d_surfaceeffector2d_icon, Enum.d_surfaceeffector2d_icon);
            _iconLookup.Add(Enum.d_targetjoint2d_icon, d_targetjoint2d_icon);
            _reverseIconLookup.Add(d_targetjoint2d_icon, Enum.d_targetjoint2d_icon);
            _iconLookup.Add(Enum.d_terrain_icon, d_terrain_icon);
            _reverseIconLookup.Add(d_terrain_icon, Enum.d_terrain_icon);
            _iconLookup.Add(Enum.d_terraincollider_icon, d_terraincollider_icon);
            _reverseIconLookup.Add(d_terraincollider_icon, Enum.d_terraincollider_icon);
            _iconLookup.Add(Enum.d_terraindata_icon, d_terraindata_icon);
            _reverseIconLookup.Add(d_terraindata_icon, Enum.d_terraindata_icon);
            _iconLookup.Add(Enum.d_textasset_icon, d_textasset_icon);
            _reverseIconLookup.Add(d_textasset_icon, Enum.d_textasset_icon);
            _iconLookup.Add(Enum.d_texture_icon, d_texture_icon);
            _reverseIconLookup.Add(d_texture_icon, Enum.d_texture_icon);
            _iconLookup.Add(Enum.d_texture2d_icon, d_texture2d_icon);
            _reverseIconLookup.Add(d_texture2d_icon, Enum.d_texture2d_icon);
            _iconLookup.Add(Enum.d_trailrenderer_icon, d_trailrenderer_icon);
            _reverseIconLookup.Add(d_trailrenderer_icon, Enum.d_trailrenderer_icon);
            _iconLookup.Add(Enum.d_transform_icon, d_transform_icon);
            _reverseIconLookup.Add(d_transform_icon, Enum.d_transform_icon);
            _iconLookup.Add(Enum.d_wheelcollider_icon, d_wheelcollider_icon);
            _reverseIconLookup.Add(d_wheelcollider_icon, Enum.d_wheelcollider_icon);
            _iconLookup.Add(Enum.d_wheeljoint2d_icon, d_wheeljoint2d_icon);
            _reverseIconLookup.Add(d_wheeljoint2d_icon, Enum.d_wheeljoint2d_icon);
            _iconLookup.Add(Enum.d_windzone_icon, d_windzone_icon);
            _reverseIconLookup.Add(d_windzone_icon, Enum.d_windzone_icon);
            _iconLookup.Add(Enum.distancejoint2d_icon, distancejoint2d_icon);
            _reverseIconLookup.Add(distancejoint2d_icon, Enum.distancejoint2d_icon);
            _iconLookup.Add(Enum.edgecollider2d_icon, edgecollider2d_icon);
            _reverseIconLookup.Add(edgecollider2d_icon, Enum.edgecollider2d_icon);
            _iconLookup.Add(Enum.d_eventsystem_icon, d_eventsystem_icon);
            _reverseIconLookup.Add(d_eventsystem_icon, Enum.d_eventsystem_icon);
            _iconLookup.Add(Enum.d_eventtrigger_icon, d_eventtrigger_icon);
            _reverseIconLookup.Add(d_eventtrigger_icon, Enum.d_eventtrigger_icon);
            _iconLookup.Add(Enum.d_hololensinputmodule_icon, d_hololensinputmodule_icon);
            _reverseIconLookup.Add(d_hololensinputmodule_icon, Enum.d_hololensinputmodule_icon);
            _iconLookup.Add(Enum.d_physics2draycaster_icon, d_physics2draycaster_icon);
            _reverseIconLookup.Add(d_physics2draycaster_icon, Enum.d_physics2draycaster_icon);
            _iconLookup.Add(Enum.d_physicsraycaster_icon, d_physicsraycaster_icon);
            _reverseIconLookup.Add(d_physicsraycaster_icon, Enum.d_physicsraycaster_icon);
            _iconLookup.Add(Enum.d_standaloneinputmodule_icon, d_standaloneinputmodule_icon);
            _reverseIconLookup.Add(d_standaloneinputmodule_icon, Enum.d_standaloneinputmodule_icon);
            _iconLookup.Add(Enum.d_touchinputmodule_icon, d_touchinputmodule_icon);
            _reverseIconLookup.Add(d_touchinputmodule_icon, Enum.d_touchinputmodule_icon);
            _iconLookup.Add(Enum.eventsystem_icon, eventsystem_icon);
            _reverseIconLookup.Add(eventsystem_icon, Enum.eventsystem_icon);
            _iconLookup.Add(Enum.eventtrigger_icon, eventtrigger_icon);
            _reverseIconLookup.Add(eventtrigger_icon, Enum.eventtrigger_icon);
            _iconLookup.Add(Enum.hololensinputmodule_icon, hololensinputmodule_icon);
            _reverseIconLookup.Add(hololensinputmodule_icon, Enum.hololensinputmodule_icon);
            _iconLookup.Add(Enum.physics2draycaster_icon, physics2draycaster_icon);
            _reverseIconLookup.Add(physics2draycaster_icon, Enum.physics2draycaster_icon);
            _iconLookup.Add(Enum.physicsraycaster_icon, physicsraycaster_icon);
            _reverseIconLookup.Add(physicsraycaster_icon, Enum.physicsraycaster_icon);
            _iconLookup.Add(Enum.standaloneinputmodule_icon, standaloneinputmodule_icon);
            _reverseIconLookup.Add(standaloneinputmodule_icon, Enum.standaloneinputmodule_icon);
            _iconLookup.Add(Enum.touchinputmodule_icon, touchinputmodule_icon);
            _reverseIconLookup.Add(touchinputmodule_icon, Enum.touchinputmodule_icon);
            _iconLookup.Add(Enum.raytracingshader_icon, raytracingshader_icon);
            _reverseIconLookup.Add(raytracingshader_icon, Enum.raytracingshader_icon);
            _iconLookup.Add(Enum.fixedjoint_icon, fixedjoint_icon);
            _reverseIconLookup.Add(fixedjoint_icon, Enum.fixedjoint_icon);
            _iconLookup.Add(Enum.fixedjoint2d_icon, fixedjoint2d_icon);
            _reverseIconLookup.Add(fixedjoint2d_icon, Enum.fixedjoint2d_icon);
            _iconLookup.Add(Enum.flare_icon, flare_icon);
            _reverseIconLookup.Add(flare_icon, Enum.flare_icon);
            _iconLookup.Add(Enum.flare_on_icon, flare_on_icon);
            _reverseIconLookup.Add(flare_on_icon, Enum.flare_on_icon);
            _iconLookup.Add(Enum.flarelayer_icon, flarelayer_icon);
            _reverseIconLookup.Add(flarelayer_icon, Enum.flarelayer_icon);
            _iconLookup.Add(Enum.font_icon, font_icon);
            _reverseIconLookup.Add(font_icon, Enum.font_icon);
            _iconLookup.Add(Enum.font_on_icon, font_on_icon);
            _reverseIconLookup.Add(font_on_icon, Enum.font_on_icon);
            _iconLookup.Add(Enum.frictionjoint2d_icon, frictionjoint2d_icon);
            _reverseIconLookup.Add(frictionjoint2d_icon, Enum.frictionjoint2d_icon);
            _iconLookup.Add(Enum.gameobject_icon, gameobject_icon);
            _reverseIconLookup.Add(gameobject_icon, Enum.gameobject_icon);
            _iconLookup.Add(Enum.gameobject_on_icon, gameobject_on_icon);
            _reverseIconLookup.Add(gameobject_on_icon, Enum.gameobject_on_icon);
            _iconLookup.Add(Enum.grid_icon, grid_icon);
            _reverseIconLookup.Add(grid_icon, Enum.grid_icon);
            _iconLookup.Add(Enum.guilayer_icon, guilayer_icon);
            _reverseIconLookup.Add(guilayer_icon, Enum.guilayer_icon);
            _iconLookup.Add(Enum.guiskin_icon, guiskin_icon);
            _reverseIconLookup.Add(guiskin_icon, Enum.guiskin_icon);
            _iconLookup.Add(Enum.guiskin_on_icon, guiskin_on_icon);
            _reverseIconLookup.Add(guiskin_on_icon, Enum.guiskin_on_icon);
            _iconLookup.Add(Enum.guitext_icon, guitext_icon);
            _reverseIconLookup.Add(guitext_icon, Enum.guitext_icon);
            _iconLookup.Add(Enum.guitexture_icon, guitexture_icon);
            _reverseIconLookup.Add(guitexture_icon, Enum.guitexture_icon);
            _iconLookup.Add(Enum.halo_icon, halo_icon);
            _reverseIconLookup.Add(halo_icon, Enum.halo_icon);
            _iconLookup.Add(Enum.hingejoint_icon, hingejoint_icon);
            _reverseIconLookup.Add(hingejoint_icon, Enum.hingejoint_icon);
            _iconLookup.Add(Enum.hingejoint2d_icon, hingejoint2d_icon);
            _reverseIconLookup.Add(hingejoint2d_icon, Enum.hingejoint2d_icon);
            _iconLookup.Add(Enum.lensflare_icon, lensflare_icon);
            _reverseIconLookup.Add(lensflare_icon, Enum.lensflare_icon);
            _iconLookup.Add(Enum.light_icon, light_icon);
            _reverseIconLookup.Add(light_icon, Enum.light_icon);
            _iconLookup.Add(Enum.lightingsettings_icon, lightingsettings_icon);
            _reverseIconLookup.Add(lightingsettings_icon, Enum.lightingsettings_icon);
            _iconLookup.Add(Enum.lightprobegroup_icon, lightprobegroup_icon);
            _reverseIconLookup.Add(lightprobegroup_icon, Enum.lightprobegroup_icon);
            _iconLookup.Add(Enum.lightprobeproxyvolume_icon, lightprobeproxyvolume_icon);
            _reverseIconLookup.Add(lightprobeproxyvolume_icon, Enum.lightprobeproxyvolume_icon);
            _iconLookup.Add(Enum.lightprobes_icon, lightprobes_icon);
            _reverseIconLookup.Add(lightprobes_icon, Enum.lightprobes_icon);
            _iconLookup.Add(Enum.linerenderer_icon, linerenderer_icon);
            _reverseIconLookup.Add(linerenderer_icon, Enum.linerenderer_icon);
            _iconLookup.Add(Enum.lodgroup_icon, lodgroup_icon);
            _reverseIconLookup.Add(lodgroup_icon, Enum.lodgroup_icon);
            _iconLookup.Add(Enum.material_icon, material_icon);
            _reverseIconLookup.Add(material_icon, Enum.material_icon);
            _iconLookup.Add(Enum.material_on_icon, material_on_icon);
            _reverseIconLookup.Add(material_on_icon, Enum.material_on_icon);
            _iconLookup.Add(Enum.mesh_icon, mesh_icon);
            _reverseIconLookup.Add(mesh_icon, Enum.mesh_icon);
            _iconLookup.Add(Enum.meshcollider_icon, meshcollider_icon);
            _reverseIconLookup.Add(meshcollider_icon, Enum.meshcollider_icon);
            _iconLookup.Add(Enum.meshfilter_icon, meshfilter_icon);
            _reverseIconLookup.Add(meshfilter_icon, Enum.meshfilter_icon);
            _iconLookup.Add(Enum.meshrenderer_icon, meshrenderer_icon);
            _reverseIconLookup.Add(meshrenderer_icon, Enum.meshrenderer_icon);
            _iconLookup.Add(Enum.motion_icon, motion_icon);
            _reverseIconLookup.Add(motion_icon, Enum.motion_icon);
            _iconLookup.Add(Enum.movietexture_icon, movietexture_icon);
            _reverseIconLookup.Add(movietexture_icon, Enum.movietexture_icon);
            _iconLookup.Add(Enum.d_networkanimator_icon, d_networkanimator_icon);
            _reverseIconLookup.Add(d_networkanimator_icon, Enum.d_networkanimator_icon);
            _iconLookup.Add(Enum.d_networkdiscovery_icon, d_networkdiscovery_icon);
            _reverseIconLookup.Add(d_networkdiscovery_icon, Enum.d_networkdiscovery_icon);
            _iconLookup.Add(Enum.d_networkidentity_icon, d_networkidentity_icon);
            _reverseIconLookup.Add(d_networkidentity_icon, Enum.d_networkidentity_icon);
            _iconLookup.Add(Enum.d_networklobbymanager_icon, d_networklobbymanager_icon);
            _reverseIconLookup.Add(d_networklobbymanager_icon, Enum.d_networklobbymanager_icon);
            _iconLookup.Add(Enum.d_networklobbyplayer_icon, d_networklobbyplayer_icon);
            _reverseIconLookup.Add(d_networklobbyplayer_icon, Enum.d_networklobbyplayer_icon);
            _iconLookup.Add(Enum.d_networkmanager_icon, d_networkmanager_icon);
            _reverseIconLookup.Add(d_networkmanager_icon, Enum.d_networkmanager_icon);
            _iconLookup.Add(Enum.d_networkmanagerhud_icon, d_networkmanagerhud_icon);
            _reverseIconLookup.Add(d_networkmanagerhud_icon, Enum.d_networkmanagerhud_icon);
            _iconLookup.Add(Enum.d_networkmigrationmanager_icon, d_networkmigrationmanager_icon);
            _reverseIconLookup.Add(d_networkmigrationmanager_icon, Enum.d_networkmigrationmanager_icon);
            _iconLookup.Add(Enum.d_networkproximitychecker_icon, d_networkproximitychecker_icon);
            _reverseIconLookup.Add(d_networkproximitychecker_icon, Enum.d_networkproximitychecker_icon);
            _iconLookup.Add(Enum.d_networkstartposition_icon, d_networkstartposition_icon);
            _reverseIconLookup.Add(d_networkstartposition_icon, Enum.d_networkstartposition_icon);
            _iconLookup.Add(Enum.d_networktransform_icon, d_networktransform_icon);
            _reverseIconLookup.Add(d_networktransform_icon, Enum.d_networktransform_icon);
            _iconLookup.Add(Enum.d_networktransformchild_icon, d_networktransformchild_icon);
            _reverseIconLookup.Add(d_networktransformchild_icon, Enum.d_networktransformchild_icon);
            _iconLookup.Add(Enum.d_networktransformvisualizer_icon, d_networktransformvisualizer_icon);
            _reverseIconLookup.Add(d_networktransformvisualizer_icon, Enum.d_networktransformvisualizer_icon);
            _iconLookup.Add(Enum.networkanimator_icon, networkanimator_icon);
            _reverseIconLookup.Add(networkanimator_icon, Enum.networkanimator_icon);
            _iconLookup.Add(Enum.networkdiscovery_icon, networkdiscovery_icon);
            _reverseIconLookup.Add(networkdiscovery_icon, Enum.networkdiscovery_icon);
            _iconLookup.Add(Enum.networkidentity_icon, networkidentity_icon);
            _reverseIconLookup.Add(networkidentity_icon, Enum.networkidentity_icon);
            _iconLookup.Add(Enum.networklobbymanager_icon, networklobbymanager_icon);
            _reverseIconLookup.Add(networklobbymanager_icon, Enum.networklobbymanager_icon);
            _iconLookup.Add(Enum.networklobbyplayer_icon, networklobbyplayer_icon);
            _reverseIconLookup.Add(networklobbyplayer_icon, Enum.networklobbyplayer_icon);
            _iconLookup.Add(Enum.networkmanager_icon, networkmanager_icon);
            _reverseIconLookup.Add(networkmanager_icon, Enum.networkmanager_icon);
            _iconLookup.Add(Enum.networkmanagerhud_icon, networkmanagerhud_icon);
            _reverseIconLookup.Add(networkmanagerhud_icon, Enum.networkmanagerhud_icon);
            _iconLookup.Add(Enum.networkmigrationmanager_icon, networkmigrationmanager_icon);
            _reverseIconLookup.Add(networkmigrationmanager_icon, Enum.networkmigrationmanager_icon);
            _iconLookup.Add(Enum.networkproximitychecker_icon, networkproximitychecker_icon);
            _reverseIconLookup.Add(networkproximitychecker_icon, Enum.networkproximitychecker_icon);
            _iconLookup.Add(Enum.networkstartposition_icon, networkstartposition_icon);
            _reverseIconLookup.Add(networkstartposition_icon, Enum.networkstartposition_icon);
            _iconLookup.Add(Enum.networktransform_icon, networktransform_icon);
            _reverseIconLookup.Add(networktransform_icon, Enum.networktransform_icon);
            _iconLookup.Add(Enum.networktransformchild_icon, networktransformchild_icon);
            _reverseIconLookup.Add(networktransformchild_icon, Enum.networktransformchild_icon);
            _iconLookup.Add(Enum.networktransformvisualizer_icon, networktransformvisualizer_icon);
            _reverseIconLookup.Add(networktransformvisualizer_icon, Enum.networktransformvisualizer_icon);
            _iconLookup.Add(Enum.networkview_icon, networkview_icon);
            _reverseIconLookup.Add(networkview_icon, Enum.networkview_icon);
            _iconLookup.Add(Enum.occlusionarea_icon, occlusionarea_icon);
            _reverseIconLookup.Add(occlusionarea_icon, Enum.occlusionarea_icon);
            _iconLookup.Add(Enum.occlusionportal_icon, occlusionportal_icon);
            _reverseIconLookup.Add(occlusionportal_icon, Enum.occlusionportal_icon);
            _iconLookup.Add(Enum.particlesystem_icon, particlesystem_icon);
            _reverseIconLookup.Add(particlesystem_icon, Enum.particlesystem_icon);
            _iconLookup.Add(Enum.particlesystemforcefield_icon, particlesystemforcefield_icon);
            _reverseIconLookup.Add(particlesystemforcefield_icon, Enum.particlesystemforcefield_icon);
            _iconLookup.Add(Enum.physicmaterial_icon, physicmaterial_icon);
            _reverseIconLookup.Add(physicmaterial_icon, Enum.physicmaterial_icon);
            _iconLookup.Add(Enum.physicmaterial_on_icon, physicmaterial_on_icon);
            _reverseIconLookup.Add(physicmaterial_on_icon, Enum.physicmaterial_on_icon);
            _iconLookup.Add(Enum.physicsmaterial2d_icon, physicsmaterial2d_icon);
            _reverseIconLookup.Add(physicsmaterial2d_icon, Enum.physicsmaterial2d_icon);
            _iconLookup.Add(Enum.physicsmaterial2d_on_icon, physicsmaterial2d_on_icon);
            _reverseIconLookup.Add(physicsmaterial2d_on_icon, Enum.physicsmaterial2d_on_icon);
            _iconLookup.Add(Enum.platformeffector2d_icon, platformeffector2d_icon);
            _reverseIconLookup.Add(platformeffector2d_icon, Enum.platformeffector2d_icon);
            _iconLookup.Add(Enum.d_playabledirector_icon, d_playabledirector_icon);
            _reverseIconLookup.Add(d_playabledirector_icon, Enum.d_playabledirector_icon);
            _iconLookup.Add(Enum.playabledirector_icon, playabledirector_icon);
            _reverseIconLookup.Add(playabledirector_icon, Enum.playabledirector_icon);
            _iconLookup.Add(Enum.pointeffector2d_icon, pointeffector2d_icon);
            _reverseIconLookup.Add(pointeffector2d_icon, Enum.pointeffector2d_icon);
            _iconLookup.Add(Enum.polygoncollider2d_icon, polygoncollider2d_icon);
            _reverseIconLookup.Add(polygoncollider2d_icon, Enum.polygoncollider2d_icon);
            _iconLookup.Add(Enum.proceduralmaterial_icon, proceduralmaterial_icon);
            _reverseIconLookup.Add(proceduralmaterial_icon, Enum.proceduralmaterial_icon);
            _iconLookup.Add(Enum.projector_icon, projector_icon);
            _reverseIconLookup.Add(projector_icon, Enum.projector_icon);
            _iconLookup.Add(Enum.recttransform_icon, recttransform_icon);
            _reverseIconLookup.Add(recttransform_icon, Enum.recttransform_icon);
            _iconLookup.Add(Enum.reflectionprobe_icon, reflectionprobe_icon);
            _reverseIconLookup.Add(reflectionprobe_icon, Enum.reflectionprobe_icon);
            _iconLookup.Add(Enum.relativejoint2d_icon, relativejoint2d_icon);
            _reverseIconLookup.Add(relativejoint2d_icon, Enum.relativejoint2d_icon);
            _iconLookup.Add(Enum.d_sortinggroup_icon, d_sortinggroup_icon);
            _reverseIconLookup.Add(d_sortinggroup_icon, Enum.d_sortinggroup_icon);
            _iconLookup.Add(Enum.sortinggroup_icon, sortinggroup_icon);
            _reverseIconLookup.Add(sortinggroup_icon, Enum.sortinggroup_icon);
            _iconLookup.Add(Enum.rendertexture_icon, rendertexture_icon);
            _reverseIconLookup.Add(rendertexture_icon, Enum.rendertexture_icon);
            _iconLookup.Add(Enum.rendertexture_on_icon, rendertexture_on_icon);
            _reverseIconLookup.Add(rendertexture_on_icon, Enum.rendertexture_on_icon);
            _iconLookup.Add(Enum.rigidbody_icon, rigidbody_icon);
            _reverseIconLookup.Add(rigidbody_icon, Enum.rigidbody_icon);
            _iconLookup.Add(Enum.rigidbody2d_icon, rigidbody2d_icon);
            _reverseIconLookup.Add(rigidbody2d_icon, Enum.rigidbody2d_icon);
            _iconLookup.Add(Enum.scriptableobject_icon, scriptableobject_icon);
            _reverseIconLookup.Add(scriptableobject_icon, Enum.scriptableobject_icon);
            _iconLookup.Add(Enum.scriptableobject_on_icon, scriptableobject_on_icon);
            _reverseIconLookup.Add(scriptableobject_on_icon, Enum.scriptableobject_on_icon);
            _iconLookup.Add(Enum.shader_icon, shader_icon);
            _reverseIconLookup.Add(shader_icon, Enum.shader_icon);
            _iconLookup.Add(Enum.shadervariantcollection_icon, shadervariantcollection_icon);
            _reverseIconLookup.Add(shadervariantcollection_icon, Enum.shadervariantcollection_icon);
            _iconLookup.Add(Enum.skinnedmeshrenderer_icon, skinnedmeshrenderer_icon);
            _reverseIconLookup.Add(skinnedmeshrenderer_icon, Enum.skinnedmeshrenderer_icon);
            _iconLookup.Add(Enum.skybox_icon, skybox_icon);
            _reverseIconLookup.Add(skybox_icon, Enum.skybox_icon);
            _iconLookup.Add(Enum.sliderjoint2d_icon, sliderjoint2d_icon);
            _reverseIconLookup.Add(sliderjoint2d_icon, Enum.sliderjoint2d_icon);
            _iconLookup.Add(Enum.trackedposedriver_icon, trackedposedriver_icon);
            _reverseIconLookup.Add(trackedposedriver_icon, Enum.trackedposedriver_icon);
            _iconLookup.Add(Enum.spherecollider_icon, spherecollider_icon);
            _reverseIconLookup.Add(spherecollider_icon, Enum.spherecollider_icon);
            _iconLookup.Add(Enum.springjoint_icon, springjoint_icon);
            _reverseIconLookup.Add(springjoint_icon, Enum.springjoint_icon);
            _iconLookup.Add(Enum.springjoint2d_icon, springjoint2d_icon);
            _reverseIconLookup.Add(springjoint2d_icon, Enum.springjoint2d_icon);
            _iconLookup.Add(Enum.sprite_icon, sprite_icon);
            _reverseIconLookup.Add(sprite_icon, Enum.sprite_icon);
            _iconLookup.Add(Enum.spritemask_icon, spritemask_icon);
            _reverseIconLookup.Add(spritemask_icon, Enum.spritemask_icon);
            _iconLookup.Add(Enum.spriterenderer_icon, spriterenderer_icon);
            _reverseIconLookup.Add(spriterenderer_icon, Enum.spriterenderer_icon);
            _iconLookup.Add(Enum.streamingcontroller_icon, streamingcontroller_icon);
            _reverseIconLookup.Add(streamingcontroller_icon, Enum.streamingcontroller_icon);
            _iconLookup.Add(Enum.surfaceeffector2d_icon, surfaceeffector2d_icon);
            _reverseIconLookup.Add(surfaceeffector2d_icon, Enum.surfaceeffector2d_icon);
            _iconLookup.Add(Enum.targetjoint2d_icon, targetjoint2d_icon);
            _reverseIconLookup.Add(targetjoint2d_icon, Enum.targetjoint2d_icon);
            _iconLookup.Add(Enum.terrain_icon, terrain_icon);
            _reverseIconLookup.Add(terrain_icon, Enum.terrain_icon);
            _iconLookup.Add(Enum.terraincollider_icon, terraincollider_icon);
            _reverseIconLookup.Add(terraincollider_icon, Enum.terraincollider_icon);
            _iconLookup.Add(Enum.terraindata_icon, terraindata_icon);
            _reverseIconLookup.Add(terraindata_icon, Enum.terraindata_icon);
            _iconLookup.Add(Enum.textasset_icon, textasset_icon);
            _reverseIconLookup.Add(textasset_icon, Enum.textasset_icon);
            _iconLookup.Add(Enum.textmesh_icon, textmesh_icon);
            _reverseIconLookup.Add(textmesh_icon, Enum.textmesh_icon);
            _iconLookup.Add(Enum.texture_icon, texture_icon);
            _reverseIconLookup.Add(texture_icon, Enum.texture_icon);
            _iconLookup.Add(Enum.texture2d_icon, texture2d_icon);
            _reverseIconLookup.Add(texture2d_icon, Enum.texture2d_icon);
            _iconLookup.Add(Enum.d_tile_icon, d_tile_icon);
            _reverseIconLookup.Add(d_tile_icon, Enum.d_tile_icon);
            _iconLookup.Add(Enum.d_tilemap_icon, d_tilemap_icon);
            _reverseIconLookup.Add(d_tilemap_icon, Enum.d_tilemap_icon);
            _iconLookup.Add(Enum.d_tilemapcollider2d_icon, d_tilemapcollider2d_icon);
            _reverseIconLookup.Add(d_tilemapcollider2d_icon, Enum.d_tilemapcollider2d_icon);
            _iconLookup.Add(Enum.d_tilemaprenderer_icon, d_tilemaprenderer_icon);
            _reverseIconLookup.Add(d_tilemaprenderer_icon, Enum.d_tilemaprenderer_icon);
            _iconLookup.Add(Enum.tile_icon, tile_icon);
            _reverseIconLookup.Add(tile_icon, Enum.tile_icon);
            _iconLookup.Add(Enum.tilemap_icon, tilemap_icon);
            _reverseIconLookup.Add(tilemap_icon, Enum.tilemap_icon);
            _iconLookup.Add(Enum.tilemapcollider2d_icon, tilemapcollider2d_icon);
            _reverseIconLookup.Add(tilemapcollider2d_icon, Enum.tilemapcollider2d_icon);
            _iconLookup.Add(Enum.tilemaprenderer_icon, tilemaprenderer_icon);
            _reverseIconLookup.Add(tilemaprenderer_icon, Enum.tilemaprenderer_icon);
            _iconLookup.Add(Enum.d_signalasset_icon, d_signalasset_icon);
            _reverseIconLookup.Add(d_signalasset_icon, Enum.d_signalasset_icon);
            _iconLookup.Add(Enum.d_signalemitter_icon, d_signalemitter_icon);
            _reverseIconLookup.Add(d_signalemitter_icon, Enum.d_signalemitter_icon);
            _iconLookup.Add(Enum.d_signalreceiver_icon, d_signalreceiver_icon);
            _reverseIconLookup.Add(d_signalreceiver_icon, Enum.d_signalreceiver_icon);
            _iconLookup.Add(Enum.d_timelineasset_icon, d_timelineasset_icon);
            _reverseIconLookup.Add(d_timelineasset_icon, Enum.d_timelineasset_icon);
            _iconLookup.Add(Enum.d_timelineasset_on_icon, d_timelineasset_on_icon);
            _reverseIconLookup.Add(d_timelineasset_on_icon, Enum.d_timelineasset_on_icon);
            _iconLookup.Add(Enum.signalasset_icon, signalasset_icon);
            _reverseIconLookup.Add(signalasset_icon, Enum.signalasset_icon);
            _iconLookup.Add(Enum.signalemitter_icon, signalemitter_icon);
            _reverseIconLookup.Add(signalemitter_icon, Enum.signalemitter_icon);
            _iconLookup.Add(Enum.signalreceiver_icon, signalreceiver_icon);
            _reverseIconLookup.Add(signalreceiver_icon, Enum.signalreceiver_icon);
            _iconLookup.Add(Enum.timelineasset_icon, timelineasset_icon);
            _reverseIconLookup.Add(timelineasset_icon, Enum.timelineasset_icon);
            _iconLookup.Add(Enum.timelineasset_on_icon, timelineasset_on_icon);
            _reverseIconLookup.Add(timelineasset_on_icon, Enum.timelineasset_on_icon);
            _iconLookup.Add(Enum.trailrenderer_icon, trailrenderer_icon);
            _reverseIconLookup.Add(trailrenderer_icon, Enum.trailrenderer_icon);
            _iconLookup.Add(Enum.transform_icon, transform_icon);
            _reverseIconLookup.Add(transform_icon, Enum.transform_icon);
            _iconLookup.Add(Enum.tree_icon, tree_icon);
            _reverseIconLookup.Add(tree_icon, Enum.tree_icon);
            _iconLookup.Add(Enum.d_spriteatlas_icon, d_spriteatlas_icon);
            _reverseIconLookup.Add(d_spriteatlas_icon, Enum.d_spriteatlas_icon);
            _iconLookup.Add(Enum.d_spriteatlas_on_icon, d_spriteatlas_on_icon);
            _reverseIconLookup.Add(d_spriteatlas_on_icon, Enum.d_spriteatlas_on_icon);
            _iconLookup.Add(Enum.d_spriteshaperenderer_icon, d_spriteshaperenderer_icon);
            _reverseIconLookup.Add(d_spriteshaperenderer_icon, Enum.d_spriteshaperenderer_icon);
            _iconLookup.Add(Enum.spriteatlas_icon, spriteatlas_icon);
            _reverseIconLookup.Add(spriteatlas_icon, Enum.spriteatlas_icon);
            _iconLookup.Add(Enum.spriteatlas_on_icon, spriteatlas_on_icon);
            _reverseIconLookup.Add(spriteatlas_on_icon, Enum.spriteatlas_on_icon);
            _iconLookup.Add(Enum.spriteshaperenderer_icon, spriteshaperenderer_icon);
            _reverseIconLookup.Add(spriteshaperenderer_icon, Enum.spriteshaperenderer_icon);
            _iconLookup.Add(Enum.aspectratiofitter_icon, aspectratiofitter_icon);
            _reverseIconLookup.Add(aspectratiofitter_icon, Enum.aspectratiofitter_icon);
            _iconLookup.Add(Enum.button_icon, button_icon);
            _reverseIconLookup.Add(button_icon, Enum.button_icon);
            _iconLookup.Add(Enum.canvasscaler_icon, canvasscaler_icon);
            _reverseIconLookup.Add(canvasscaler_icon, Enum.canvasscaler_icon);
            _iconLookup.Add(Enum.contentsizefitter_icon, contentsizefitter_icon);
            _reverseIconLookup.Add(contentsizefitter_icon, Enum.contentsizefitter_icon);
            _iconLookup.Add(Enum.d_aspectratiofitter_icon, d_aspectratiofitter_icon);
            _reverseIconLookup.Add(d_aspectratiofitter_icon, Enum.d_aspectratiofitter_icon);
            _iconLookup.Add(Enum.d_button_icon, d_button_icon);
            _reverseIconLookup.Add(d_button_icon, Enum.d_button_icon);
            _iconLookup.Add(Enum.d_canvasscaler_icon, d_canvasscaler_icon);
            _reverseIconLookup.Add(d_canvasscaler_icon, Enum.d_canvasscaler_icon);
            _iconLookup.Add(Enum.d_contentsizefitter_icon, d_contentsizefitter_icon);
            _reverseIconLookup.Add(d_contentsizefitter_icon, Enum.d_contentsizefitter_icon);
            _iconLookup.Add(Enum.d_dropdown_icon, d_dropdown_icon);
            _reverseIconLookup.Add(d_dropdown_icon, Enum.d_dropdown_icon);
            _iconLookup.Add(Enum.d_freeformlayoutgroup_icon, d_freeformlayoutgroup_icon);
            _reverseIconLookup.Add(d_freeformlayoutgroup_icon, Enum.d_freeformlayoutgroup_icon);
            _iconLookup.Add(Enum.d_graphicraycaster_icon, d_graphicraycaster_icon);
            _reverseIconLookup.Add(d_graphicraycaster_icon, Enum.d_graphicraycaster_icon);
            _iconLookup.Add(Enum.d_image_icon, d_image_icon);
            _reverseIconLookup.Add(d_image_icon, Enum.d_image_icon);
            _iconLookup.Add(Enum.d_inputfield_icon, d_inputfield_icon);
            _reverseIconLookup.Add(d_inputfield_icon, Enum.d_inputfield_icon);
            _iconLookup.Add(Enum.d_layoutelement_icon, d_layoutelement_icon);
            _reverseIconLookup.Add(d_layoutelement_icon, Enum.d_layoutelement_icon);
            _iconLookup.Add(Enum.d_mask_icon, d_mask_icon);
            _reverseIconLookup.Add(d_mask_icon, Enum.d_mask_icon);
            _iconLookup.Add(Enum.d_outline_icon, d_outline_icon);
            _reverseIconLookup.Add(d_outline_icon, Enum.d_outline_icon);
            _iconLookup.Add(Enum.d_physicalresolution_icon, d_physicalresolution_icon);
            _reverseIconLookup.Add(d_physicalresolution_icon, Enum.d_physicalresolution_icon);
            _iconLookup.Add(Enum.d_positionasuv1_icon, d_positionasuv1_icon);
            _reverseIconLookup.Add(d_positionasuv1_icon, Enum.d_positionasuv1_icon);
            _iconLookup.Add(Enum.d_rawimage_icon, d_rawimage_icon);
            _reverseIconLookup.Add(d_rawimage_icon, Enum.d_rawimage_icon);
            _iconLookup.Add(Enum.d_rectmask2d_icon, d_rectmask2d_icon);
            _reverseIconLookup.Add(d_rectmask2d_icon, Enum.d_rectmask2d_icon);
            _iconLookup.Add(Enum.d_scrollbar_icon, d_scrollbar_icon);
            _reverseIconLookup.Add(d_scrollbar_icon, Enum.d_scrollbar_icon);
            _iconLookup.Add(Enum.d_scrollrect_icon, d_scrollrect_icon);
            _reverseIconLookup.Add(d_scrollrect_icon, Enum.d_scrollrect_icon);
            _iconLookup.Add(Enum.d_scrollviewarea_icon, d_scrollviewarea_icon);
            _reverseIconLookup.Add(d_scrollviewarea_icon, Enum.d_scrollviewarea_icon);
            _iconLookup.Add(Enum.d_selectable_icon, d_selectable_icon);
            _reverseIconLookup.Add(d_selectable_icon, Enum.d_selectable_icon);
            _iconLookup.Add(Enum.d_selectionlist_icon, d_selectionlist_icon);
            _reverseIconLookup.Add(d_selectionlist_icon, Enum.d_selectionlist_icon);
            _iconLookup.Add(Enum.d_selectionlistitem_icon, d_selectionlistitem_icon);
            _reverseIconLookup.Add(d_selectionlistitem_icon, Enum.d_selectionlistitem_icon);
            _iconLookup.Add(Enum.d_selectionlisttemplate_icon, d_selectionlisttemplate_icon);
            _reverseIconLookup.Add(d_selectionlisttemplate_icon, Enum.d_selectionlisttemplate_icon);
            _iconLookup.Add(Enum.d_shadow_icon, d_shadow_icon);
            _reverseIconLookup.Add(d_shadow_icon, Enum.d_shadow_icon);
            _iconLookup.Add(Enum.d_slider_icon, d_slider_icon);
            _reverseIconLookup.Add(d_slider_icon, Enum.d_slider_icon);
            _iconLookup.Add(Enum.d_text_icon, d_text_icon);
            _reverseIconLookup.Add(d_text_icon, Enum.d_text_icon);
            _iconLookup.Add(Enum.d_toggle_icon, d_toggle_icon);
            _reverseIconLookup.Add(d_toggle_icon, Enum.d_toggle_icon);
            _iconLookup.Add(Enum.d_togglegroup_icon, d_togglegroup_icon);
            _reverseIconLookup.Add(d_togglegroup_icon, Enum.d_togglegroup_icon);
            _iconLookup.Add(Enum.dropdown_icon, dropdown_icon);
            _reverseIconLookup.Add(dropdown_icon, Enum.dropdown_icon);
            _iconLookup.Add(Enum.freeformlayoutgroup_icon, freeformlayoutgroup_icon);
            _reverseIconLookup.Add(freeformlayoutgroup_icon, Enum.freeformlayoutgroup_icon);
            _iconLookup.Add(Enum.graphicraycaster_icon, graphicraycaster_icon);
            _reverseIconLookup.Add(graphicraycaster_icon, Enum.graphicraycaster_icon);
            _iconLookup.Add(Enum.gridlayoutgroup_icon, gridlayoutgroup_icon);
            _reverseIconLookup.Add(gridlayoutgroup_icon, Enum.gridlayoutgroup_icon);
            _iconLookup.Add(Enum.image_icon, image_icon);
            _reverseIconLookup.Add(image_icon, Enum.image_icon);
            _iconLookup.Add(Enum.inputfield_icon, inputfield_icon);
            _reverseIconLookup.Add(inputfield_icon, Enum.inputfield_icon);
            _iconLookup.Add(Enum.layoutelement_icon, layoutelement_icon);
            _reverseIconLookup.Add(layoutelement_icon, Enum.layoutelement_icon);
            _iconLookup.Add(Enum.mask_icon, mask_icon);
            _reverseIconLookup.Add(mask_icon, Enum.mask_icon);
            _iconLookup.Add(Enum.outline_icon, outline_icon);
            _reverseIconLookup.Add(outline_icon, Enum.outline_icon);
            _iconLookup.Add(Enum.positionasuv1_icon, positionasuv1_icon);
            _reverseIconLookup.Add(positionasuv1_icon, Enum.positionasuv1_icon);
            _iconLookup.Add(Enum.rawimage_icon, rawimage_icon);
            _reverseIconLookup.Add(rawimage_icon, Enum.rawimage_icon);
            _iconLookup.Add(Enum.rectmask2d_icon, rectmask2d_icon);
            _reverseIconLookup.Add(rectmask2d_icon, Enum.rectmask2d_icon);
            _iconLookup.Add(Enum.scrollbar_icon, scrollbar_icon);
            _reverseIconLookup.Add(scrollbar_icon, Enum.scrollbar_icon);
            _iconLookup.Add(Enum.scrollrect_icon, scrollrect_icon);
            _reverseIconLookup.Add(scrollrect_icon, Enum.scrollrect_icon);
            _iconLookup.Add(Enum.selectable_icon, selectable_icon);
            _reverseIconLookup.Add(selectable_icon, Enum.selectable_icon);
            _iconLookup.Add(Enum.shadow_icon, shadow_icon);
            _reverseIconLookup.Add(shadow_icon, Enum.shadow_icon);
            _iconLookup.Add(Enum.slider_icon, slider_icon);
            _reverseIconLookup.Add(slider_icon, Enum.slider_icon);
            _iconLookup.Add(Enum.text_icon, text_icon);
            _reverseIconLookup.Add(text_icon, Enum.text_icon);
            _iconLookup.Add(Enum.toggle_icon, toggle_icon);
            _reverseIconLookup.Add(toggle_icon, Enum.toggle_icon);
            _iconLookup.Add(Enum.togglegroup_icon, togglegroup_icon);
            _reverseIconLookup.Add(togglegroup_icon, Enum.togglegroup_icon);
            _iconLookup.Add(Enum.verticallayoutgroup_icon, verticallayoutgroup_icon);
            _reverseIconLookup.Add(verticallayoutgroup_icon, Enum.verticallayoutgroup_icon);
            _iconLookup.Add(Enum.d_panelsettings_icon, d_panelsettings_icon);
            _reverseIconLookup.Add(d_panelsettings_icon, Enum.d_panelsettings_icon);
            _iconLookup.Add(Enum.d_panelsettings_on_icon, d_panelsettings_on_icon);
            _reverseIconLookup.Add(d_panelsettings_on_icon, Enum.d_panelsettings_on_icon);
            _iconLookup.Add(Enum.d_stylesheet_icon, d_stylesheet_icon);
            _reverseIconLookup.Add(d_stylesheet_icon, Enum.d_stylesheet_icon);
            _iconLookup.Add(Enum.d_uidocument_icon, d_uidocument_icon);
            _reverseIconLookup.Add(d_uidocument_icon, Enum.d_uidocument_icon);
            _iconLookup.Add(Enum.d_visualtreeasset_icon, d_visualtreeasset_icon);
            _reverseIconLookup.Add(d_visualtreeasset_icon, Enum.d_visualtreeasset_icon);
            _iconLookup.Add(Enum.panelsettings_icon, panelsettings_icon);
            _reverseIconLookup.Add(panelsettings_icon, Enum.panelsettings_icon);
            _iconLookup.Add(Enum.panelsettings_on_icon, panelsettings_on_icon);
            _reverseIconLookup.Add(panelsettings_on_icon, Enum.panelsettings_on_icon);
            _iconLookup.Add(Enum.stylesheet_icon, stylesheet_icon);
            _reverseIconLookup.Add(stylesheet_icon, Enum.stylesheet_icon);
            _iconLookup.Add(Enum.uidocument_icon, uidocument_icon);
            _reverseIconLookup.Add(uidocument_icon, Enum.uidocument_icon);
            _iconLookup.Add(Enum.visualtreeasset_icon, visualtreeasset_icon);
            _reverseIconLookup.Add(visualtreeasset_icon, Enum.visualtreeasset_icon);
            _iconLookup.Add(Enum.d_visualeffect_icon, d_visualeffect_icon);
            _reverseIconLookup.Add(d_visualeffect_icon, Enum.d_visualeffect_icon);
            _iconLookup.Add(Enum.d_visualeffectasset_icon, d_visualeffectasset_icon);
            _reverseIconLookup.Add(d_visualeffectasset_icon, Enum.d_visualeffectasset_icon);
            _iconLookup.Add(Enum.visualeffect_icon, visualeffect_icon);
            _reverseIconLookup.Add(visualeffect_icon, Enum.visualeffect_icon);
            _iconLookup.Add(Enum.visualeffectasset_icon, visualeffectasset_icon);
            _reverseIconLookup.Add(visualeffectasset_icon, Enum.visualeffectasset_icon);
            _iconLookup.Add(Enum.d_videoplayer_icon, d_videoplayer_icon);
            _reverseIconLookup.Add(d_videoplayer_icon, Enum.d_videoplayer_icon);
            _iconLookup.Add(Enum.videoclip_icon, videoclip_icon);
            _reverseIconLookup.Add(videoclip_icon, Enum.videoclip_icon);
            _iconLookup.Add(Enum.videoplayer_icon, videoplayer_icon);
            _reverseIconLookup.Add(videoplayer_icon, Enum.videoplayer_icon);
            _iconLookup.Add(Enum.wheelcollider_icon, wheelcollider_icon);
            _reverseIconLookup.Add(wheelcollider_icon, Enum.wheelcollider_icon);
            _iconLookup.Add(Enum.wheeljoint2d_icon, wheeljoint2d_icon);
            _reverseIconLookup.Add(wheeljoint2d_icon, Enum.wheeljoint2d_icon);
            _iconLookup.Add(Enum.windzone_icon, windzone_icon);
            _reverseIconLookup.Add(windzone_icon, Enum.windzone_icon);
            _iconLookup.Add(Enum.d_spatialmappingcollider_icon, d_spatialmappingcollider_icon);
            _reverseIconLookup.Add(d_spatialmappingcollider_icon, Enum.d_spatialmappingcollider_icon);
            _iconLookup.Add(Enum.spatialmappingcollider_icon, spatialmappingcollider_icon);
            _reverseIconLookup.Add(spatialmappingcollider_icon, Enum.spatialmappingcollider_icon);
            _iconLookup.Add(Enum.spatialmappingrenderer_icon, spatialmappingrenderer_icon);
            _reverseIconLookup.Add(spatialmappingrenderer_icon, Enum.spatialmappingrenderer_icon);
            _iconLookup.Add(Enum.worldanchor_icon, worldanchor_icon);
            _reverseIconLookup.Add(worldanchor_icon, Enum.worldanchor_icon);
            _iconLookup.Add(Enum.ussscript_icon, ussscript_icon);
            _reverseIconLookup.Add(ussscript_icon, Enum.ussscript_icon);
            _iconLookup.Add(Enum.uxmlscript_icon, uxmlscript_icon);
            _reverseIconLookup.Add(uxmlscript_icon, Enum.uxmlscript_icon);
            _iconLookup.Add(Enum.videoeffect_icon, videoeffect_icon);
            _reverseIconLookup.Add(videoeffect_icon, Enum.videoeffect_icon);
            _iconLookup.Add(Enum.visualeffect_gizmo, visualeffect_gizmo);
            _reverseIconLookup.Add(visualeffect_gizmo, Enum.visualeffect_gizmo);
            _iconLookup.Add(Enum.windzone_gizmo, windzone_gizmo);
            _reverseIconLookup.Add(windzone_gizmo, Enum.windzone_gizmo);
            _iconLookup.Add(Enum.profiler_audio, profiler_audio);
            _reverseIconLookup.Add(profiler_audio, Enum.profiler_audio);
            _iconLookup.Add(Enum.profiler_cpu, profiler_cpu);
            _reverseIconLookup.Add(profiler_cpu, Enum.profiler_cpu);
            _iconLookup.Add(Enum.profiler_custom, profiler_custom);
            _reverseIconLookup.Add(profiler_custom, Enum.profiler_custom);
            _iconLookup.Add(Enum.profiler_firstframe, profiler_firstframe);
            _reverseIconLookup.Add(profiler_firstframe, Enum.profiler_firstframe);
            _iconLookup.Add(Enum.profiler_globalillumination, profiler_globalillumination);
            _reverseIconLookup.Add(profiler_globalillumination, Enum.profiler_globalillumination);
            _iconLookup.Add(Enum.profiler_gpu, profiler_gpu);
            _reverseIconLookup.Add(profiler_gpu, Enum.profiler_gpu);
            _iconLookup.Add(Enum.profiler_instrumentation, profiler_instrumentation);
            _reverseIconLookup.Add(profiler_instrumentation, Enum.profiler_instrumentation);
            _iconLookup.Add(Enum.profiler_lastframe, profiler_lastframe);
            _reverseIconLookup.Add(profiler_lastframe, Enum.profiler_lastframe);
            _iconLookup.Add(Enum.profiler_memory, profiler_memory);
            _reverseIconLookup.Add(profiler_memory, Enum.profiler_memory);
            _iconLookup.Add(Enum.profiler_networkmessages, profiler_networkmessages);
            _reverseIconLookup.Add(profiler_networkmessages, Enum.profiler_networkmessages);
            _iconLookup.Add(Enum.profiler_networkoperations, profiler_networkoperations);
            _reverseIconLookup.Add(profiler_networkoperations, Enum.profiler_networkoperations);
            _iconLookup.Add(Enum.profiler_nextframe, profiler_nextframe);
            _reverseIconLookup.Add(profiler_nextframe, Enum.profiler_nextframe);
            _iconLookup.Add(Enum.profiler_open, profiler_open);
            _reverseIconLookup.Add(profiler_open, Enum.profiler_open);
            _iconLookup.Add(Enum.profiler_physics, profiler_physics);
            _reverseIconLookup.Add(profiler_physics, Enum.profiler_physics);
            _iconLookup.Add(Enum.profiler_physics2d, profiler_physics2d);
            _reverseIconLookup.Add(profiler_physics2d, Enum.profiler_physics2d);
            _iconLookup.Add(Enum.profiler_prevframe, profiler_prevframe);
            _reverseIconLookup.Add(profiler_prevframe, Enum.profiler_prevframe);
            _iconLookup.Add(Enum.profiler_record, profiler_record);
            _reverseIconLookup.Add(profiler_record, Enum.profiler_record);
            _iconLookup.Add(Enum.profiler_rendering, profiler_rendering);
            _reverseIconLookup.Add(profiler_rendering, Enum.profiler_rendering);
            _iconLookup.Add(Enum.profiler_ui, profiler_ui);
            _reverseIconLookup.Add(profiler_ui, Enum.profiler_ui);
            _iconLookup.Add(Enum.profiler_uidetails, profiler_uidetails);
            _reverseIconLookup.Add(profiler_uidetails, Enum.profiler_uidetails);
            _iconLookup.Add(Enum.profiler_video, profiler_video);
            _reverseIconLookup.Add(profiler_video, Enum.profiler_video);
            _iconLookup.Add(Enum.profiler_virtualtexturing, profiler_virtualtexturing);
            _reverseIconLookup.Add(profiler_virtualtexturing, Enum.profiler_virtualtexturing);
            _iconLookup.Add(Enum.profilercolumn_warningcount, profilercolumn_warningcount);
            _reverseIconLookup.Add(profilercolumn_warningcount, Enum.profilercolumn_warningcount);
            _iconLookup.Add(Enum.progress, progress);
            _reverseIconLookup.Add(progress, Enum.progress);
            _iconLookup.Add(Enum.project, project);
            _reverseIconLookup.Add(project, Enum.project);
            _iconLookup.Add(Enum.d_dragarrow, d_dragarrow);
            _reverseIconLookup.Add(d_dragarrow, Enum.d_dragarrow);
            _iconLookup.Add(Enum.d_gridview_on, d_gridview_on);
            _reverseIconLookup.Add(d_gridview_on, Enum.d_gridview_on);
            _iconLookup.Add(Enum.d_gridview, d_gridview);
            _reverseIconLookup.Add(d_gridview, Enum.d_gridview);
            _iconLookup.Add(Enum.d_help, d_help);
            _reverseIconLookup.Add(d_help, Enum.d_help);
            _iconLookup.Add(Enum.d_listview_on, d_listview_on);
            _reverseIconLookup.Add(d_listview_on, Enum.d_listview_on);
            _iconLookup.Add(Enum.d_listview, d_listview);
            _reverseIconLookup.Add(d_listview, Enum.d_listview);
            _iconLookup.Add(Enum.d_more, d_more);
            _reverseIconLookup.Add(d_more, Enum.d_more);
            _iconLookup.Add(Enum.d_searchwindow, d_searchwindow);
            _reverseIconLookup.Add(d_searchwindow, Enum.d_searchwindow);
            _iconLookup.Add(Enum.d_syncsearch_on, d_syncsearch_on);
            _reverseIconLookup.Add(d_syncsearch_on, Enum.d_syncsearch_on);
            _iconLookup.Add(Enum.d_syncsearch, d_syncsearch);
            _reverseIconLookup.Add(d_syncsearch, Enum.d_syncsearch);
            _iconLookup.Add(Enum.d_tableview_on, d_tableview_on);
            _reverseIconLookup.Add(d_tableview_on, Enum.d_tableview_on);
            _iconLookup.Add(Enum.d_tableview, d_tableview);
            _reverseIconLookup.Add(d_tableview, Enum.d_tableview);
            _iconLookup.Add(Enum.dragarrow, dragarrow);
            _reverseIconLookup.Add(dragarrow, Enum.dragarrow);
            _iconLookup.Add(Enum.gridview_on, gridview_on);
            _reverseIconLookup.Add(gridview_on, Enum.gridview_on);
            _iconLookup.Add(Enum.gridview, gridview);
            _reverseIconLookup.Add(gridview, Enum.gridview);
            _iconLookup.Add(Enum.help, help);
            _reverseIconLookup.Add(help, Enum.help);
            _iconLookup.Add(Enum.listview_on, listview_on);
            _reverseIconLookup.Add(listview_on, Enum.listview_on);
            _iconLookup.Add(Enum.listview, listview);
            _reverseIconLookup.Add(listview, Enum.listview);
            _iconLookup.Add(Enum.more, more);
            _reverseIconLookup.Add(more, Enum.more);
            _iconLookup.Add(Enum.package_installed, package_installed);
            _reverseIconLookup.Add(package_installed, Enum.package_installed);
            _iconLookup.Add(Enum.package_update, package_update);
            _reverseIconLookup.Add(package_update, Enum.package_update);
            _iconLookup.Add(Enum.searchwindow, searchwindow);
            _reverseIconLookup.Add(searchwindow, Enum.searchwindow);
            _iconLookup.Add(Enum.syncsearch_on, syncsearch_on);
            _reverseIconLookup.Add(syncsearch_on, Enum.syncsearch_on);
            _iconLookup.Add(Enum.syncsearch, syncsearch);
            _reverseIconLookup.Add(syncsearch, Enum.syncsearch);
            _iconLookup.Add(Enum.tableview_on, tableview_on);
            _reverseIconLookup.Add(tableview_on, Enum.tableview_on);
            _iconLookup.Add(Enum.tableview, tableview);
            _reverseIconLookup.Add(tableview, Enum.tableview);
            _iconLookup.Add(Enum.record_off, record_off);
            _reverseIconLookup.Add(record_off, Enum.record_off);
            _iconLookup.Add(Enum.record_on, record_on);
            _reverseIconLookup.Add(record_on, Enum.record_on);
            _iconLookup.Add(Enum.recttool_on, recttool_on);
            _reverseIconLookup.Add(recttool_on, Enum.recttool_on);
            _iconLookup.Add(Enum.recttool, recttool);
            _reverseIconLookup.Add(recttool, Enum.recttool);
            _iconLookup.Add(Enum.recttransformblueprint, recttransformblueprint);
            _reverseIconLookup.Add(recttransformblueprint, Enum.recttransformblueprint);
            _iconLookup.Add(Enum.recttransformraw, recttransformraw);
            _reverseIconLookup.Add(recttransformraw, Enum.recttransformraw);
            _iconLookup.Add(Enum.redgroove, redgroove);
            _reverseIconLookup.Add(redgroove, Enum.redgroove);
            _iconLookup.Add(Enum.reflectionprobeselector, reflectionprobeselector);
            _reverseIconLookup.Add(reflectionprobeselector, Enum.reflectionprobeselector);
            _iconLookup.Add(Enum.repaintdot, repaintdot);
            _reverseIconLookup.Add(repaintdot, Enum.repaintdot);
            _iconLookup.Add(Enum.rightbracket, rightbracket);
            _reverseIconLookup.Add(rightbracket, Enum.rightbracket);
            _iconLookup.Add(Enum.rotatetool_on, rotatetool_on);
            _reverseIconLookup.Add(rotatetool_on, Enum.rotatetool_on);
            _iconLookup.Add(Enum.rotatetool, rotatetool);
            _reverseIconLookup.Add(rotatetool, Enum.rotatetool);
            _iconLookup.Add(Enum.saveactive, saveactive);
            _reverseIconLookup.Add(saveactive, Enum.saveactive);
            _iconLookup.Add(Enum.saveas, saveas);
            _reverseIconLookup.Add(saveas, Enum.saveas);
            _iconLookup.Add(Enum.savefromplay, savefromplay);
            _reverseIconLookup.Add(savefromplay, Enum.savefromplay);
            _iconLookup.Add(Enum.savepassive, savepassive);
            _reverseIconLookup.Add(savepassive, Enum.savepassive);
            _iconLookup.Add(Enum.scaletool_on, scaletool_on);
            _reverseIconLookup.Add(scaletool_on, Enum.scaletool_on);
            _iconLookup.Add(Enum.scaletool, scaletool);
            _reverseIconLookup.Add(scaletool, Enum.scaletool);
            _iconLookup.Add(Enum.sceneloadin, sceneloadin);
            _reverseIconLookup.Add(sceneloadin, Enum.sceneloadin);
            _iconLookup.Add(Enum.sceneloadout, sceneloadout);
            _reverseIconLookup.Add(sceneloadout, Enum.sceneloadout);
            _iconLookup.Add(Enum.scenepicking_notpickable_mixed, scenepicking_notpickable_mixed);
            _reverseIconLookup.Add(scenepicking_notpickable_mixed, Enum.scenepicking_notpickable_mixed);
            _iconLookup.Add(Enum.scenepicking_notpickable_mixed_hover, scenepicking_notpickable_mixed_hover);
            _reverseIconLookup.Add(scenepicking_notpickable_mixed_hover, Enum.scenepicking_notpickable_mixed_hover);
            _iconLookup.Add(Enum.scenepicking_notpickable, scenepicking_notpickable);
            _reverseIconLookup.Add(scenepicking_notpickable, Enum.scenepicking_notpickable);
            _iconLookup.Add(Enum.scenepicking_notpickable_hover, scenepicking_notpickable_hover);
            _reverseIconLookup.Add(scenepicking_notpickable_hover, Enum.scenepicking_notpickable_hover);
            _iconLookup.Add(Enum.scenepicking_pickable_mixed, scenepicking_pickable_mixed);
            _reverseIconLookup.Add(scenepicking_pickable_mixed, Enum.scenepicking_pickable_mixed);
            _iconLookup.Add(Enum.scenepicking_pickable_mixed_hover, scenepicking_pickable_mixed_hover);
            _reverseIconLookup.Add(scenepicking_pickable_mixed_hover, Enum.scenepicking_pickable_mixed_hover);
            _iconLookup.Add(Enum.scenepicking_pickable, scenepicking_pickable);
            _reverseIconLookup.Add(scenepicking_pickable, Enum.scenepicking_pickable);
            _iconLookup.Add(Enum.scenepicking_pickable_hover, scenepicking_pickable_hover);
            _reverseIconLookup.Add(scenepicking_pickable_hover, Enum.scenepicking_pickable_hover);
            _iconLookup.Add(Enum.scenesave, scenesave);
            _reverseIconLookup.Add(scenesave, Enum.scenesave);
            _iconLookup.Add(Enum.scenesavegrey, scenesavegrey);
            _reverseIconLookup.Add(scenesavegrey, Enum.scenesavegrey);
            _iconLookup.Add(Enum.pin, pin);
            _reverseIconLookup.Add(pin, Enum.pin);
            _iconLookup.Add(Enum.pinned, pinned);
            _reverseIconLookup.Add(pinned, Enum.pinned);
            _iconLookup.Add(Enum.scene_template_2d_scene, scene_template_2d_scene);
            _reverseIconLookup.Add(scene_template_2d_scene, Enum.scene_template_2d_scene);
            _iconLookup.Add(Enum.scene_template_3d_scene, scene_template_3d_scene);
            _reverseIconLookup.Add(scene_template_3d_scene, Enum.scene_template_3d_scene);
            _iconLookup.Add(Enum.scene_template_dark, scene_template_dark);
            _reverseIconLookup.Add(scene_template_dark, Enum.scene_template_dark);
            _iconLookup.Add(Enum.scene_template_default_scene, scene_template_default_scene);
            _reverseIconLookup.Add(scene_template_default_scene, Enum.scene_template_default_scene);
            _iconLookup.Add(Enum.scene_template_empty_scene, scene_template_empty_scene);
            _reverseIconLookup.Add(scene_template_empty_scene, Enum.scene_template_empty_scene);
            _iconLookup.Add(Enum.scene_template_light, scene_template_light);
            _reverseIconLookup.Add(scene_template_light, Enum.scene_template_light);
            _iconLookup.Add(Enum.scene_template, scene_template);
            _reverseIconLookup.Add(scene_template, Enum.scene_template);
            _iconLookup.Add(Enum.sceneview2d_on, sceneview2d_on);
            _reverseIconLookup.Add(sceneview2d_on, Enum.sceneview2d_on);
            _iconLookup.Add(Enum.sceneview2d, sceneview2d);
            _reverseIconLookup.Add(sceneview2d, Enum.sceneview2d);
            _iconLookup.Add(Enum.sceneviewalpha, sceneviewalpha);
            _reverseIconLookup.Add(sceneviewalpha, Enum.sceneviewalpha);
            _iconLookup.Add(Enum.sceneviewaudio_on, sceneviewaudio_on);
            _reverseIconLookup.Add(sceneviewaudio_on, Enum.sceneviewaudio_on);
            _iconLookup.Add(Enum.sceneviewaudio, sceneviewaudio);
            _reverseIconLookup.Add(sceneviewaudio, Enum.sceneviewaudio);
            _iconLookup.Add(Enum.sceneviewcamera_on, sceneviewcamera_on);
            _reverseIconLookup.Add(sceneviewcamera_on, Enum.sceneviewcamera_on);
            _iconLookup.Add(Enum.sceneviewcamera, sceneviewcamera);
            _reverseIconLookup.Add(sceneviewcamera, Enum.sceneviewcamera);
            _iconLookup.Add(Enum.sceneviewfx_on, sceneviewfx_on);
            _reverseIconLookup.Add(sceneviewfx_on, Enum.sceneviewfx_on);
            _iconLookup.Add(Enum.sceneviewfx, sceneviewfx);
            _reverseIconLookup.Add(sceneviewfx, Enum.sceneviewfx);
            _iconLookup.Add(Enum.sceneviewlighting_on, sceneviewlighting_on);
            _reverseIconLookup.Add(sceneviewlighting_on, Enum.sceneviewlighting_on);
            _iconLookup.Add(Enum.sceneviewlighting, sceneviewlighting);
            _reverseIconLookup.Add(sceneviewlighting, Enum.sceneviewlighting);
            _iconLookup.Add(Enum.sceneviewortho, sceneviewortho);
            _reverseIconLookup.Add(sceneviewortho, Enum.sceneviewortho);
            _iconLookup.Add(Enum.sceneviewrgb, sceneviewrgb);
            _reverseIconLookup.Add(sceneviewrgb, Enum.sceneviewrgb);
            _iconLookup.Add(Enum.sceneviewtools_on, sceneviewtools_on);
            _reverseIconLookup.Add(sceneviewtools_on, Enum.sceneviewtools_on);
            _iconLookup.Add(Enum.sceneviewtools, sceneviewtools);
            _reverseIconLookup.Add(sceneviewtools, Enum.sceneviewtools);
            _iconLookup.Add(Enum.sceneviewvisibility_on, sceneviewvisibility_on);
            _reverseIconLookup.Add(sceneviewvisibility_on, Enum.sceneviewvisibility_on);
            _iconLookup.Add(Enum.sceneviewvisibility, sceneviewvisibility);
            _reverseIconLookup.Add(sceneviewvisibility, Enum.sceneviewvisibility);
            _iconLookup.Add(Enum.scenevis_hidden_mixed, scenevis_hidden_mixed);
            _reverseIconLookup.Add(scenevis_hidden_mixed, Enum.scenevis_hidden_mixed);
            _iconLookup.Add(Enum.scenevis_hidden_mixed_hover, scenevis_hidden_mixed_hover);
            _reverseIconLookup.Add(scenevis_hidden_mixed_hover, Enum.scenevis_hidden_mixed_hover);
            _iconLookup.Add(Enum.scenevis_hidden, scenevis_hidden);
            _reverseIconLookup.Add(scenevis_hidden, Enum.scenevis_hidden);
            _iconLookup.Add(Enum.scenevis_hidden_hover, scenevis_hidden_hover);
            _reverseIconLookup.Add(scenevis_hidden_hover, Enum.scenevis_hidden_hover);
            _iconLookup.Add(Enum.scenevis_scene_hover, scenevis_scene_hover);
            _reverseIconLookup.Add(scenevis_scene_hover, Enum.scenevis_scene_hover);
            _iconLookup.Add(Enum.scenevis_visible_mixed, scenevis_visible_mixed);
            _reverseIconLookup.Add(scenevis_visible_mixed, Enum.scenevis_visible_mixed);
            _iconLookup.Add(Enum.scenevis_visible_mixed_hover, scenevis_visible_mixed_hover);
            _reverseIconLookup.Add(scenevis_visible_mixed_hover, Enum.scenevis_visible_mixed_hover);
            _iconLookup.Add(Enum.scenevis_visible, scenevis_visible);
            _reverseIconLookup.Add(scenevis_visible, Enum.scenevis_visible);
            _iconLookup.Add(Enum.scenevis_visible_hover, scenevis_visible_hover);
            _reverseIconLookup.Add(scenevis_visible_hover, Enum.scenevis_visible_hover);
            _iconLookup.Add(Enum.scrollshadow, scrollshadow);
            _reverseIconLookup.Add(scrollshadow, Enum.scrollshadow);
            _iconLookup.Add(Enum.settings, settings);
            _reverseIconLookup.Add(settings, Enum.settings);
            _iconLookup.Add(Enum.settingsicon, settingsicon);
            _reverseIconLookup.Add(settingsicon, Enum.settingsicon);
            _iconLookup.Add(Enum.alertdialog, alertdialog);
            _reverseIconLookup.Add(alertdialog, Enum.alertdialog);
            _iconLookup.Add(Enum.conflict_icon, conflict_icon);
            _reverseIconLookup.Add(conflict_icon, Enum.conflict_icon);
            _iconLookup.Add(Enum.showpanels, showpanels);
            _reverseIconLookup.Add(showpanels, Enum.showpanels);
            _iconLookup.Add(Enum.d_gridaxisx_on, d_gridaxisx_on);
            _reverseIconLookup.Add(d_gridaxisx_on, Enum.d_gridaxisx_on);
            _iconLookup.Add(Enum.d_gridaxisx, d_gridaxisx);
            _reverseIconLookup.Add(d_gridaxisx, Enum.d_gridaxisx);
            _iconLookup.Add(Enum.d_gridaxisy_on, d_gridaxisy_on);
            _reverseIconLookup.Add(d_gridaxisy_on, Enum.d_gridaxisy_on);
            _iconLookup.Add(Enum.d_gridaxisy, d_gridaxisy);
            _reverseIconLookup.Add(d_gridaxisy, Enum.d_gridaxisy);
            _iconLookup.Add(Enum.d_gridaxisz_on, d_gridaxisz_on);
            _reverseIconLookup.Add(d_gridaxisz_on, Enum.d_gridaxisz_on);
            _iconLookup.Add(Enum.d_gridaxisz, d_gridaxisz);
            _reverseIconLookup.Add(d_gridaxisz, Enum.d_gridaxisz);
            _iconLookup.Add(Enum.d_sceneviewsnap_on, d_sceneviewsnap_on);
            _reverseIconLookup.Add(d_sceneviewsnap_on, Enum.d_sceneviewsnap_on);
            _iconLookup.Add(Enum.d_sceneviewsnap, d_sceneviewsnap);
            _reverseIconLookup.Add(d_sceneviewsnap, Enum.d_sceneviewsnap);
            _iconLookup.Add(Enum.d_snapincrement, d_snapincrement);
            _reverseIconLookup.Add(d_snapincrement, Enum.d_snapincrement);
            _iconLookup.Add(Enum.gridaxisx_on, gridaxisx_on);
            _reverseIconLookup.Add(gridaxisx_on, Enum.gridaxisx_on);
            _iconLookup.Add(Enum.gridaxisx, gridaxisx);
            _reverseIconLookup.Add(gridaxisx, Enum.gridaxisx);
            _iconLookup.Add(Enum.gridaxisy_on, gridaxisy_on);
            _reverseIconLookup.Add(gridaxisy_on, Enum.gridaxisy_on);
            _iconLookup.Add(Enum.gridaxisy, gridaxisy);
            _reverseIconLookup.Add(gridaxisy, Enum.gridaxisy);
            _iconLookup.Add(Enum.gridaxisz_on, gridaxisz_on);
            _reverseIconLookup.Add(gridaxisz_on, Enum.gridaxisz_on);
            _iconLookup.Add(Enum.gridaxisz, gridaxisz);
            _reverseIconLookup.Add(gridaxisz, Enum.gridaxisz);
            _iconLookup.Add(Enum.sceneviewsnap_on, sceneviewsnap_on);
            _reverseIconLookup.Add(sceneviewsnap_on, Enum.sceneviewsnap_on);
            _iconLookup.Add(Enum.sceneviewsnap, sceneviewsnap);
            _reverseIconLookup.Add(sceneviewsnap, Enum.sceneviewsnap);
            _iconLookup.Add(Enum.snapincrement, snapincrement);
            _reverseIconLookup.Add(snapincrement, Enum.snapincrement);
            _iconLookup.Add(Enum.socialnetworks_facebookshare, socialnetworks_facebookshare);
            _reverseIconLookup.Add(socialnetworks_facebookshare, Enum.socialnetworks_facebookshare);
            _iconLookup.Add(Enum.socialnetworks_linkedinshare, socialnetworks_linkedinshare);
            _reverseIconLookup.Add(socialnetworks_linkedinshare, Enum.socialnetworks_linkedinshare);
            _iconLookup.Add(Enum.socialnetworks_tweet, socialnetworks_tweet);
            _reverseIconLookup.Add(socialnetworks_tweet, Enum.socialnetworks_tweet);
            _iconLookup.Add(Enum.socialnetworks_udnlogo, socialnetworks_udnlogo);
            _reverseIconLookup.Add(socialnetworks_udnlogo, Enum.socialnetworks_udnlogo);
            _iconLookup.Add(Enum.socialnetworks_udnopen, socialnetworks_udnopen);
            _reverseIconLookup.Add(socialnetworks_udnopen, Enum.socialnetworks_udnopen);
            _iconLookup.Add(Enum.softlockinline, softlockinline);
            _reverseIconLookup.Add(softlockinline, Enum.softlockinline);
            _iconLookup.Add(Enum.speedscale, speedscale);
            _reverseIconLookup.Add(speedscale, Enum.speedscale);
            _iconLookup.Add(Enum.statemachineeditor_arrowtip, statemachineeditor_arrowtip);
            _reverseIconLookup.Add(statemachineeditor_arrowtip, Enum.statemachineeditor_arrowtip);
            _iconLookup.Add(Enum.statemachineeditor_arrowtipselected, statemachineeditor_arrowtipselected);
            _reverseIconLookup.Add(statemachineeditor_arrowtipselected, Enum.statemachineeditor_arrowtipselected);
            _iconLookup.Add(Enum.statemachineeditor_background, statemachineeditor_background);
            _reverseIconLookup.Add(statemachineeditor_background, Enum.statemachineeditor_background);
            _iconLookup.Add(Enum.statemachineeditor_state, statemachineeditor_state);
            _reverseIconLookup.Add(statemachineeditor_state, Enum.statemachineeditor_state);
            _iconLookup.Add(Enum.statemachineeditor_statehover, statemachineeditor_statehover);
            _reverseIconLookup.Add(statemachineeditor_statehover, Enum.statemachineeditor_statehover);
            _iconLookup.Add(Enum.statemachineeditor_stateselected, statemachineeditor_stateselected);
            _reverseIconLookup.Add(statemachineeditor_stateselected, Enum.statemachineeditor_stateselected);
            _iconLookup.Add(Enum.statemachineeditor_statesub, statemachineeditor_statesub);
            _reverseIconLookup.Add(statemachineeditor_statesub, Enum.statemachineeditor_statesub);
            _iconLookup.Add(Enum.statemachineeditor_statesubhover, statemachineeditor_statesubhover);
            _reverseIconLookup.Add(statemachineeditor_statesubhover, Enum.statemachineeditor_statesubhover);
            _iconLookup.Add(Enum.statemachineeditor_statesubselected, statemachineeditor_statesubselected);
            _reverseIconLookup.Add(statemachineeditor_statesubselected, Enum.statemachineeditor_statesubselected);
            _iconLookup.Add(Enum.statemachineeditor_upbutton, statemachineeditor_upbutton);
            _reverseIconLookup.Add(statemachineeditor_upbutton, Enum.statemachineeditor_upbutton);
            _iconLookup.Add(Enum.statemachineeditor_upbuttonhover, statemachineeditor_upbuttonhover);
            _reverseIconLookup.Add(statemachineeditor_upbuttonhover, Enum.statemachineeditor_upbuttonhover);
            _iconLookup.Add(Enum.stepbutton_on, stepbutton_on);
            _reverseIconLookup.Add(stepbutton_on, Enum.stepbutton_on);
            _iconLookup.Add(Enum.stepbutton, stepbutton);
            _reverseIconLookup.Add(stepbutton, Enum.stepbutton);
            _iconLookup.Add(Enum.stepleftbutton_on, stepleftbutton_on);
            _reverseIconLookup.Add(stepleftbutton_on, Enum.stepleftbutton_on);
            _iconLookup.Add(Enum.stepleftbutton, stepleftbutton);
            _reverseIconLookup.Add(stepleftbutton, Enum.stepleftbutton);
            _iconLookup.Add(Enum.sv_icon_dot0_sml, sv_icon_dot0_sml);
            _reverseIconLookup.Add(sv_icon_dot0_sml, Enum.sv_icon_dot0_sml);
            _iconLookup.Add(Enum.sv_icon_dot10_sml, sv_icon_dot10_sml);
            _reverseIconLookup.Add(sv_icon_dot10_sml, Enum.sv_icon_dot10_sml);
            _iconLookup.Add(Enum.sv_icon_dot11_sml, sv_icon_dot11_sml);
            _reverseIconLookup.Add(sv_icon_dot11_sml, Enum.sv_icon_dot11_sml);
            _iconLookup.Add(Enum.sv_icon_dot12_sml, sv_icon_dot12_sml);
            _reverseIconLookup.Add(sv_icon_dot12_sml, Enum.sv_icon_dot12_sml);
            _iconLookup.Add(Enum.sv_icon_dot13_sml, sv_icon_dot13_sml);
            _reverseIconLookup.Add(sv_icon_dot13_sml, Enum.sv_icon_dot13_sml);
            _iconLookup.Add(Enum.sv_icon_dot14_sml, sv_icon_dot14_sml);
            _reverseIconLookup.Add(sv_icon_dot14_sml, Enum.sv_icon_dot14_sml);
            _iconLookup.Add(Enum.sv_icon_dot15_sml, sv_icon_dot15_sml);
            _reverseIconLookup.Add(sv_icon_dot15_sml, Enum.sv_icon_dot15_sml);
            _iconLookup.Add(Enum.sv_icon_dot1_sml, sv_icon_dot1_sml);
            _reverseIconLookup.Add(sv_icon_dot1_sml, Enum.sv_icon_dot1_sml);
            _iconLookup.Add(Enum.sv_icon_dot2_sml, sv_icon_dot2_sml);
            _reverseIconLookup.Add(sv_icon_dot2_sml, Enum.sv_icon_dot2_sml);
            _iconLookup.Add(Enum.sv_icon_dot3_sml, sv_icon_dot3_sml);
            _reverseIconLookup.Add(sv_icon_dot3_sml, Enum.sv_icon_dot3_sml);
            _iconLookup.Add(Enum.sv_icon_dot4_sml, sv_icon_dot4_sml);
            _reverseIconLookup.Add(sv_icon_dot4_sml, Enum.sv_icon_dot4_sml);
            _iconLookup.Add(Enum.sv_icon_dot5_sml, sv_icon_dot5_sml);
            _reverseIconLookup.Add(sv_icon_dot5_sml, Enum.sv_icon_dot5_sml);
            _iconLookup.Add(Enum.sv_icon_dot6_sml, sv_icon_dot6_sml);
            _reverseIconLookup.Add(sv_icon_dot6_sml, Enum.sv_icon_dot6_sml);
            _iconLookup.Add(Enum.sv_icon_dot7_sml, sv_icon_dot7_sml);
            _reverseIconLookup.Add(sv_icon_dot7_sml, Enum.sv_icon_dot7_sml);
            _iconLookup.Add(Enum.sv_icon_dot8_sml, sv_icon_dot8_sml);
            _reverseIconLookup.Add(sv_icon_dot8_sml, Enum.sv_icon_dot8_sml);
            _iconLookup.Add(Enum.sv_icon_dot9_sml, sv_icon_dot9_sml);
            _reverseIconLookup.Add(sv_icon_dot9_sml, Enum.sv_icon_dot9_sml);
            _iconLookup.Add(Enum.sv_icon_name0, sv_icon_name0);
            _reverseIconLookup.Add(sv_icon_name0, Enum.sv_icon_name0);
            _iconLookup.Add(Enum.sv_icon_name1, sv_icon_name1);
            _reverseIconLookup.Add(sv_icon_name1, Enum.sv_icon_name1);
            _iconLookup.Add(Enum.sv_icon_name2, sv_icon_name2);
            _reverseIconLookup.Add(sv_icon_name2, Enum.sv_icon_name2);
            _iconLookup.Add(Enum.sv_icon_name3, sv_icon_name3);
            _reverseIconLookup.Add(sv_icon_name3, Enum.sv_icon_name3);
            _iconLookup.Add(Enum.sv_icon_name4, sv_icon_name4);
            _reverseIconLookup.Add(sv_icon_name4, Enum.sv_icon_name4);
            _iconLookup.Add(Enum.sv_icon_name5, sv_icon_name5);
            _reverseIconLookup.Add(sv_icon_name5, Enum.sv_icon_name5);
            _iconLookup.Add(Enum.sv_icon_name6, sv_icon_name6);
            _reverseIconLookup.Add(sv_icon_name6, Enum.sv_icon_name6);
            _iconLookup.Add(Enum.sv_icon_name7, sv_icon_name7);
            _reverseIconLookup.Add(sv_icon_name7, Enum.sv_icon_name7);
            _iconLookup.Add(Enum.sv_icon_none, sv_icon_none);
            _reverseIconLookup.Add(sv_icon_none, Enum.sv_icon_none);
            _iconLookup.Add(Enum.sv_label_0, sv_label_0);
            _reverseIconLookup.Add(sv_label_0, Enum.sv_label_0);
            _iconLookup.Add(Enum.sv_label_1, sv_label_1);
            _reverseIconLookup.Add(sv_label_1, Enum.sv_label_1);
            _iconLookup.Add(Enum.sv_label_2, sv_label_2);
            _reverseIconLookup.Add(sv_label_2, Enum.sv_label_2);
            _iconLookup.Add(Enum.sv_label_3, sv_label_3);
            _reverseIconLookup.Add(sv_label_3, Enum.sv_label_3);
            _iconLookup.Add(Enum.sv_label_4, sv_label_4);
            _reverseIconLookup.Add(sv_label_4, Enum.sv_label_4);
            _iconLookup.Add(Enum.sv_label_5, sv_label_5);
            _reverseIconLookup.Add(sv_label_5, Enum.sv_label_5);
            _iconLookup.Add(Enum.sv_label_6, sv_label_6);
            _reverseIconLookup.Add(sv_label_6, Enum.sv_label_6);
            _iconLookup.Add(Enum.sv_label_7, sv_label_7);
            _reverseIconLookup.Add(sv_label_7, Enum.sv_label_7);
            _iconLookup.Add(Enum.tab_next, tab_next);
            _reverseIconLookup.Add(tab_next, Enum.tab_next);
            _iconLookup.Add(Enum.tab_prev, tab_prev);
            _reverseIconLookup.Add(tab_prev, Enum.tab_prev);
            _iconLookup.Add(Enum.tabtofilter, tabtofilter);
            _reverseIconLookup.Add(tabtofilter, Enum.tabtofilter);
            _iconLookup.Add(Enum.terraininspector_terraintooladd, terraininspector_terraintooladd);
            _reverseIconLookup.Add(terraininspector_terraintooladd, Enum.terraininspector_terraintooladd);
            _iconLookup.Add(Enum.terraininspector_terraintoollower_on, terraininspector_terraintoollower_on);
            _reverseIconLookup.Add(terraininspector_terraintoollower_on, Enum.terraininspector_terraintoollower_on);
            _iconLookup.Add(Enum.terraininspector_terraintoollower, terraininspector_terraintoollower);
            _reverseIconLookup.Add(terraininspector_terraintoollower, Enum.terraininspector_terraintoollower);
            _iconLookup.Add(Enum.terraininspector_terraintoolloweralt, terraininspector_terraintoolloweralt);
            _reverseIconLookup.Add(terraininspector_terraintoolloweralt, Enum.terraininspector_terraintoolloweralt);
            _iconLookup.Add(Enum.terraininspector_terraintoolplants_on, terraininspector_terraintoolplants_on);
            _reverseIconLookup.Add(terraininspector_terraintoolplants_on, Enum.terraininspector_terraintoolplants_on);
            _iconLookup.Add(Enum.terraininspector_terraintoolplants, terraininspector_terraintoolplants);
            _reverseIconLookup.Add(terraininspector_terraintoolplants, Enum.terraininspector_terraintoolplants);
            _iconLookup.Add(Enum.terraininspector_terraintoolplantsalt_on, terraininspector_terraintoolplantsalt_on);
            _reverseIconLookup.Add(terraininspector_terraintoolplantsalt_on, Enum.terraininspector_terraintoolplantsalt_on);
            _iconLookup.Add(Enum.terraininspector_terraintoolplantsalt, terraininspector_terraintoolplantsalt);
            _reverseIconLookup.Add(terraininspector_terraintoolplantsalt, Enum.terraininspector_terraintoolplantsalt);
            _iconLookup.Add(Enum.terraininspector_terraintoolraise_on, terraininspector_terraintoolraise_on);
            _reverseIconLookup.Add(terraininspector_terraintoolraise_on, Enum.terraininspector_terraintoolraise_on);
            _iconLookup.Add(Enum.terraininspector_terraintoolraise, terraininspector_terraintoolraise);
            _reverseIconLookup.Add(terraininspector_terraintoolraise, Enum.terraininspector_terraintoolraise);
            _iconLookup.Add(Enum.terraininspector_terraintoolsculpt_on, terraininspector_terraintoolsculpt_on);
            _reverseIconLookup.Add(terraininspector_terraintoolsculpt_on, Enum.terraininspector_terraintoolsculpt_on);
            _iconLookup.Add(Enum.terraininspector_terraintoolsculpt, terraininspector_terraintoolsculpt);
            _reverseIconLookup.Add(terraininspector_terraintoolsculpt, Enum.terraininspector_terraintoolsculpt);
            _iconLookup.Add(Enum.terraininspector_terraintoolsetheight_on, terraininspector_terraintoolsetheight_on);
            _reverseIconLookup.Add(terraininspector_terraintoolsetheight_on, Enum.terraininspector_terraintoolsetheight_on);
            _iconLookup.Add(Enum.terraininspector_terraintoolsetheight, terraininspector_terraintoolsetheight);
            _reverseIconLookup.Add(terraininspector_terraintoolsetheight, Enum.terraininspector_terraintoolsetheight);
            _iconLookup.Add(Enum.terraininspector_terraintoolsetheightalt_on, terraininspector_terraintoolsetheightalt_on);
            _reverseIconLookup.Add(terraininspector_terraintoolsetheightalt_on, Enum.terraininspector_terraintoolsetheightalt_on);
            _iconLookup.Add(Enum.terraininspector_terraintoolsetheightalt, terraininspector_terraintoolsetheightalt);
            _reverseIconLookup.Add(terraininspector_terraintoolsetheightalt, Enum.terraininspector_terraintoolsetheightalt);
            _iconLookup.Add(Enum.terraininspector_terraintoolsettings_on, terraininspector_terraintoolsettings_on);
            _reverseIconLookup.Add(terraininspector_terraintoolsettings_on, Enum.terraininspector_terraintoolsettings_on);
            _iconLookup.Add(Enum.terraininspector_terraintoolsettings, terraininspector_terraintoolsettings);
            _reverseIconLookup.Add(terraininspector_terraintoolsettings, Enum.terraininspector_terraintoolsettings);
            _iconLookup.Add(Enum.terraininspector_terraintoolsmoothheight_on, terraininspector_terraintoolsmoothheight_on);
            _reverseIconLookup.Add(terraininspector_terraintoolsmoothheight_on, Enum.terraininspector_terraintoolsmoothheight_on);
            _iconLookup.Add(Enum.terraininspector_terraintoolsmoothheight, terraininspector_terraintoolsmoothheight);
            _reverseIconLookup.Add(terraininspector_terraintoolsmoothheight, Enum.terraininspector_terraintoolsmoothheight);
            _iconLookup.Add(Enum.terraininspector_terraintoolsplat_on, terraininspector_terraintoolsplat_on);
            _reverseIconLookup.Add(terraininspector_terraintoolsplat_on, Enum.terraininspector_terraintoolsplat_on);
            _iconLookup.Add(Enum.terraininspector_terraintoolsplat, terraininspector_terraintoolsplat);
            _reverseIconLookup.Add(terraininspector_terraintoolsplat, Enum.terraininspector_terraintoolsplat);
            _iconLookup.Add(Enum.terraininspector_terraintoolsplatalt_on, terraininspector_terraintoolsplatalt_on);
            _reverseIconLookup.Add(terraininspector_terraintoolsplatalt_on, Enum.terraininspector_terraintoolsplatalt_on);
            _iconLookup.Add(Enum.terraininspector_terraintoolsplatalt, terraininspector_terraintoolsplatalt);
            _reverseIconLookup.Add(terraininspector_terraintoolsplatalt, Enum.terraininspector_terraintoolsplatalt);
            _iconLookup.Add(Enum.terraininspector_terraintooltrees_on, terraininspector_terraintooltrees_on);
            _reverseIconLookup.Add(terraininspector_terraintooltrees_on, Enum.terraininspector_terraintooltrees_on);
            _iconLookup.Add(Enum.terraininspector_terraintooltrees, terraininspector_terraintooltrees);
            _reverseIconLookup.Add(terraininspector_terraintooltrees, Enum.terraininspector_terraintooltrees);
            _iconLookup.Add(Enum.terraininspector_terraintooltreesalt_on, terraininspector_terraintooltreesalt_on);
            _reverseIconLookup.Add(terraininspector_terraintooltreesalt_on, Enum.terraininspector_terraintooltreesalt_on);
            _iconLookup.Add(Enum.terraininspector_terraintooltreesalt, terraininspector_terraintooltreesalt);
            _reverseIconLookup.Add(terraininspector_terraintooltreesalt, Enum.terraininspector_terraintooltreesalt);
            _iconLookup.Add(Enum.testfailed, testfailed);
            _reverseIconLookup.Add(testfailed, Enum.testfailed);
            _iconLookup.Add(Enum.testignored, testignored);
            _reverseIconLookup.Add(testignored, Enum.testignored);
            _iconLookup.Add(Enum.testinconclusive, testinconclusive);
            _reverseIconLookup.Add(testinconclusive, Enum.testinconclusive);
            _iconLookup.Add(Enum.testnormal, testnormal);
            _reverseIconLookup.Add(testnormal, Enum.testnormal);
            _iconLookup.Add(Enum.testpassed, testpassed);
            _reverseIconLookup.Add(testpassed, Enum.testpassed);
            _iconLookup.Add(Enum.teststopwatch, teststopwatch);
            _reverseIconLookup.Add(teststopwatch, Enum.teststopwatch);
            _iconLookup.Add(Enum.toggleuvoverlay, toggleuvoverlay);
            _reverseIconLookup.Add(toggleuvoverlay, Enum.toggleuvoverlay);
            _iconLookup.Add(Enum.toolbar_minus, toolbar_minus);
            _reverseIconLookup.Add(toolbar_minus, Enum.toolbar_minus);
            _iconLookup.Add(Enum.toolbar_plus_more, toolbar_plus_more);
            _reverseIconLookup.Add(toolbar_plus_more, Enum.toolbar_plus_more);
            _iconLookup.Add(Enum.toolbar_plus, toolbar_plus);
            _reverseIconLookup.Add(toolbar_plus, Enum.toolbar_plus);
            _iconLookup.Add(Enum.d_debug, d_debug);
            _reverseIconLookup.Add(d_debug, Enum.d_debug);
            _iconLookup.Add(Enum.d_objectmode, d_objectmode);
            _reverseIconLookup.Add(d_objectmode, Enum.d_objectmode);
            _iconLookup.Add(Enum.d_sceneviewtools_on, d_sceneviewtools_on);
            _reverseIconLookup.Add(d_sceneviewtools_on, Enum.d_sceneviewtools_on);
            _iconLookup.Add(Enum.d_shaded, d_shaded);
            _reverseIconLookup.Add(d_shaded, Enum.d_shaded);
            _iconLookup.Add(Enum.d_shadedwireframe, d_shadedwireframe);
            _reverseIconLookup.Add(d_shadedwireframe, Enum.d_shadedwireframe);
            _iconLookup.Add(Enum.d_wireframe, d_wireframe);
            _reverseIconLookup.Add(d_wireframe, Enum.d_wireframe);
            _iconLookup.Add(Enum.debug_on, debug_on);
            _reverseIconLookup.Add(debug_on, Enum.debug_on);
            _iconLookup.Add(Enum.debug, debug);
            _reverseIconLookup.Add(debug, Enum.debug);
            _iconLookup.Add(Enum.objectmode, objectmode);
            _reverseIconLookup.Add(objectmode, Enum.objectmode);
            _iconLookup.Add(Enum.shaded, shaded);
            _reverseIconLookup.Add(shaded, Enum.shaded);
            _iconLookup.Add(Enum.shadedwireframe, shadedwireframe);
            _reverseIconLookup.Add(shadedwireframe, Enum.shadedwireframe);
            _iconLookup.Add(Enum.wireframe, wireframe);
            _reverseIconLookup.Add(wireframe, Enum.wireframe);
            _iconLookup.Add(Enum.toolhandlecenter, toolhandlecenter);
            _reverseIconLookup.Add(toolhandlecenter, Enum.toolhandlecenter);
            _iconLookup.Add(Enum.toolhandleglobal, toolhandleglobal);
            _reverseIconLookup.Add(toolhandleglobal, Enum.toolhandleglobal);
            _iconLookup.Add(Enum.toolhandlelocal, toolhandlelocal);
            _reverseIconLookup.Add(toolhandlelocal, Enum.toolhandlelocal);
            _iconLookup.Add(Enum.toolhandlepivot, toolhandlepivot);
            _reverseIconLookup.Add(toolhandlepivot, Enum.toolhandlepivot);
            _iconLookup.Add(Enum.toolsicon, toolsicon);
            _reverseIconLookup.Add(toolsicon, Enum.toolsicon);
            _iconLookup.Add(Enum.tranp, tranp);
            _reverseIconLookup.Add(tranp, Enum.tranp);
            _iconLookup.Add(Enum.transformtool_on, transformtool_on);
            _reverseIconLookup.Add(transformtool_on, Enum.transformtool_on);
            _iconLookup.Add(Enum.transformtool, transformtool);
            _reverseIconLookup.Add(transformtool, Enum.transformtool);
            _iconLookup.Add(Enum.tree_icon_branch, tree_icon_branch);
            _reverseIconLookup.Add(tree_icon_branch, Enum.tree_icon_branch);
            _iconLookup.Add(Enum.tree_icon_branch_frond, tree_icon_branch_frond);
            _reverseIconLookup.Add(tree_icon_branch_frond, Enum.tree_icon_branch_frond);
            _iconLookup.Add(Enum.tree_icon_frond, tree_icon_frond);
            _reverseIconLookup.Add(tree_icon_frond, Enum.tree_icon_frond);
            _iconLookup.Add(Enum.tree_icon_leaf, tree_icon_leaf);
            _reverseIconLookup.Add(tree_icon_leaf, Enum.tree_icon_leaf);
            _iconLookup.Add(Enum.treeeditor_addbranches, treeeditor_addbranches);
            _reverseIconLookup.Add(treeeditor_addbranches, Enum.treeeditor_addbranches);
            _iconLookup.Add(Enum.treeeditor_addleaves, treeeditor_addleaves);
            _reverseIconLookup.Add(treeeditor_addleaves, Enum.treeeditor_addleaves);
            _iconLookup.Add(Enum.treeeditor_branch_on, treeeditor_branch_on);
            _reverseIconLookup.Add(treeeditor_branch_on, Enum.treeeditor_branch_on);
            _iconLookup.Add(Enum.treeeditor_branch, treeeditor_branch);
            _reverseIconLookup.Add(treeeditor_branch, Enum.treeeditor_branch);
            _iconLookup.Add(Enum.treeeditor_branchfreehand_on, treeeditor_branchfreehand_on);
            _reverseIconLookup.Add(treeeditor_branchfreehand_on, Enum.treeeditor_branchfreehand_on);
            _iconLookup.Add(Enum.treeeditor_branchfreehand, treeeditor_branchfreehand);
            _reverseIconLookup.Add(treeeditor_branchfreehand, Enum.treeeditor_branchfreehand);
            _iconLookup.Add(Enum.treeeditor_branchrotate_on, treeeditor_branchrotate_on);
            _reverseIconLookup.Add(treeeditor_branchrotate_on, Enum.treeeditor_branchrotate_on);
            _iconLookup.Add(Enum.treeeditor_branchrotate, treeeditor_branchrotate);
            _reverseIconLookup.Add(treeeditor_branchrotate, Enum.treeeditor_branchrotate);
            _iconLookup.Add(Enum.treeeditor_branchscale_on, treeeditor_branchscale_on);
            _reverseIconLookup.Add(treeeditor_branchscale_on, Enum.treeeditor_branchscale_on);
            _iconLookup.Add(Enum.treeeditor_branchscale, treeeditor_branchscale);
            _reverseIconLookup.Add(treeeditor_branchscale, Enum.treeeditor_branchscale);
            _iconLookup.Add(Enum.treeeditor_branchtranslate_on, treeeditor_branchtranslate_on);
            _reverseIconLookup.Add(treeeditor_branchtranslate_on, Enum.treeeditor_branchtranslate_on);
            _iconLookup.Add(Enum.treeeditor_branchtranslate, treeeditor_branchtranslate);
            _reverseIconLookup.Add(treeeditor_branchtranslate, Enum.treeeditor_branchtranslate);
            _iconLookup.Add(Enum.treeeditor_distribution_on, treeeditor_distribution_on);
            _reverseIconLookup.Add(treeeditor_distribution_on, Enum.treeeditor_distribution_on);
            _iconLookup.Add(Enum.treeeditor_distribution, treeeditor_distribution);
            _reverseIconLookup.Add(treeeditor_distribution, Enum.treeeditor_distribution);
            _iconLookup.Add(Enum.treeeditor_duplicate, treeeditor_duplicate);
            _reverseIconLookup.Add(treeeditor_duplicate, Enum.treeeditor_duplicate);
            _iconLookup.Add(Enum.treeeditor_geometry_on, treeeditor_geometry_on);
            _reverseIconLookup.Add(treeeditor_geometry_on, Enum.treeeditor_geometry_on);
            _iconLookup.Add(Enum.treeeditor_geometry, treeeditor_geometry);
            _reverseIconLookup.Add(treeeditor_geometry, Enum.treeeditor_geometry);
            _iconLookup.Add(Enum.treeeditor_leaf_on, treeeditor_leaf_on);
            _reverseIconLookup.Add(treeeditor_leaf_on, Enum.treeeditor_leaf_on);
            _iconLookup.Add(Enum.treeeditor_leaf, treeeditor_leaf);
            _reverseIconLookup.Add(treeeditor_leaf, Enum.treeeditor_leaf);
            _iconLookup.Add(Enum.treeeditor_leaffreehand_on, treeeditor_leaffreehand_on);
            _reverseIconLookup.Add(treeeditor_leaffreehand_on, Enum.treeeditor_leaffreehand_on);
            _iconLookup.Add(Enum.treeeditor_leaffreehand, treeeditor_leaffreehand);
            _reverseIconLookup.Add(treeeditor_leaffreehand, Enum.treeeditor_leaffreehand);
            _iconLookup.Add(Enum.treeeditor_leafrotate_on, treeeditor_leafrotate_on);
            _reverseIconLookup.Add(treeeditor_leafrotate_on, Enum.treeeditor_leafrotate_on);
            _iconLookup.Add(Enum.treeeditor_leafrotate, treeeditor_leafrotate);
            _reverseIconLookup.Add(treeeditor_leafrotate, Enum.treeeditor_leafrotate);
            _iconLookup.Add(Enum.treeeditor_leafscale_on, treeeditor_leafscale_on);
            _reverseIconLookup.Add(treeeditor_leafscale_on, Enum.treeeditor_leafscale_on);
            _iconLookup.Add(Enum.treeeditor_leafscale, treeeditor_leafscale);
            _reverseIconLookup.Add(treeeditor_leafscale, Enum.treeeditor_leafscale);
            _iconLookup.Add(Enum.treeeditor_leaftranslate_on, treeeditor_leaftranslate_on);
            _reverseIconLookup.Add(treeeditor_leaftranslate_on, Enum.treeeditor_leaftranslate_on);
            _iconLookup.Add(Enum.treeeditor_leaftranslate, treeeditor_leaftranslate);
            _reverseIconLookup.Add(treeeditor_leaftranslate, Enum.treeeditor_leaftranslate);
            _iconLookup.Add(Enum.treeeditor_material_on, treeeditor_material_on);
            _reverseIconLookup.Add(treeeditor_material_on, Enum.treeeditor_material_on);
            _iconLookup.Add(Enum.treeeditor_material, treeeditor_material);
            _reverseIconLookup.Add(treeeditor_material, Enum.treeeditor_material);
            _iconLookup.Add(Enum.treeeditor_refresh, treeeditor_refresh);
            _reverseIconLookup.Add(treeeditor_refresh, Enum.treeeditor_refresh);
            _iconLookup.Add(Enum.treeeditor_trash, treeeditor_trash);
            _reverseIconLookup.Add(treeeditor_trash, Enum.treeeditor_trash);
            _iconLookup.Add(Enum.treeeditor_wind_on, treeeditor_wind_on);
            _reverseIconLookup.Add(treeeditor_wind_on, Enum.treeeditor_wind_on);
            _iconLookup.Add(Enum.treeeditor_wind, treeeditor_wind);
            _reverseIconLookup.Add(treeeditor_wind, Enum.treeeditor_wind);
            _iconLookup.Add(Enum.unityeditor_animationwindow, unityeditor_animationwindow);
            _reverseIconLookup.Add(unityeditor_animationwindow, Enum.unityeditor_animationwindow);
            _iconLookup.Add(Enum.unityeditor_consolewindow, unityeditor_consolewindow);
            _reverseIconLookup.Add(unityeditor_consolewindow, Enum.unityeditor_consolewindow);
            _iconLookup.Add(Enum.unityeditor_debuginspectorwindow, unityeditor_debuginspectorwindow);
            _reverseIconLookup.Add(unityeditor_debuginspectorwindow, Enum.unityeditor_debuginspectorwindow);
            _iconLookup.Add(Enum.unityeditor_devicesimulation_simulatorwindow, unityeditor_devicesimulation_simulatorwindow);
            _reverseIconLookup.Add(unityeditor_devicesimulation_simulatorwindow, Enum.unityeditor_devicesimulation_simulatorwindow);
            _iconLookup.Add(Enum.unityeditor_finddependencies, unityeditor_finddependencies);
            _reverseIconLookup.Add(unityeditor_finddependencies, Enum.unityeditor_finddependencies);
            _iconLookup.Add(Enum.unityeditor_gameview, unityeditor_gameview);
            _reverseIconLookup.Add(unityeditor_gameview, Enum.unityeditor_gameview);
            _iconLookup.Add(Enum.unityeditor_graphs_animatorcontrollertool, unityeditor_graphs_animatorcontrollertool);
            _reverseIconLookup.Add(unityeditor_graphs_animatorcontrollertool, Enum.unityeditor_graphs_animatorcontrollertool);
            _iconLookup.Add(Enum.unityeditor_hierarchywindow, unityeditor_hierarchywindow);
            _reverseIconLookup.Add(unityeditor_hierarchywindow, Enum.unityeditor_hierarchywindow);
            _iconLookup.Add(Enum.unityeditor_inspectorwindow, unityeditor_inspectorwindow);
            _reverseIconLookup.Add(unityeditor_inspectorwindow, Enum.unityeditor_inspectorwindow);
            _iconLookup.Add(Enum.unityeditor_profilerwindow, unityeditor_profilerwindow);
            _reverseIconLookup.Add(unityeditor_profilerwindow, Enum.unityeditor_profilerwindow);
            _iconLookup.Add(Enum.unityeditor_scenehierarchywindow, unityeditor_scenehierarchywindow);
            _reverseIconLookup.Add(unityeditor_scenehierarchywindow, Enum.unityeditor_scenehierarchywindow);
            _iconLookup.Add(Enum.unityeditor_sceneview, unityeditor_sceneview);
            _reverseIconLookup.Add(unityeditor_sceneview, Enum.unityeditor_sceneview);
            _iconLookup.Add(Enum.unityeditor_timeline_timelinewindow, unityeditor_timeline_timelinewindow);
            _reverseIconLookup.Add(unityeditor_timeline_timelinewindow, Enum.unityeditor_timeline_timelinewindow);
            _iconLookup.Add(Enum.unityeditor_versioncontrol, unityeditor_versioncontrol);
            _reverseIconLookup.Add(unityeditor_versioncontrol, Enum.unityeditor_versioncontrol);
            _iconLookup.Add(Enum.unitylogo, unitylogo);
            _reverseIconLookup.Add(unitylogo, Enum.unitylogo);
            _iconLookup.Add(Enum.unitylogolarge, unitylogolarge);
            _reverseIconLookup.Add(unitylogolarge, Enum.unitylogolarge);
            _iconLookup.Add(Enum.unlinked, unlinked);
            _reverseIconLookup.Add(unlinked, Enum.unlinked);
            _iconLookup.Add(Enum.uparrow, uparrow);
            _reverseIconLookup.Add(uparrow, Enum.uparrow);
            _iconLookup.Add(Enum.valid, valid);
            _reverseIconLookup.Add(valid, Enum.valid);
            _iconLookup.Add(Enum.d_file, d_file);
            _reverseIconLookup.Add(d_file, Enum.d_file);
            _iconLookup.Add(Enum.d_incoming_icon, d_incoming_icon);
            _reverseIconLookup.Add(d_incoming_icon, Enum.d_incoming_icon);
            _iconLookup.Add(Enum.d_p4_addedlocal, d_p4_addedlocal);
            _reverseIconLookup.Add(d_p4_addedlocal, Enum.d_p4_addedlocal);
            _iconLookup.Add(Enum.d_p4_addedremote, d_p4_addedremote);
            _reverseIconLookup.Add(d_p4_addedremote, Enum.d_p4_addedremote);
            _iconLookup.Add(Enum.d_p4_blueleftparenthesis, d_p4_blueleftparenthesis);
            _reverseIconLookup.Add(d_p4_blueleftparenthesis, Enum.d_p4_blueleftparenthesis);
            _iconLookup.Add(Enum.d_p4_bluerightparenthesis, d_p4_bluerightparenthesis);
            _reverseIconLookup.Add(d_p4_bluerightparenthesis, Enum.d_p4_bluerightparenthesis);
            _iconLookup.Add(Enum.d_p4_checkoutlocal, d_p4_checkoutlocal);
            _reverseIconLookup.Add(d_p4_checkoutlocal, Enum.d_p4_checkoutlocal);
            _iconLookup.Add(Enum.d_p4_checkoutremote, d_p4_checkoutremote);
            _reverseIconLookup.Add(d_p4_checkoutremote, Enum.d_p4_checkoutremote);
            _iconLookup.Add(Enum.d_p4_conflicted, d_p4_conflicted);
            _reverseIconLookup.Add(d_p4_conflicted, Enum.d_p4_conflicted);
            _iconLookup.Add(Enum.d_p4_deletedlocal, d_p4_deletedlocal);
            _reverseIconLookup.Add(d_p4_deletedlocal, Enum.d_p4_deletedlocal);
            _iconLookup.Add(Enum.d_p4_deletedremote, d_p4_deletedremote);
            _reverseIconLookup.Add(d_p4_deletedremote, Enum.d_p4_deletedremote);
            _iconLookup.Add(Enum.d_p4_local, d_p4_local);
            _reverseIconLookup.Add(d_p4_local, Enum.d_p4_local);
            _iconLookup.Add(Enum.d_p4_lockedlocal, d_p4_lockedlocal);
            _reverseIconLookup.Add(d_p4_lockedlocal, Enum.d_p4_lockedlocal);
            _iconLookup.Add(Enum.d_p4_lockedremote, d_p4_lockedremote);
            _reverseIconLookup.Add(d_p4_lockedremote, Enum.d_p4_lockedremote);
            _iconLookup.Add(Enum.d_p4_offline, d_p4_offline);
            _reverseIconLookup.Add(d_p4_offline, Enum.d_p4_offline);
            _iconLookup.Add(Enum.d_p4_outofsync, d_p4_outofsync);
            _reverseIconLookup.Add(d_p4_outofsync, Enum.d_p4_outofsync);
            _iconLookup.Add(Enum.d_p4_redleftparenthesis, d_p4_redleftparenthesis);
            _reverseIconLookup.Add(d_p4_redleftparenthesis, Enum.d_p4_redleftparenthesis);
            _iconLookup.Add(Enum.d_p4_redrightparenthesis, d_p4_redrightparenthesis);
            _reverseIconLookup.Add(d_p4_redrightparenthesis, Enum.d_p4_redrightparenthesis);
            _iconLookup.Add(Enum.d_p4_updating, d_p4_updating);
            _reverseIconLookup.Add(d_p4_updating, Enum.d_p4_updating);
            _iconLookup.Add(Enum.file, file);
            _reverseIconLookup.Add(file, Enum.file);
            _iconLookup.Add(Enum.incoming_icon, incoming_icon);
            _reverseIconLookup.Add(incoming_icon, Enum.incoming_icon);
            _iconLookup.Add(Enum.incoming_on_icon, incoming_on_icon);
            _reverseIconLookup.Add(incoming_on_icon, Enum.incoming_on_icon);
            _iconLookup.Add(Enum.outgoing_icon, outgoing_icon);
            _reverseIconLookup.Add(outgoing_icon, Enum.outgoing_icon);
            _iconLookup.Add(Enum.p4_addedlocal, p4_addedlocal);
            _reverseIconLookup.Add(p4_addedlocal, Enum.p4_addedlocal);
            _iconLookup.Add(Enum.p4_addedremote, p4_addedremote);
            _reverseIconLookup.Add(p4_addedremote, Enum.p4_addedremote);
            _iconLookup.Add(Enum.p4_blueleftparenthesis, p4_blueleftparenthesis);
            _reverseIconLookup.Add(p4_blueleftparenthesis, Enum.p4_blueleftparenthesis);
            _iconLookup.Add(Enum.p4_bluerightparenthesis, p4_bluerightparenthesis);
            _reverseIconLookup.Add(p4_bluerightparenthesis, Enum.p4_bluerightparenthesis);
            _iconLookup.Add(Enum.p4_checkoutlocal, p4_checkoutlocal);
            _reverseIconLookup.Add(p4_checkoutlocal, Enum.p4_checkoutlocal);
            _iconLookup.Add(Enum.p4_checkoutremote, p4_checkoutremote);
            _reverseIconLookup.Add(p4_checkoutremote, Enum.p4_checkoutremote);
            _iconLookup.Add(Enum.p4_conflicted, p4_conflicted);
            _reverseIconLookup.Add(p4_conflicted, Enum.p4_conflicted);
            _iconLookup.Add(Enum.p4_deletedlocal, p4_deletedlocal);
            _reverseIconLookup.Add(p4_deletedlocal, Enum.p4_deletedlocal);
            _iconLookup.Add(Enum.p4_deletedremote, p4_deletedremote);
            _reverseIconLookup.Add(p4_deletedremote, Enum.p4_deletedremote);
            _iconLookup.Add(Enum.p4_local, p4_local);
            _reverseIconLookup.Add(p4_local, Enum.p4_local);
            _iconLookup.Add(Enum.p4_lockedlocal, p4_lockedlocal);
            _reverseIconLookup.Add(p4_lockedlocal, Enum.p4_lockedlocal);
            _iconLookup.Add(Enum.p4_lockedremote, p4_lockedremote);
            _reverseIconLookup.Add(p4_lockedremote, Enum.p4_lockedremote);
            _iconLookup.Add(Enum.p4_offline, p4_offline);
            _reverseIconLookup.Add(p4_offline, Enum.p4_offline);
            _iconLookup.Add(Enum.p4_outofsync, p4_outofsync);
            _reverseIconLookup.Add(p4_outofsync, Enum.p4_outofsync);
            _iconLookup.Add(Enum.p4_redleftparenthesis, p4_redleftparenthesis);
            _reverseIconLookup.Add(p4_redleftparenthesis, Enum.p4_redleftparenthesis);
            _iconLookup.Add(Enum.p4_redrightparenthesis, p4_redrightparenthesis);
            _reverseIconLookup.Add(p4_redrightparenthesis, Enum.p4_redrightparenthesis);
            _iconLookup.Add(Enum.p4_updating, p4_updating);
            _reverseIconLookup.Add(p4_updating, Enum.p4_updating);
            _iconLookup.Add(Enum.verticalsplit, verticalsplit);
            _reverseIconLookup.Add(verticalsplit, Enum.verticalsplit);
            _iconLookup.Add(Enum.viewtoolmove_on, viewtoolmove_on);
            _reverseIconLookup.Add(viewtoolmove_on, Enum.viewtoolmove_on);
            _iconLookup.Add(Enum.viewtoolmove, viewtoolmove);
            _reverseIconLookup.Add(viewtoolmove, Enum.viewtoolmove);
            _iconLookup.Add(Enum.viewtoolorbit_on, viewtoolorbit_on);
            _reverseIconLookup.Add(viewtoolorbit_on, Enum.viewtoolorbit_on);
            _iconLookup.Add(Enum.viewtoolorbit, viewtoolorbit);
            _reverseIconLookup.Add(viewtoolorbit, Enum.viewtoolorbit);
            _iconLookup.Add(Enum.viewtoolzoom_on, viewtoolzoom_on);
            _reverseIconLookup.Add(viewtoolzoom_on, Enum.viewtoolzoom_on);
            _iconLookup.Add(Enum.viewtoolzoom, viewtoolzoom);
            _reverseIconLookup.Add(viewtoolzoom, Enum.viewtoolzoom);
            _iconLookup.Add(Enum.visibilityoff, visibilityoff);
            _reverseIconLookup.Add(visibilityoff, Enum.visibilityoff);
            _iconLookup.Add(Enum.visibilityon, visibilityon);
            _reverseIconLookup.Add(visibilityon, Enum.visibilityon);
            _iconLookup.Add(Enum.vumetertexturehorizontal, vumetertexturehorizontal);
            _reverseIconLookup.Add(vumetertexturehorizontal, Enum.vumetertexturehorizontal);
            _iconLookup.Add(Enum.vumetertexturevertical, vumetertexturevertical);
            _reverseIconLookup.Add(vumetertexturevertical, Enum.vumetertexturevertical);
            _iconLookup.Add(Enum.waitspin00, waitspin00);
            _reverseIconLookup.Add(waitspin00, Enum.waitspin00);
            _iconLookup.Add(Enum.waitspin01, waitspin01);
            _reverseIconLookup.Add(waitspin01, Enum.waitspin01);
            _iconLookup.Add(Enum.waitspin02, waitspin02);
            _reverseIconLookup.Add(waitspin02, Enum.waitspin02);
            _iconLookup.Add(Enum.waitspin03, waitspin03);
            _reverseIconLookup.Add(waitspin03, Enum.waitspin03);
            _iconLookup.Add(Enum.waitspin04, waitspin04);
            _reverseIconLookup.Add(waitspin04, Enum.waitspin04);
            _iconLookup.Add(Enum.waitspin05, waitspin05);
            _reverseIconLookup.Add(waitspin05, Enum.waitspin05);
            _iconLookup.Add(Enum.waitspin06, waitspin06);
            _reverseIconLookup.Add(waitspin06, Enum.waitspin06);
            _iconLookup.Add(Enum.waitspin07, waitspin07);
            _reverseIconLookup.Add(waitspin07, Enum.waitspin07);
            _iconLookup.Add(Enum.waitspin08, waitspin08);
            _reverseIconLookup.Add(waitspin08, Enum.waitspin08);
            _iconLookup.Add(Enum.waitspin09, waitspin09);
            _reverseIconLookup.Add(waitspin09, Enum.waitspin09);
            _iconLookup.Add(Enum.waitspin10, waitspin10);
            _reverseIconLookup.Add(waitspin10, Enum.waitspin10);
            _iconLookup.Add(Enum.waitspin11, waitspin11);
            _reverseIconLookup.Add(waitspin11, Enum.waitspin11);
            _iconLookup.Add(Enum.welcomescreen_assetstorelogo, welcomescreen_assetstorelogo);
            _reverseIconLookup.Add(welcomescreen_assetstorelogo, Enum.welcomescreen_assetstorelogo);
            _iconLookup.Add(Enum.winbtn_graph, winbtn_graph);
            _reverseIconLookup.Add(winbtn_graph, Enum.winbtn_graph);
            _iconLookup.Add(Enum.winbtn_graph_close_h, winbtn_graph_close_h);
            _reverseIconLookup.Add(winbtn_graph_close_h, Enum.winbtn_graph_close_h);
            _iconLookup.Add(Enum.winbtn_graph_max_h, winbtn_graph_max_h);
            _reverseIconLookup.Add(winbtn_graph_max_h, Enum.winbtn_graph_max_h);
            _iconLookup.Add(Enum.winbtn_graph_min_h, winbtn_graph_min_h);
            _reverseIconLookup.Add(winbtn_graph_min_h, Enum.winbtn_graph_min_h);
            _iconLookup.Add(Enum.winbtn_mac_close, winbtn_mac_close);
            _reverseIconLookup.Add(winbtn_mac_close, Enum.winbtn_mac_close);
            _iconLookup.Add(Enum.winbtn_mac_close_a, winbtn_mac_close_a);
            _reverseIconLookup.Add(winbtn_mac_close_a, Enum.winbtn_mac_close_a);
            _iconLookup.Add(Enum.winbtn_mac_close_h, winbtn_mac_close_h);
            _reverseIconLookup.Add(winbtn_mac_close_h, Enum.winbtn_mac_close_h);
            _iconLookup.Add(Enum.winbtn_mac_inact, winbtn_mac_inact);
            _reverseIconLookup.Add(winbtn_mac_inact, Enum.winbtn_mac_inact);
            _iconLookup.Add(Enum.winbtn_mac_max, winbtn_mac_max);
            _reverseIconLookup.Add(winbtn_mac_max, Enum.winbtn_mac_max);
            _iconLookup.Add(Enum.winbtn_mac_max_a, winbtn_mac_max_a);
            _reverseIconLookup.Add(winbtn_mac_max_a, Enum.winbtn_mac_max_a);
            _iconLookup.Add(Enum.winbtn_mac_max_h, winbtn_mac_max_h);
            _reverseIconLookup.Add(winbtn_mac_max_h, Enum.winbtn_mac_max_h);
            _iconLookup.Add(Enum.winbtn_mac_min, winbtn_mac_min);
            _reverseIconLookup.Add(winbtn_mac_min, Enum.winbtn_mac_min);
            _iconLookup.Add(Enum.winbtn_mac_min_a, winbtn_mac_min_a);
            _reverseIconLookup.Add(winbtn_mac_min_a, Enum.winbtn_mac_min_a);
            _iconLookup.Add(Enum.winbtn_mac_min_h, winbtn_mac_min_h);
            _reverseIconLookup.Add(winbtn_mac_min_h, Enum.winbtn_mac_min_h);
            _iconLookup.Add(Enum.winbtn_win_close, winbtn_win_close);
            _reverseIconLookup.Add(winbtn_win_close, Enum.winbtn_win_close);
            _iconLookup.Add(Enum.winbtn_win_close_a, winbtn_win_close_a);
            _reverseIconLookup.Add(winbtn_win_close_a, Enum.winbtn_win_close_a);
            _iconLookup.Add(Enum.winbtn_win_close_h, winbtn_win_close_h);
            _reverseIconLookup.Add(winbtn_win_close_h, Enum.winbtn_win_close_h);
            _iconLookup.Add(Enum.winbtn_win_max, winbtn_win_max);
            _reverseIconLookup.Add(winbtn_win_max, Enum.winbtn_win_max);
            _iconLookup.Add(Enum.winbtn_win_max_a, winbtn_win_max_a);
            _reverseIconLookup.Add(winbtn_win_max_a, Enum.winbtn_win_max_a);
            _iconLookup.Add(Enum.winbtn_win_max_h, winbtn_win_max_h);
            _reverseIconLookup.Add(winbtn_win_max_h, Enum.winbtn_win_max_h);
            _iconLookup.Add(Enum.winbtn_win_min, winbtn_win_min);
            _reverseIconLookup.Add(winbtn_win_min, Enum.winbtn_win_min);
            _iconLookup.Add(Enum.winbtn_win_min_a, winbtn_win_min_a);
            _reverseIconLookup.Add(winbtn_win_min_a, Enum.winbtn_win_min_a);
            _iconLookup.Add(Enum.winbtn_win_min_h, winbtn_win_min_h);
            _reverseIconLookup.Add(winbtn_win_min_h, Enum.winbtn_win_min_h);
            _iconLookup.Add(Enum.winbtn_win_rest, winbtn_win_rest);
            _reverseIconLookup.Add(winbtn_win_rest, Enum.winbtn_win_rest);
            _iconLookup.Add(Enum.winbtn_win_rest_a, winbtn_win_rest_a);
            _reverseIconLookup.Add(winbtn_win_rest_a, Enum.winbtn_win_rest_a);
            _iconLookup.Add(Enum.winbtn_win_rest_h, winbtn_win_rest_h);
            _reverseIconLookup.Add(winbtn_win_rest_h, Enum.winbtn_win_rest_h);
            _iconLookup.Add(Enum.winbtn_win_restore, winbtn_win_restore);
            _reverseIconLookup.Add(winbtn_win_restore, Enum.winbtn_win_restore);
            _iconLookup.Add(Enum.winbtn_win_restore_a, winbtn_win_restore_a);
            _reverseIconLookup.Add(winbtn_win_restore_a, Enum.winbtn_win_restore_a);
            _iconLookup.Add(Enum.winbtn_win_restore_h, winbtn_win_restore_h);
            _reverseIconLookup.Add(winbtn_win_restore_h, Enum.winbtn_win_restore_h);

        }
#endif

#endregion

#region Methods

        public static GUIContent GetIconContent(Enum icon)
        {
#if UNITY_EDITOR
            return UnityEditor.EditorGUIUtility.IconContent(_iconLookup[icon]);
#else
        return GUIContent.none;
#endif
        }

        public static GUIContent GetIconContent(Enum icon, string tooltip)
        {
#if UNITY_EDITOR
            return UnityEditor.EditorGUIUtility.IconContent(_iconLookup[icon], tooltip);
#else
        return GUIContent.none;
#endif
        }

        public static GUIContent GetIconContent(string iconName)
        {
#if UNITY_EDITOR
            return UnityEditor.EditorGUIUtility.IconContent(iconName);
#else
        return GUIContent.none;
#endif
        }

        public static GUIContent GetIconContent(string iconName, string tooltip)
        {
#if UNITY_EDITOR
            return UnityEditor.EditorGUIUtility.IconContent(iconName, tooltip);
#else
        return GUIContent.none;
#endif
        }

        public static string GetIconName(Enum icon)
        {
#if UNITY_EDITOR
            return _iconLookup[icon];
#else
        return null;
#endif
        }

        public static Enum GetIconEnum(string name)
        {
#if UNITY_EDITOR
            return _reverseIconLookup[name];
#else
        return default;
#endif
        }

#endregion

#region UI


#if UNITY_EDITOR
        public class EditorGUIIconViewer : EditorWindow
        {
#region UI Constants

            private const string _headerText = "EditorGUI Icons";

            private const string _subheaderText = "Build Version: " +
                                                  BUILD_VERSION +
                                                  " | Icon Count: " +
                                                  VALUE_COUNT_STRING;

            private const string _settingsText = "Display Settings";
            private const string _searchText = "Search (RegEx)";
            private const string _selectedIconText = "Selected Icon Name";
            private const string _buttonTextPadding = "  ";

            private static readonly Color lineColor = new(.22f, .22f, .22f, 1f);

            private const int _defaultIconSize = 32;
            private const int _iconPadding = 1;
            private const float _paddingMultiplier = 3f;
            private const int _reservedSpace = 15;
            private const float _verticalSpacer = 8f;
            private const float _horizontalSpacer = 4f;
            private const float _selectionSize = 1f;
            private const int _buttonIconSize = 16;
            private const float _iconSizeLabelSize = 60f;
            private const float _iconBackgroundLabelSize = 110f;
            private const float _iconSelectedBackgroundLabelSize = 120f;
            private const float _searchLabelSize = 120f;
            private const float _regexLabelSize = 18f;
            private const float _selectedIconLabelSize = 130f;

#endregion

#region Icons

            private const string _regenerateButtonIconName = "sceneviewtools on";
            private const string _resetButtonIconName = "grid.erasertool";
            private const string _searchIconName = "searchoverlay";
            private const string _settingsIconName = "settings";
            private const string _regexValidIconName = "p4_checkoutremote";
            private const string _regexInvalidIconName = "p4_deletedlocal";
            private const string _regexMissingIconName = "testignored";

#endregion

#region State

            private static Enum[] _enums;
            private static string[] _iconNames;
            private static GUIContent[] _icons;

#endregion

#region UI State

            private string _searchFilter = "";
            private Color _backgroundColor = new(0.1647059f, 0.1647059f, 0.1647059f, 1f);
            private Color _selectedBackgroundColor = new(0f, 1f, 0f, .7f);
            private int _iconSize = _defaultIconSize;
            private bool _showSettings;

            private RegexState _regexState;
            private Vector2 _scrollPosition;

            private Color _lastBackgroundColor;
            private int _lastIconSize;
            private string _lastSelection = "";
            private GUIContent _lastSelectionContent;

#endregion

#region Layout

#region Fields

            private static readonly GUILayoutOption[] _expandWidth = {GUILayout.ExpandWidth(true)};
            private GUILayoutOption[] _iconLayout = {GUILayout.Width(_defaultIconSize)};
            private GUILayoutOption[] _iconSizeLabelLayout = {GUILayout.Width(_iconSizeLabelSize)};
            private GUILayoutOption[] _regexIconLayout = {GUILayout.Width(_regexLabelSize)};
            private GUILayoutOption[] _searchLabelLayout = {GUILayout.Width(_searchLabelSize)};

            private GUILayoutOption[] _iconBackgroundLabelLayout =
            {
                GUILayout.Width(_iconBackgroundLabelSize)
            };

            private GUILayoutOption[] _iconSelectedBackgroundLabelLayout =
            {
                GUILayout.Width(_iconSelectedBackgroundLabelSize)
            };

            private GUILayoutOption[] _selectedIconLabelLayout =
            {
                GUILayout.Width(_selectedIconLabelSize)
            };

#endregion

#region Properties

            private GUILayoutOption[] iconSizeLabelLayout
            {
                get
                {
                    if (_iconSizeLabelLayout == null)
                    {
                        _iconSizeLabelLayout = new[] {GUILayout.Width(_iconSizeLabelSize)};
                    }

                    return _iconSizeLabelLayout;
                }
            }

            private GUILayoutOption[] iconBackgroundLabelLayout
            {
                get
                {
                    if (_iconBackgroundLabelLayout == null)
                    {
                        _iconBackgroundLabelLayout = new[] {GUILayout.Width(_iconBackgroundLabelSize)};
                    }

                    return _iconBackgroundLabelLayout;
                }
            }

            private GUILayoutOption[] iconSelectedBackgroundLabelLayout
            {
                get
                {
                    if (_iconSelectedBackgroundLabelLayout == null)
                    {
                        _iconSelectedBackgroundLabelLayout = new[]
                        {
                            GUILayout.Width(_iconSelectedBackgroundLabelSize)
                        };
                    }

                    return _iconSelectedBackgroundLabelLayout;
                }
            }

            private GUILayoutOption[] searchLabelLayout
            {
                get
                {
                    if (_searchLabelLayout == null)
                    {
                        _searchLabelLayout = new[] {GUILayout.Width(_searchLabelSize)};
                    }

                    return _searchLabelLayout;
                }
            }

            private GUILayoutOption[] regexIconLayout
            {
                get
                {
                    if (_regexIconLayout == null)
                    {
                        _regexIconLayout = new[] {GUILayout.Width(_regexLabelSize)};
                    }

                    return _regexIconLayout;
                }
            }

            private GUILayoutOption[] selectedIconLabelLayout
            {
                get
                {
                    if (_selectedIconLabelLayout == null)
                    {
                        _selectedIconLabelLayout = new[] {GUILayout.Width(_selectedIconLabelSize)};
                    }

                    return _selectedIconLabelLayout;
                }
            }

#endregion

#endregion

#region Style

#region Fields

            private GUIStyle _scrollViewStyle;
            private GUIStyle _iconStyle;
            private GUIStyle _regexIconStyle;

#endregion

#region Properties

            private GUIStyle scrollViewStyle
            {
                get
                {
                    if (_scrollViewStyle == null)
                    {
                        _scrollViewStyle = new GUIStyle(GUI.skin.scrollView)
                        {
                        };

                        _scrollViewStyle.normal.background = MakeTex(1, 1, _backgroundColor);
                    }

                    return _scrollViewStyle;
                }
            }
        
            private GUIStyle iconStyle
            {
                get
                {
                    if (_iconStyle == null)
                    {
                        _iconStyle = new GUIStyle
                        {
                            fixedWidth = _iconSize,
                            padding = new RectOffset(
                                _iconPadding,
                                _iconPadding,
                                _iconPadding,
                                _iconPadding
                            ),
                            border = new RectOffset(0, 0, 0, 0)
                        };
                    }

                    return _iconStyle;
                }
            }

            private GUIStyle regexIconStyle
            {
                get
                {
                    if (_regexIconStyle == null)
                    {
                        _regexIconStyle = new GUIStyle
                        {
                            fixedWidth = _regexLabelSize,
                            padding = new RectOffset(
                                _iconPadding,
                                _iconPadding,
                                _iconPadding,
                                _iconPadding
                            ),
                            border = new RectOffset(0, 0, 0, 0)
                        };
                    }

                    return _regexIconStyle;
                }
            }

#endregion

#endregion

#region Content

#region Fields

            private GUIContent _regenerateButtonContent;
            private GUIContent _resetButtonContent;
            private GUIContent _settingsLabel;
            private GUIContent _searchLabel;
            private GUIContent _regexInvalidLabel;
            private GUIContent _regexMissingLabel;
            private GUIContent _regexValidLabel;
            private GUIContent _selectedIconLabel;

#endregion

#region Properties

            private GUIContent regenerateButtonContent
            {
                get
                {
                    if (_regenerateButtonContent == null)
                    {
                        var regenerateButtonIcon = GetIconEnum(_regenerateButtonIconName);
                        _regenerateButtonContent = GetIconContent(regenerateButtonIcon);

                        _regenerateButtonContent.text = _buttonTextPadding +
                                                        EditorGUIIconGenerator.regenerateButtonText;
                    }

                    return _regenerateButtonContent;
                }
            }

            private GUIContent resetButtonContent
            {
                get
                {
                    if (_resetButtonContent == null)
                    {
                        var resetButtonIcon = GetIconEnum(_resetButtonIconName);
                        _resetButtonContent = GetIconContent(resetButtonIcon);

                        _resetButtonContent.text =
                            _buttonTextPadding + EditorGUIIconGenerator.resetButtonText;
                    }

                    return _resetButtonContent;
                }
            }

            public GUIContent settingsLabel
            {
                get
                {
                    if (_settingsLabel == null)
                    {
                        var settingsButtonIcon = GetIconEnum(_settingsIconName);
                        _settingsLabel = GetIconContent(settingsButtonIcon);

                        _settingsLabel.text = _buttonTextPadding + _settingsText;
                    }

                    return _settingsLabel;
                }
            }

            public GUIContent searchLabel
            {
                get
                {
                    if (_searchLabel == null)
                    {
                        var searchButtonIcon = GetIconEnum(_searchIconName);
                        _searchLabel = GetIconContent(searchButtonIcon);

                        _searchLabel.text = _buttonTextPadding + _searchText;
                    }

                    return _searchLabel;
                }
            }

            public GUIContent regexValidLabel
            {
                get
                {
                    if (_regexValidLabel == null)
                    {
                        _regexValidLabel = new GUIContent(GetIconContent(_regexValidIconName));
                    }

                    return _regexValidLabel;
                }
            }

            public GUIContent regexInvalidLabel
            {
                get
                {
                    if (_regexInvalidLabel == null)
                    {
                        _regexInvalidLabel = new GUIContent(GetIconContent(_regexInvalidIconName));
                    }

                    return _regexInvalidLabel;
                }
            }

            public GUIContent regexMissingLabel
            {
                get
                {
                    if (_regexMissingLabel == null)
                    {
                        _regexMissingLabel = new GUIContent(GetIconContent(_regexMissingIconName));
                    }

                    return _regexMissingLabel;
                }
            }

            public GUIContent selectedIconLabel
            {
                get
                {
                    if (_selectedIconLabel == null)
                    {
                        _selectedIconLabel = new GUIContent(_selectedIconText);
                    }

                    return _selectedIconLabel;
                }
            }

            public GUIContent lastSelectionContent
            {
                get
                {
                    if (_lastSelectionContent == null)
                    {
                        _lastSelectionContent = new GUIContent(string.Empty);
                    }

                    return _lastSelectionContent;
                }
            }

#endregion

#endregion

#region Editor Window API

            private void OnEnable()
            {
                if ((Application.unityVersion != BUILD_VERSION) || (VALUE_COUNT == 0))
                {
                    EditorGUIIconGenerator.RegenerateIconUtilities(true);
                    return;
                }

                _lastIconSize = 0;
                _lastBackgroundColor = new Color();

                minSize = new Vector2(640, 640);

                var sortEnumValues = System.Enum.GetValues(typeof(SortEnum));
                var sortEnumEnumerable = sortEnumValues.Cast<SortEnum>();
                var sortEnumArray = sortEnumEnumerable.ToArray();
                var sortEnums = sortEnumArray.ToDictionary(e => e.ToString());

                _enums = System.Enum.GetValues(typeof(Enum)).Cast<Enum>().ToArray();

                Array.Sort(
                    _enums,
                    (a, b) => sortEnums[a.ToString()].CompareTo(sortEnums[b.ToString()])
                );
                _icons = new GUIContent[_enums.Length];
                _iconNames = new string[_enums.Length];

                for (var i = 0; i < _enums.Length; i++)
                {
                    var e = _enums[i];
                    var iconName = GetIconName(e);

                    _iconNames[i] = iconName;
                    var content = GetIconContent(e, iconName);
                    content.tooltip = iconName;
                    _icons[i] = content;
                }
            }

            private void OnGUI()
            {
                Action drawButtons = () =>
                {
                    if (GUILayout.Button(regenerateButtonContent))
                    {
                        EditorGUIIconGenerator.RegenerateIconUtilities(true);
                    }

                    if (GUILayout.Button(resetButtonContent))
                    {
                        EditorGUIIconGenerator.ResetGeneratedIconUtilities();
                    }

                    EditorGUILayout.Space(_horizontalSpacer * 4, false);
                };


                DrawHeader(_headerText, _subheaderText, drawButtons);

                DrawSettings();

                EditorGUILayout.Space(_verticalSpacer, false);

                using (new EditorGUI.IndentLevelScope())
                {
                    DrawSearch();

                    DrawResult();

                    EditorGUILayout.Space(_verticalSpacer, false);
                    DrawIcons();
                }

                EditorGUILayout.Space(_verticalSpacer, false);

                if (GUILayout.Button("Close"))
                {
                    CloseWindow();
                }
            }

            private void CloseWindow()
            {
                Close();
                GUIUtility.ExitGUI();
            }

#endregion

#region UI Menu Items

            [MenuItem("Tools/EditorGUI Icons/Explore", false, 22)]
            internal static void ExploreEditorGUIIcons()
            {
                GetWindow<EditorGUIIconViewer>(false, "EditorGUI Icons", true);
            }

#endregion

#region UI Parts

            private void DrawHeader(string text, string subheader, Action additional)
            {
                EditorGUILayout.LabelField(text, EditorStyles.whiteLargeLabel);

                using (new GUILayout.HorizontalScope())
                {
                    EditorGUILayout.LabelField(subheader, EditorStyles.whiteMiniLabel);

                    if (additional != null)
                    {
                        additional();
                    }
                }

                HorizontalLineSeparator(lineColor, 4);
            }

            private void DrawSettings()
            {
                _showSettings = EditorGUILayout.Foldout(_showSettings, settingsLabel);

                if (_showSettings)
                {
                    using (new EditorGUILayout.HorizontalScope())
                    using (new EditorGUI.IndentLevelScope())
                    {
                        EditorGUILayout.LabelField("Icon Size", iconSizeLabelLayout);
                        _iconSize = EditorGUILayout.IntSlider(_iconSize, 8, 64);

                        EditorGUILayout.Space(6f, false);

                        EditorGUILayout.LabelField("Icon Background", iconBackgroundLabelLayout);
                        _backgroundColor = EditorGUILayout.ColorField(_backgroundColor);

                        EditorGUILayout.Space(6f, false);

                        EditorGUILayout.LabelField(
                            "Selected Outline",
                            iconSelectedBackgroundLabelLayout
                        );
                        _selectedBackgroundColor = EditorGUILayout.ColorField(_selectedBackgroundColor);
                    }
                }

                if (_lastIconSize != _iconSize)
                {
                    _iconStyle = new GUIStyle(iconStyle) {fixedWidth = _iconSize};
                    _iconLayout = new[] {GUILayout.Width(_iconSize)};
                    _lastIconSize = _iconSize;
                }

                if (_lastBackgroundColor != _backgroundColor)
                {
                
                    PaintTex(scrollViewStyle.normal.background, _backgroundColor);
                    _lastBackgroundColor = _backgroundColor;
                }
            }

            private void DrawSearch()
            {
                CheckRegexEnumState();

                using (new EditorGUILayout.HorizontalScope())
                {
                    EditorGUILayout.LabelField(searchLabel, searchLabelLayout);
                    _searchFilter = EditorGUILayout.TextField(_searchFilter);

                    var regexStatusLabel = _regexState switch
                    {
                        RegexState.Valid   => regexValidLabel,
                        RegexState.Invalid => regexInvalidLabel,
                        _                  => regexMissingLabel
                    };

                    EditorGUILayout.LabelField(regexStatusLabel, regexIconStyle, regexIconLayout);

                    EditorGUILayout.Space(_horizontalSpacer * 10, false);
                }

                CheckRegexEnumState();
            }

            private void DrawResult()
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    EditorGUILayout.LabelField(selectedIconLabel, selectedIconLabelLayout);

                    EditorGUILayout.LabelField(lastSelectionContent);
                }
            }

            private void DrawIcons()
            {
                if ((_enums == null) || (_enums.Length == 0))
                {
                    return;
                }

                var indentOffset = EditorGUI.indentLevel * 15f;

                var width = position.width - _reservedSpace - indentOffset;
                var iconWidth = _iconSize + (_paddingMultiplier * _iconPadding);
                var columnCount = (int) (width / iconWidth);

                var iconIndex = 0;
                var columnIndex = 0;
            
                using (var scroll = new EditorGUILayout.ScrollViewScope(
                    _scrollPosition, scrollViewStyle))
                {
                    scroll.handleScrollWheel = true;
                    _scrollPosition = scroll.scrollPosition;

                    var scope = new EditorGUILayout.HorizontalScope();

                    try
                    {
                        while (iconIndex < _enums.Length)
                        {
                            var iconName = _iconNames[iconIndex];

                            var regexMatch = true;

                            if (_regexState == RegexState.Valid)
                            {
                                regexMatch = Regex.IsMatch(iconName, _searchFilter);
                            }

                            if (!string.IsNullOrWhiteSpace(_searchFilter) && !regexMatch)
                            {
                                iconIndex += 1;
                                continue;
                            }

                            if (columnIndex >= columnCount)
                            {
                                columnIndex = 0;
                                scope.Dispose();
                                scope = new EditorGUILayout.HorizontalScope();
                            }

                            var icon = _icons[iconIndex];
                            var style = iconStyle;

                            //var style = _lastSelection == icon.tooltip ? selectedIconStyle : iconStyle;

                            EditorGUILayout.LabelField(icon, style, _iconLayout);

                            var lastRectSize = GUILayoutUtility.GetLastRect();
                            lastRectSize.x += EditorGUI.indentLevel * 15f;

                            if (icon.tooltip == _lastSelection)
                            {
                                DrawUIBox(lastRectSize, _selectedBackgroundColor, _selectionSize);
                            }

                            if (GUI.Button(lastRectSize, string.Empty, GUIStyle.none))
                            {
                                _lastSelection = icon.tooltip;
                                EditorGUIUtility.systemCopyBuffer = _lastSelection;

                                var lastSelectionEnum = GetIconEnum(_lastSelection);
                                _lastSelectionContent =
                                    new GUIContent(GetIconContent(lastSelectionEnum))
                                    {
                                        text = _buttonTextPadding + _lastSelection
                                    };
                            }

                            columnIndex += 1;
                            iconIndex += 1;
                        }
                    }
                    finally
                    {
                        scope.Dispose();
                    }
                }
            }

#endregion

#region UI Helper Methods

            private Texture2D MakeTex(int width, int height, Color col)
            {
                var result = new Texture2D(width, height);

                return PaintTex(result, col);
            }

            private Texture2D PaintTex(Texture2D texture, Color col)
            {
                if (texture == null)
                {
                    texture = new Texture2D(1, 1);
                }

                var pix = texture.GetPixels();

                for (var i = 0; i < pix.Length; i++)
                {
                    pix[i] = col;
                }

                texture.SetPixels(pix);
                texture.Apply();

                return texture;
            }

            private void CheckRegexEnumState()
            {
                if (!string.IsNullOrWhiteSpace(_searchFilter))
                {
                    try
                    {
                        Regex.Match("", _searchFilter);
                        _regexState = RegexState.Valid;
                    }
                    catch (Exception ex)
                    {
                        _regexState = RegexState.Invalid;
                    }
                }
                else
                {
                    _regexState = RegexState.Missing;
                }
            }

            public static void HorizontalLineSeparator(Color color, int lineWidth = 1)
            {
                DrawSolidRect(GUILayoutUtility.GetRect(lineWidth, lineWidth, _expandWidth), color);
            }

            public static void DrawUIBox(Rect rect, Color borderColor, float size = 1.5f)
            {
                var left = new Rect(rect.xMin - size, rect.yMin - size, size, rect.height + (2 * size));
                var right = new Rect(rect.xMax, rect.yMin - size, size, rect.height + (2 * size));
                var top = new Rect(rect.xMin - size, rect.yMin - size, rect.width + (2 * size), size);
                var bottom = new Rect(rect.xMin - size, rect.yMax, rect.width + (2 * size), size);

                EditorGUI.DrawRect(left,   borderColor);
                EditorGUI.DrawRect(right,  borderColor);
                EditorGUI.DrawRect(top,    borderColor);
                EditorGUI.DrawRect(bottom, borderColor);
            }

            public static void DrawSolidRect(Rect rect, Color color, bool usePlaymodeTint = true)
            {
                if (Event.current.type != EventType.Repaint)
                {
                    return;
                }

                if (usePlaymodeTint)
                {
                    EditorGUI.DrawRect(rect, color);
                }
                else
                {
                    var oldColor = GUI.color;
                    GUI.color = color;
                    GUI.DrawTexture(rect, EditorGUIUtility.whiteTexture);
                    GUI.color = oldColor;
                }
            }

            private enum RegexState
            {
                Valid,
                Invalid,
                Missing
            }

#endregion
        }
#endif  


#endregion
    }
}
