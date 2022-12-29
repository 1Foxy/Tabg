using ExitGames.Client.Photon.LoadBalancing;
using Rape.Modules.Managers;
using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using static Battlepass;

namespace Rape.Modules
{
    internal class Render : MonoBehaviour
    {
        public static Camera mainCam;
        private static readonly float crosshairScale = 7f;
        private static readonly float lineThickness = 1.75f;

        public static void DoChams()
        {
            foreach (Player player in FindObjectsOfType<Player>())
            {
                if (player == null)
                {
                    continue;
                }

                foreach (Renderer renderer in player?.gameObject?.GetComponentsInChildren<Renderer>())
                {
                    //renderer.material = chamsMaterial;
                    renderer.material = TABGMaterialDatabase.Instance.GetRarityMaterial(Curse.Rarity.Legendary);
                }

                /*Highlighter h = player.GetOrAddComponent<Highlighter>();
                
                if (h) {
                    h.FlashingOff();
                    h.ConstantOnImmediate(Color.red);
                }*/
            }
        }

        public void OnGUI()
        {
            if (Event.current.type != EventType.Repaint)
            {
                return;
            }

            Items();
            Vehicles();
            PlayerName();
            PlayerBox();
            Crosshair();
            Launchped();

        }

        private static void Items()
        {
            if (!Config.Config.item)
            {
                return;
            }

            if (Managers.PickupManager.droppedItems.Length > 0)
            {
                foreach (Pickup item in Managers.PickupManager.droppedItems)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    Vector3 w2s = mainCam.WorldToScreenPoint(item.transform.position);
                    w2s.y = Screen.height - (w2s.y + 1f);

                    if (RenderUtils.IsOnScreen(w2s))
                    {
                        RenderUtils.DrawString(w2s, item.itemName, Color.green, true, 12, FontStyle.BoldAndItalic, 1);
                    }
                }
            }
        }

        private static void Vehicles()
        {
            if (!Config.Config.Vehicle)
            {
                return;
            }

            if (CarManager.vehicles.Length > 0)
            {
                foreach (Car vehicle in CarManager.vehicles)
                {
                    if (vehicle == null)
                    {
                        continue;
                    }

                    Vector3 w2s = mainCam.WorldToScreenPoint(vehicle.transform.position);
                    w2s.y = Screen.height - (w2s.y + 1f);

                    if (RenderUtils.IsOnScreen(w2s))
                    {
                        RenderUtils.DrawString(w2s, vehicle.name, Color.yellow, true, 12, FontStyle.BoldAndItalic, 1);
                    }
                }
            }
        }

        private static void PlayerBox()
        {
            if (!Config.Config.playerBox)
            {
                return;
            }

            if (PlayerManager.players.Length > 0)
            {
                foreach (Player player in Managers.PlayerManager.players)
                {
                    if (player != null && player != Player.localPlayer)
                    {
                        Vector3 w2sHead = mainCam.WorldToScreenPoint(player.m_head.transform.position);
                        Vector3 w2sBottom = mainCam.WorldToScreenPoint(player.footLeft.transform.position);

                        float height = Mathf.Abs(w2sHead.y - w2sBottom.y);

                        if (RenderUtils.IsOnScreen(w2sHead))
                        {
                            RenderUtils.CornerBox(new Vector2(w2sHead.x, Screen.height - w2sHead.y - 20f), height / 2f, height + 20f, 2f, Color.cyan, true);
                        }
                    }
                }
            }
        }

        private static void PlayerName()
        {
            if (!Config.Config.playerName)
            {
                return;
            }

            if (Managers.PlayerManager.players.Length > 0)
            {
                foreach (Player player in Managers.PlayerManager.players)
                {
                    if (player != null && player != Player.localPlayer)
                    {
                        Vector3 w2s = mainCam.WorldToScreenPoint(player.footLeft.transform.position);
                        w2s.y = Screen.height - (w2s.y + 1f);

                        if (RenderUtils.IsOnScreen(w2s))
                        {
                            RenderUtils.DrawString(w2s, player.name.ToString(), Color.cyan, true, 12, FontStyle.Bold, 1);
                        }
                    }
                }
            }
        }

