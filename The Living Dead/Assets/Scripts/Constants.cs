using UnityEngine;

public static class Constants
{
    public static class Scene
    {
        public static string Loading => "LoadingScene";
        public static string MainMenu => "MainMenu";
        public static string Game => "Game";
        public static string GameOver => "GameOver";
    }

    public static class RoundStatistics
    {
        public static string YouSurvivedRoundsText => "You survived {0} rounds!";
    }

    public static class VideoOptionsKey
    {
        public static string FieldOfView => "FieldOfView";
        public static string DrawDistance => "DrawDistance";
    }

    public static class AudioOptionsKey
    {
        public static string MenuAudio => "MenuAudio";
        public static string MuteMenuAudio => "MuteMenuAudio";
        public static string GameAudio => "GameAudio";
        public static string MuteGameAudio => "MuteGameAudio";
    }

    public static class MouseOptionsKey
    {
        public static string MouseSensitivityX => "MouseSensitivityX";
        public static string MouseSensitivityY => "MouseSensitivityY";
        public static string InvertMouse => "InvertMouse";
    }

    public static class GameOptionsKey
    {
        public static string StartingHealth => "StartingHealth";
        public static string StartingAmmoClips => "StartingAmmoClips";
        public static string StartingMoney => "StartingMoney";
    }

    public static class UnitText
    {
        public static string SpaceMetre => " m";
        public static string SpaceSecond => " s";
    }

    public static class Unit
    {
        public static float Second => 1.0f;
    }

    public static class CustomValue
    {
        public static float PointNine => 0.9f;
        public static float SliderMaxValue => 1f;
        public static int Zero => 0;
    }

    public static class TimeScale
    {
        public static float DefaultTimeScale => 1.0f;
        public static float PausedTimeScale => 0.0f;
    }

    public static class PlayerPrefs
    {
        public static int BoolValueTrue => 1;
        public static int BoolValueFalse => 0;
    }

    public static class Character
    {
        public static string Minus => "-";
    }

    public static class Layer
    {
        public static int Zombie => 11;
        public static int Shop => 13;
    }

    public static class GameObject
    {
        public static string Player => "Player";
        public static string ZombieWithSpace => "Zombie ";
    }

    public static class Input
    {
        public static string Fire1 => "Fire1";
    }

    public static class WeaponIndex
    {
        public static int Weapon0 => 0;
        public static int Weapon1 => 1;
    }

    public static class AnimationParameter
    {
        public static string IsAimWalking => "IsAimWalking";
        public static string IsWeaponHidden => "IsWeaponHidden";
        public static string IsRunning => "IsRunning";
        public static string IsWalking => "IsWalking";
    }

    public static class AnimationState
    {
        public static string Idle => "Idle";
        public static string Shot => "Shot";
        public static string AimShot => "Aim Shot";
        public static string AimWalk => "Aim Walk";
        public static string Reload => "Reload";
        public static string Run => "Run";
        public static string Walk => "Walk";
        public static string SwitchWeapon => "Switch Weapon";
        public static string RevealWeapon => "Reveal Weapon";
        public static string HideWeapon => "Hide Weapon";
        public static string Die => "Die";
    }

    public static class Camera
    {
        public static Vector3 Center => new Vector3(0.5f, 0.5f, 0.0f);
    }
}