using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFSM
{
    public delegate void DelegateFunc();

    public class CState
    {
        public DelegateFunc OnEnterFunc = null;

        public virtual void Initialize(DelegateFunc func)
        { OnEnterFunc = new DelegateFunc(func); }

        public virtual void OnEnter() { }
        public virtual void OnUpdate() { }
        public virtual void OnExit() { }
    }

    public class CReadyState : CState
    {
        public override void OnEnter()
        {
            if (OnEnterFunc != null)
                OnEnterFunc();
        }
        public override void OnUpdate()
        {

        }
        public override void OnExit()
        {

        }
    }

    public class CGameState : CState
    {
        public override void OnEnter()
        {
            if (OnEnterFunc != null)
                OnEnterFunc();
        }
        public override void OnUpdate()
        {

        }
        public override void OnExit()
        {

        }
    }

    public class CLayerState : CState
    {
        public override void OnEnter()
        {
            if (OnEnterFunc != null)
                OnEnterFunc();
        }
        public override void OnUpdate()
        {

        }
        public override void OnExit()
        {

        }
    }

    public class CResultState : CState
    {
        public override void OnEnter()
        {
            if (OnEnterFunc != null)
                OnEnterFunc();
        }
        public override void OnUpdate()
        {

        }
        public override void OnExit()
        {

        }
    }

    public class CEscState : CState
    {
        public override void OnEnter()
        {
            if (OnEnterFunc != null)
                OnEnterFunc();
        }
        public override void OnUpdate()
        {

        }
        public override void OnExit()
        {

        }
    }

    CState CurState = null;
    CState NewState = null;

    CState Ready = new CReadyState();
    CState Game = new CGameState();
    CState Result = new CResultState();
    CState Esc = new CEscState();

    public void Initialize(DelegateFunc ready, DelegateFunc game, DelegateFunc result, DelegateFunc esc)
    {
        Ready.Initialize(ready);
        Game.Initialize(game);
        Result.Initialize(result);
        Esc.Initialize(esc);
    }

    public void OnUpdate()
    {
        if (NewState != null)
        {
            if (CurState != null) CurState.OnExit();

            CurState = NewState;
            NewState = null;

            if (CurState != null) CurState.OnEnter();
        }

        if (CurState != null) CurState.OnUpdate();
    }

    void SetState(CState state) { NewState = state; }

    public void SetReadyState() { SetState(Ready); }
    public void SetGameState() { SetState(Game); }
    public void SetResultState() { SetState(Result); }
    public void SetEscState() { SetState(Esc); }

    public bool IsCurState(CState state)
    {
        if (CurState == null) return false;
        return (CurState == state) ? true : false;
    }

    public bool IsReadyState() { return IsCurState(Ready); }
    public bool IsGameState() { return IsCurState(Game); }
    public bool IsResultState() { return IsCurState(Result); }
    public bool IsEscState() { return IsCurState(Esc); }

    public CState GetCurState() { return CurState; }

    public void ResetState()
    {
        NewState = null;
        CurState = null;
    }
}
