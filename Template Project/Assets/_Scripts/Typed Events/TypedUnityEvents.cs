using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.VFX;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.XR.WSA;

namespace TypedEvents
{
    #region C# Data Types
    
    [System.Serializable]
    public class UnityBoolEvent : UnityEvent<bool>
    {

    }

    [System.Serializable]
    public class UnityByteEvent : UnityEvent<byte>
    {

    }

    [System.Serializable]
    public class UnityCharEvent : UnityEvent<char>
    {

    }

    [System.Serializable]
    public class UnityDecimalEvent : UnityEvent<decimal>
    {

    }

    [System.Serializable]
    public class UnityDoubleEvent : UnityEvent<double>
    {

    }

    [System.Serializable]
    public class UnityFloatEvent: UnityEvent<float>
    {

    }

    [System.Serializable]
    public class UnityIntEvent : UnityEvent<int>
    {

    }

    [System.Serializable]
    public class UnityLongEvent : UnityEvent<long>
    {

    }

    [System.Serializable]
    public class UnityObjectEvent : UnityEvent<object>
    {

    }

    [System.Serializable]
    public class UnitySbyteEvent : UnityEvent<sbyte>
    {

    }

    [System.Serializable]
    public class UnityShortEvent : UnityEvent<short>
    {

    }

    [System.Serializable]
    public class UnityUintEvent : UnityEvent<uint>
    {

    }

    [System.Serializable]
    public class UnityUlongEvent : UnityEvent<ulong>
    {

    }

    [System.Serializable]
    public class UnityUshortEvent : UnityEvent<ushort>
    {

    }

    [System.Serializable]
    public class UnityStringEvent : UnityEvent<string>
    {

    }

    #endregion

    #region Built-in Unity AR Components
    
    [System.Serializable]
    public class UnityWorldAnchorEvent : UnityEvent<WorldAnchor>
    {

    }

    #endregion

    #region Built-in Unity Audio Components

    [System.Serializable]
    public class UnityAudioChorusFilterEvent : UnityEvent<AudioChorusFilter>
    {

    }

    [System.Serializable]
    public class UnityAudioDistortionFilterEvent : UnityEvent<AudioDistortionFilter>
    {

    }

    [System.Serializable]
    public class UnityAudioEchoFilterEvent : UnityEvent<AudioEchoFilter>
    {

    }

    [System.Serializable]
    public class UnityAudioHighPassFilterEvent : UnityEvent<AudioHighPassFilter>
    {

    }

    [System.Serializable]
    public class UnityAudioListenerEvent : UnityEvent<AudioListener>
    {

    }

    [System.Serializable]
    public class UnityAudioLowPassFilterEvent : UnityEvent<AudioLowPassFilter>
    {

    }

    [System.Serializable]
    public class UnityAudioReverbFilterEvent : UnityEvent<AudioReverbFilter>
    {

    }

    [System.Serializable]
    public class UnityAudioReverbZoneEvent : UnityEvent<AudioReverbZone>
    {

    }

    [System.Serializable]
    public class UnityAudioSourceEvent : UnityEvent<AudioSource>
    {

    }

    #endregion

    #region Built-in Unity Effects Components

    /* Halos are classified as Behaviours, so either:
        1) Use UnityBehaviourEvent
        2) Use UnityLightEvent, since you can access Halo properties through the Light class     
     */

    [System.Serializable]
    public class UnityLensFlareEvent : UnityEvent<LensFlare>
    {

    }

    [System.Serializable]
    public class UnityLineRendererEvent : UnityEvent<LineRenderer>
    {

    }

    [System.Serializable]
    public class UnityParticleSystemEvent : UnityEvent<ParticleSystem>
    {

    }

    [System.Serializable]
    public class UnityProjectorEvent : UnityEvent<Projector>
    {

    }

    [System.Serializable]
    public class UnityTrailRendererEvent : UnityEvent<TrailRenderer>
    {

    }

    [System.Serializable]
    public class UnityVisualEffectEvent : UnityEvent<VisualEffect>
    {

    }

