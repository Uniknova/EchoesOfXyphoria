using System;
using System.Collections.Generic;
using UnityEngine;
using BehaviourAPI.Core;
using BehaviourAPI.Core.Actions;
using BehaviourAPI.Core.Perceptions;
using BehaviourAPI.UnityToolkit;
using BehaviourAPI.StateMachines;
using BehaviourAPI.BehaviourTrees;
using BehaviourAPI.StateMachines.StackFSMs;

namespace ComportamientoMercader
{
	public class ComportamientoMercader : BehaviourRunner
	{
		[SerializeField] private Mercader1 m_Mercader1;
		[SerializeField] private Transform ha_llegado_perception_OtherTransform;
		private PushPerception newpushPerception;
		
		protected override void Init()
		{
			m_Mercader1 = GetComponent<Mercader1>();
			
			base.Init();
		}
		
		protected override BehaviourGraph CreateGraph()
		{
			StackFSM FSM_Nivel1 = new StackFSM();
			BehaviourTree nivel2 = new BehaviourTree();
			
			SubsystemAction ComportamientoMercader_action = new SubsystemAction(nivel2, true, ExecutionInterruptOptions.Pause);
			State ComportamientoMercader = FSM_Nivel1.CreateState(ComportamientoMercader_action);
			
			SimpleAction Mover_action = new SimpleAction();
			Mover_action.action = m_Mercader1.MoveMosrador;
			State Mover = FSM_Nivel1.CreateState(Mover_action);
			
			ConditionPerception Interactuar_perception = new ConditionPerception();
			Interactuar_perception.onCheck = m_Mercader1.interactuarMercader;
			PushTransition Interactuar = FSM_Nivel1.CreatePushTransition(ComportamientoMercader, Mover, Interactuar_perception);
			
			SimpleAction unnamed_action = new SimpleAction();
			unnamed_action.action = m_Mercader1.mostrarInterfaz;
			State unnamed = FSM_Nivel1.CreateState(unnamed_action);
			
			DistancePerception ha_llegado_perception = new DistancePerception();
			ha_llegado_perception.OtherTransform = ha_llegado_perception_OtherTransform;
			ha_llegado_perception.MaxDistance = 0.4f;
			StateTransition ha_llegado = FSM_Nivel1.CreateTransition(Mover, unnamed, ha_llegado_perception);
			
			ConditionPerception unnamed_1_perception = new ConditionPerception();
			unnamed_1_perception.onCheck = m_Mercader1.interactuarMercader;
			SimpleAction unnamed_1_action = new SimpleAction();
			unnamed_1_action.action = m_Mercader1.volver;
			PushTransition unnamed_1 = FSM_Nivel1.CreatePushTransition(unnamed, ComportamientoMercader, unnamed_1_perception, unnamed_1_action);
			
			SimpleAction unnamed_4_action = new SimpleAction();
			unnamed_4_action.action = m_Mercader1.reproducirPintarPlanos;
			LeafNode unnamed_4 = nivel2.CreateLeafNode(unnamed_4_action);
			
			DelayAction unnamed_5_action = new DelayAction();
			unnamed_5_action.delayTime = 1f;
			LeafNode unnamed_5 = nivel2.CreateLeafNode(unnamed_5_action);
			
			SimpleAction unnamed_3_action = new SimpleAction();
			unnamed_3_action.action = m_Mercader1.reproducirPintarPlanos;
			LeafNode unnamed_3 = nivel2.CreateLeafNode(unnamed_3_action);
			
			DelayAction unnamed_6_action = new DelayAction();
			unnamed_6_action.delayTime = 10f;
			LeafNode unnamed_6 = nivel2.CreateLeafNode(unnamed_6_action);
			
			SequencerNode unnamed_2 = nivel2.CreateComposite<SequencerNode>(false, unnamed_4, unnamed_5, unnamed_3, unnamed_6);
			unnamed_2.IsRandomized = false;
			
			newpushPerception = new PushPerception();
			return FSM_Nivel1;
		}
	}
}