        private static void Crosshair()
        {
            if (!Config.Config.crosshair)
            {
                return;
            }

            Color32 col = new Color32(30, 144, 255, 255);

            Vector2 lineHorizontalStart = new Vector2(Screen.width / 2 - crosshairScale, Screen.height / 2);
            Vector2 lineHorizontalEnd = new Vector2(Screen.width / 2 + crosshairScale, Screen.height / 2);

            Vector2 lineVerticalStart = new Vector2(Screen.width / 2, Screen.height / 2 - crosshairScale);
            Vector2 lineVerticalEnd = new Vector2(Screen.width / 2, Screen.height / 2 + crosshairScale);



            RenderUtils.DrawLine(lineHorizontalStart, lineHorizontalEnd, col, lineThickness);
            RenderUtils.DrawLine(lineVerticalStart, lineVerticalEnd, col, lineThickness);   

        }

        private static void Launchped()
        {
            if (!Config.Config.LaunchPed)
            {
                return;
            }

            foreach (LaunchPad gameObject in Resources.FindObjectsOfTypeAll<LaunchPad>())
            {
                Vector3 w2s = mainCam.WorldToScreenPoint(gameObject.transform.position);
                w2s.y = Screen.height - (w2s.y + 1f);
                bool flag2 = gameObject == null;
                if (!flag2)
                {
                    if (RenderUtils.IsOnScreen(w2s))
                    {
                        RenderUtils.DrawString(w2s, "Launchpad", Color.cyan, true, 12, FontStyle.Bold, 1);
                    }
                } new WaitForSeconds(2.5f);
            }
        }

    }

    class RenderUtils
    {
        public static Material material;
        private static Texture2D drawingTex;
        private static Color lastTexColour;
        private static GUIStyle __style = new GUIStyle();
        private static GUIStyle __outlineStyle = new GUIStyle();

        internal static bool IsOnScreen(Vector3 position)
        {
            return position.y > 0.01f && position.y < Screen.height - 5f && position.z > 0.01f;
        }
        internal static void DrawLine(Vector2 start, Vector2 end, Color color, float width)
        {
            Color oldColour = GUI.color;

            var rad2deg = 360 / (Math.PI * 2);

            Vector2 d = end - start;

            float a = (float)rad2deg * Mathf.Atan(d.y / d.x);

            if (d.x < 0)
                a += 180;

            int width2 = (int)Mathf.Ceil(width / 2);

            GUIUtility.RotateAroundPivot(a, start);

            GUI.color = color;

            GUI.DrawTexture(new Rect(start.x, start.y - width2, d.magnitude, width), Texture2D.whiteTexture, ScaleMode.StretchToFill);

            GUIUtility.RotateAroundPivot(-a, start);

            GUI.color = oldColour;
        }
        internal static void DrawString(Vector2 pos, string text, Color color, bool center = true, int size = 12, FontStyle fontStyle = FontStyle.Bold, int depth = 1)
        {
            __style.fontSize = size;
            __style.richText = true;
            //__style.font = tahoma;
            __style.normal.textColor = color;
            __style.fontStyle = fontStyle;

            __outlineStyle.fontSize = size;
            __outlineStyle.richText = true;
            //__outlineStyle.font = tahoma;
            __outlineStyle.normal.textColor = new Color(0f, 0f, 0f, 1f);
            __outlineStyle.fontStyle = fontStyle;

            GUIContent content = new GUIContent(text);
            GUIContent content2 = new GUIContent(text);
            if (center)
            {
                //GUI.skin.label.alignment = TextAnchor.MiddleCenter;
                pos.x -= __style.CalcSize(content).x / 2f;
            }
            switch (depth)
            {
                case 0:
                    GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), content, __style);
                    break;
                case 1:
                    GUI.Label(new Rect(pos.x + 1f, pos.y + 1f, 300f, 25f), content2, __outlineStyle);
                    GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), content, __style);
                    break;
                case 2:
                    GUI.Label(new Rect(pos.x + 1f, pos.y + 1f, 300f, 25f), content2, __outlineStyle);
                    GUI.Label(new Rect(pos.x - 1f, pos.y - 1f, 300f, 25f), content2, __outlineStyle);
                    GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), content, __style);
                    break;
                case 3:
                    GUI.Label(new Rect(pos.x + 1f, pos.y + 1f, 300f, 25f), content2, __outlineStyle);
                    GUI.Label(new Rect(pos.x - 1f, pos.y - 1f, 300f, 25f), content2, __outlineStyle);
                    GUI.Label(new Rect(pos.x, pos.y - 1f, 300f, 25f), content2, __outlineStyle);
                    GUI.Label(new Rect(pos.x, pos.y + 1f, 300f, 25f), content2, __outlineStyle);
                    GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), content, __style);
                    break;
            }
        }
        internal static void CornerBox(Vector2 Head, float Width, float Height, float thickness, Color color, bool outline)
        {
            int num = (int)(Width / 4f);
            int num2 = num;

            if (outline)
            {
                RectFilled(Head.x - Width / 2f - 1f, Head.y - 1f, (float)(num + 2), 3f, Color.black);
                RectFilled(Head.x - Width / 2f - 1f, Head.y - 1f, 3f, (float)(num2 + 2), Color.black);
                RectFilled(Head.x + Width / 2f - (float)num - 1f, Head.y - 1f, (float)(num + 2), 3f, Color.black);
                RectFilled(Head.x + Width / 2f - 1f, Head.y - 1f, 3f, (float)(num2 + 2), Color.black);
                RectFilled(Head.x - Width / 2f - 1f, Head.y + Height - 4f, (float)(num + 2), 3f, Color.black);
                RectFilled(Head.x - Width / 2f - 1f, Head.y + Height - (float)num2 - 4f, 3f, (float)(num2 + 2), Color.black);
                RectFilled(Head.x + Width / 2f - (float)num - 1f, Head.y + Height - 4f, (float)(num + 2), 3f, Color.black);
                RectFilled(Head.x + Width / 2f - 1f, Head.y + Height - (float)num2 - 4f, 3f, (float)(num2 + 3), Color.black);
            }

            RectFilled(Head.x - Width / 2f, Head.y, num, 1f, color);
            RectFilled(Head.x - Width / 2f, Head.y, 1f, num2, color);
            RectFilled(Head.x + Width / 2f - num, Head.y, num, 1f, color);
            RectFilled(Head.x + Width / 2f, Head.y, 1f, num2, color);
            RectFilled(Head.x - Width / 2f, Head.y + Height - 3f, num, 1f, color);
            RectFilled(Head.x - Width / 2f, Head.y + Height - num2 - 3f, 1f, num2, color);
            RectFilled(Head.x + Width / 2f - num, Head.y + Height - 3f, num, 1f, color);
            RectFilled(Head.x + Width / 2f, Head.y + Height - num2 - 3f, 1f, num2 + 1, color);
        }
        internal static void RectFilled(float x, float y, float width, float height, Color color)
        {
            if (!drawingTex)
                drawingTex = new Texture2D(1, 1);

            if (color != lastTexColour)
            {
                drawingTex.SetPixel(0, 0, color);
                drawingTex.Apply();

                lastTexColour = color;
            }

            GUI.DrawTexture(new Rect(x, y, width, height), drawingTex);
        }
        public static void DrawCrosshair(Vector2 position, float size, float thickness)
        {
            thickness = 1.5f;
            size = 5f;

            Texture2D whiteTexture = Texture2D.whiteTexture;
            GUI.DrawTexture(new Rect(position.x - size, position.y, size * 2f + thickness, thickness), whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y - size, thickness, size * 2f + thickness), whiteTexture);
        }


    }
}