    #endregion

    #region Built-in Unity Event Components

    [System.Serializable]
    public class UnityEventSystemEvent : UnityEvent<EventSystem>
    {

    }

    [System.Serializable]
    public class UnityEventTriggerEvent : UnityEvent<EventTrigger>
    {

    }

    [System.Serializable]
    public class UnityGraphicRaycasterEvent : UnityEvent<GraphicRaycaster>
    {

    }

    [System.Serializable]
    public class UnityPhysisc2DRaycasterEvent : UnityEvent<Physics2DRaycaster>
    {

    }

    [System.Serializable]
    public class UnityPhysicsRaycasterEvent : UnityEvent<PhysicsRaycaster>
    {

    }

    [System.Serializable]
    public class UnityStandaloneInputModuleEvent : UnityEvent<StandaloneInputModule>
    {

    }

    #if !UNITY_2018_4_OR_NEWER
    #pragma warning disable CS0618
    [System.Serializable]
    public class UnityTouchInputModuleEvent : UnityEvent<TouchInputModule>
    {

    }
    #pragma warning restore CS0618
    #endif

    #endregion

    #region Built-in Unity General Components

    [System.Serializable]
    public class UnityBehaviourEvent : UnityEvent<Behaviour>
    {

    }

    [System.Serializable]
    public class UnityGameObjectEvent : UnityEvent<GameObject>
    {

    }

    [System.Serializable]
    public class UnityMonoBehaviourEvent : UnityEvent<MonoBehaviour>
    {

    }

    [System.Serializable]
    public class UnityTransformEvent : UnityEvent<Transform>
    {

    }

    #endregion

    #region Built-in Unity Layout Components

    [System.Serializable]
    public class UnityAspectRatioFitterEvent : UnityEvent<AspectRatioFitter>
    {

    }

    [System.Serializable]
    public class UnityCanvasEvent : UnityEvent<Canvas>
    {

    }

    [System.Serializable]
    public class UnityCanvasGroupEvent : UnityEvent<CanvasGroup>
    {

    }

    [System.Serializable]
    public class UnityCanvasScalerEvent : UnityEvent<CanvasScaler>
    {

    }

    [System.Serializable]
    public class UnityContentSizeFitterEvent : UnityEvent<ContentSizeFitter>
    {

    }

    [System.Serializable]
    public class UnityGridLayoutGroupEvent : UnityEvent<GridLayoutGroup>
    {

    }

    [System.Serializable]
    public class UnityHorizontalLayoutGroupEvent : UnityEvent<HorizontalLayoutGroup>
    {

    }

    [System.Serializable]
    public class UnityLayoutElementEvent : UnityEvent<LayoutElement>
    {

    }

    [System.Serializable]
    public class UnityRectTransformEvent : UnityEvent<RectTransform>
    {

    }

    [System.Serializable]
    public class UnityVerticalLayoutGroupEvent : UnityEvent<VerticalLayoutGroup>
    {

    }

    #endregion

    #region Built-in Unity Mesh Components

    [System.Serializable]
    public class UnityMeshFilterEvent : UnityEvent<MeshFilter>
    {

    }

    [System.Serializable]
    public class UnityMeshRendererEvent : UnityEvent<MeshRenderer>
    {

    }

    [System.Serializable]
    public class UnitySkinnedMeshRendererEvent : UnityEvent<SkinnedMeshRenderer>
    {

    }

    #endregion

    #region Built-in Unity Miscellaneous Components

    [System.Serializable]
    public class UnityAimConstraintEvent : UnityEvent<AimConstraint>
    {

    }

    [System.Serializable]
    public class UnityAnimationEvent : UnityEvent<Animation>
    {

    }

    [System.Serializable]
    public class UnityAnimatorEvent : UnityEvent<Animator>
    {

    }

    [System.Serializable]
    public class UnityBillboardRendererEvent : UnityEvent<BillboardRenderer>
    {

    }

    [System.Serializable]
    public class UnityGridEvent : UnityEvent<Grid>
    {

    }

    [System.Serializable]
    public class UnityLookAtConstraintEvent : UnityEvent<LookAtConstraint>
    {

    }

    [System.Serializable]
    public class UnityParentConstraintEvent : UnityEvent<ParentConstraint>
    {

    }

    [System.Serializable]
    public class UnityParticleSystemForceFieldEvent : UnityEvent<ParticleSystemForceField>
    {

    }

    [System.Serializable]
    public class UnityPositionConstraintEvent : UnityEvent<PositionConstraint>
    {

    }

    [System.Serializable]
    public class UnityRotationConstraintEvent : UnityEvent<RotationConstraint>
    {

    }

    [System.Serializable]
    public class UnityScaleConstraintEvent : UnityEvent<ScaleConstraint>
    {

    }

    [System.Serializable]
    public class UnitySpriteMaskEvent : UnityEvent<SpriteMask>
    {

    }

    [System.Serializable]
    public class UnityTerrainEvent : UnityEvent<Terrain>
    {

    }

    [System.Serializable]
    public class UnityWindZoneEvent : UnityEvent<WindZone>
    {

    }

    #endregion

    #region Built-in Unity Navigation Components
    
    [System.Serializable]
    public class UnityNavMeshAgentEvent : UnityEvent<NavMeshAgent>
    {

    }

    [System.Serializable]
    public class UnityNavMeshObstacleEvent : UnityEvent<NavMeshObstacle>
    {

    }

    [System.Serializable]
    public class UnityOffMeshLinkEvent : UnityEvent<OffMeshLink>
    {

    }

    #endregion

    #region Built-in Unity Physics 2D Components

    [System.Serializable]
    public class UnityAreaEffector2DEvent : UnityEvent<AreaEffector2D>
    {

    }

    [System.Serializable]
    public class UnityBoxCollider2DEvent : UnityEvent<BoxCollider2D>
    {

    }

    [System.Serializable]
    public class UnityBuoyancyEffector2DEvent : UnityEvent<BuoyancyEffector2D>
    {

    }

    [System.Serializable]
    public class UnityCapsuleCollider2DEvent : UnityEvent<CapsuleCollider2D>
    {

    }

    [System.Serializable]
    public class UnityCollider2DEvent : UnityEvent<Collider2D>
    {

    }

    [System.Serializable]
    public class UnityCompositeCollider2DEvent : UnityEvent<CompositeCollider2D>
    {

    }

    [System.Serializable]
    public class UnityCircleCollider2DEvent : UnityEvent<CircleCollider2D>
    {

    }

    [System.Serializable]
    public class UnityConstantForce2DEvent : UnityEvent<ConstantForce2D>
    {

    }

    [System.Serializable]
    public class UnityDistanceJoint2DEvent : UnityEvent<DistanceJoint2D>
    {

    }

    [System.Serializable]
    public class UnityEdgeCollider2DEvent : UnityEvent<EdgeCollider2D>
    {

    }

    [System.Serializable]
    public class UnityFixedJoint2DEvent : UnityEvent<FixedJoint2D>
    {

    }

    [System.Serializable]
    public class UnityFrictionJoint2DEvent : UnityEvent<FrictionJoint2D>
    {

    }

    [System.Serializable]
    public class UnityHingeJoint2DEvent : UnityEvent<HingeJoint2D>
    {

    }

    [System.Serializable]
    public class UnityPlatformEffector2DEvent : UnityEvent<PlatformEffector2D>
    {

    }

    [System.Serializable]
    public class UnityPointEffector2DEvent : UnityEvent<PointEffector2D>
    {

    }

    [System.Serializable]
    public class UnityPolygonCollider2DEvent : UnityEvent<PolygonCollider2D>
    {

    }

    [System.Serializable]
    public class UnityRelativeJoint2DEvent : UnityEvent<RelativeJoint2D>
    {

    }

    [System.Serializable]
    public class UnityRigidbody2DEvent : UnityEvent<Rigidbody2D>
    {

    }

    [System.Serializable]
    public class UnitySliderJoint2DEvent : UnityEvent<SliderJoint2D>
    {

    }

    [System.Serializable]
    public class UnitySpringJoint2DEvent : UnityEvent<SpringJoint2D>
    {

    }

    [System.Serializable]
    public class UnitySurfaceEffector2DEvent : UnityEvent<SurfaceEffector2D>
    {

    }

    [System.Serializable]
    public class UnityTargetJoint2DEvent : UnityEvent<TargetJoint2D>
    {

    }

    [System.Serializable]
    public class UnityWheelJoint2DEvent : UnityEvent<WheelJoint2D>
    {

    }

    #endregion

    #region Built-in Unity Physics Components

    [System.Serializable]
    public class UnityBoxColliderEvent : UnityEvent<BoxCollider>
    {

    }

    [System.Serializable]
    public class UnityCapsuleColliderEvent : UnityEvent<CapsuleCollider>
    {

    }

    [System.Serializable]
    public class UnityCharacterControllerEvent : UnityEvent<CharacterController>
    {

    }

    [System.Serializable]
    public class UnityCharacterJointEvent : UnityEvent<CharacterJoint>
    {

    }

    [System.Serializable]
    public class UnityClothEvent : UnityEvent<Cloth>
    {

    }

    [System.Serializable]
    public class UnityColliderEvent : UnityEvent<Collider>
    {

    }

    [System.Serializable]
    public class UnityConfigurableJointEvent : UnityEvent<ConfigurableJoint>
    {

    }

    [System.Serializable]
    public class UnityConstantForceEvent : UnityEvent<ConstantForce>
    {

    }

    [System.Serializable]
    public class UnityFixedJointEvent : UnityEvent<FixedJoint>
    {

    }

    [System.Serializable]
    public class UnityHingeJointEvent : UnityEvent<HingeJoint>
    {

    }

    [System.Serializable]
    public class UnityMeshColliderEvent : UnityEvent<MeshCollider>
    {

    }

    [System.Serializable]
    public class UnityRigidbodyEvent : UnityEvent<Rigidbody>
    {

    }

    [System.Serializable]
    public class UnitySphereColliderEvent : UnityEvent<SphereCollider>
    {

    }

    [System.Serializable]
    public class UnitySpringJointEvent : UnityEvent<SpringJoint>
    {

    }

    [System.Serializable]
    public class UnityTerrainColliderEvent : UnityEvent<TerrainCollider>
    {

    }

    [System.Serializable]
    public class UnityWheelColliderEvent : UnityEvent<WheelCollider>
    {

    }

    #endregion

    #region Built-in Unity Playables Components

    [System.Serializable]
    public class UnityPlayableDirectorEvent : UnityEvent<PlayableDirector>
    {

    }

    #endregion

    #region Built-in Unity Rendering Components

    [System.Serializable]
    public class UnityCameraEvent : UnityEvent<Camera>
    {

    }

    [System.Serializable]
    public class UnityCanvasRendererEvent : UnityEvent<CanvasRenderer>
    {

    }

    [System.Serializable]
    public class UnityFlareLayerEvent : UnityEvent<FlareLayer>
    {

    }

    #if !UNITY_2019_3_OR_NEWER
    #pragma warning disable CS0618
    [System.Serializable]
    public class UnityGUILayerEvent : UnityEvent<GUILayer>
    {

    }
    #pragma warning restore CS0618
    #endif

    #if !UNITY_2019_3_OR_NEWER
    #pragma warning disable CS0618
    [System.Serializable]
    public class UnityGUITextEvent : UnityEvent<GUIText>
    {

    }
    #pragma warning restore CS0618
    #endif
    
    #if !UNITY_2019_3_OR_NEWER
    #pragma warning disable CS0618
    [System.Serializable]
    public class UnityGUITextureEvent : UnityEvent<GUITexture>
    {

    }
    #pragma warning restore CS0618
    #endif

    [System.Serializable]
    public class UnityLightEvent : UnityEvent<Light>
    {

    }

    [System.Serializable]
    public class UnityLightProbeGroupEvent : UnityEvent<LightProbeGroup>
    {

    }

    [System.Serializable]
    public class UnityLightProbeProxyVolumeEvent : UnityEvent<LightProbeProxyVolume>
    {

    }

    [System.Serializable]
    public class UnityLODGroupEvent : UnityEvent<LODGroup>
    {

    }

    [System.Serializable]
    public class UnityOcclusionAreaEvent : UnityEvent<OcclusionArea>
    {

    }

    [System.Serializable]
    public class UnityOcclusionPortalEvent : UnityEvent<OcclusionPortal>
    {

    }

    [System.Serializable]
    public class UnityReflectionProbeEvent : UnityEvent<ReflectionProbe>
    {

    }

    [System.Serializable]
    public class UnitySkyboxEvent : UnityEvent<Skybox>
    {

    }

    [System.Serializable]
    public class UnitySortingGroupEvent : UnityEvent<SortingGroup>
    {

    }

    [System.Serializable]
    public class UnitySpriteRendererEvent : UnityEvent<SpriteRenderer>
    {

    }

    [System.Serializable]
    public class UnityStreamingControllerEvent : UnityEvent<StreamingController>
    {

    }

    #endregion

    #region Built-in Unity Tilemap Components

    #if UNITY_2017_4_OR_NEWER
    [System.Serializable]
    public class UnityTilemapEvent : UnityEvent<Tilemap>
    {

    }
    #endif
    
    #if UNITY_2017_4_OR_NEWER
    [System.Serializable]
    public class UnityTilemapCollider2DEvent : UnityEvent<TilemapCollider2D>
    {

    }
    #endif
    
    #if UNITY_2017_4_OR_NEWER
    [System.Serializable]
    public class UnityTilemapRendererEvent : UnityEvent<TilemapRenderer>
    {

    }
#endif

    #endregion

    #region Built-in Unity UI Components

    [System.Serializable]
    public class UnityButtonEvent : UnityEvent<Button>
    {

    }

    [System.Serializable]
    public class UnityDropdownEvent : UnityEvent<Dropdown>
    {

    }

    [System.Serializable]
    public class UnityOutlineEvent : UnityEvent<Outline>
    {

    }

    [System.Serializable]
    public class UnityPositionAsUV1Event : UnityEvent<PositionAsUV1>
    {

    }

    [System.Serializable]
    public class UnityShadowEvent : UnityEvent<Shadow>
    {

    }

    [System.Serializable]
    public class UnityImageEvent : UnityEvent<Image>
    {

    }

    [System.Serializable]
    public class UnityInputFieldEvent : UnityEvent<InputField>
    {

    }

    [System.Serializable]
    public class UnityMaskEvent : UnityEvent<Mask>
    {

    }

    [System.Serializable]
    public class UnityRawImageEvent : UnityEvent<RawImage>
    {

    }

    [System.Serializable]
    public class UnityRectMask2DEvent : UnityEvent<RectMask2D>
    {

    }

    [System.Serializable]
    public class UnityScrollRectEvent : UnityEvent<ScrollRect>
    {

    }

    [System.Serializable]
    public class UnityScrollbarEvent : UnityEvent<Scrollbar>
    {

    }

    [System.Serializable]
    public class UnitySelectableEvent : UnityEvent<Selectable>
    {

    }

    [System.Serializable]
    public class UnitySliderEvent : UnityEvent<Slider>
    {

    }

    [System.Serializable]
    public class UnityTextEvent : UnityEvent<Text>
    {

    }

    [System.Serializable]
    public class UnityToggleEvent : UnityEvent<Toggle>
    {

    }

    [System.Serializable]
    public class UnityToggleGroupEvent : UnityEvent<ToggleGroup>
    {

    }

    #endregion

    #region Built-in Unity Video Components

    [System.Serializable]
    public class UnityVideoPlayerEvent : UnityEvent<VideoPlayer>
    {

    }

    #endregion
}
