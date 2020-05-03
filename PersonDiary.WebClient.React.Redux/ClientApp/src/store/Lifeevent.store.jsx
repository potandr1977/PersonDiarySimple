const requestLifeEventsType = 'REQUEST_LIFEEVENTS';
const receiveLifeEventsType = 'RECEIVE_LIFEEVENTS';
const requestLifeEventType = 'REQUEST_LIFEEVENT';
const receiveLifeEventType = 'RECEIVE_LIFEEVENT';
const saveLifeEventType = 'SAVE_LIFEEVENT';
const deleteLifeEventType = 'DELETE_LIFEEVENT';
const initialState = { lifeevents: [], lifeevent: undefined, isLoading: false };

export const actionCreators = {
    requestLifeEvents: startDataIndex => async (dispatch,getState) => {

        dispatch({ type: requestLifeEventsType, startDataIndex });
        getState().startIndex = startDataIndex;
        const url = `api/lifeevent/?json=${JSON.stringify({ PageNo: startDataIndex, PageSize: 100 })}`;
        const response = await fetch(url);
        const resp = await response.json();
        const lifeevents = resp.lifeEvents;
        dispatch({ type: receiveLifeEventsType, startDataIndex, lifeevents });
    },
    requestLifeEvent: id => async (dispatch, getState) => {

        dispatch({ type: requestLifeEventType, id });
        const url = `api/lifeevent/${id}`;
        const response = await fetch(url);
        const resp = await response.json();
        const lifeevent = resp.lifeevent;

        dispatch({ type: receiveLifeEventType, lifeevent });
    },
    saveLifeEvent: lifeevent => async (dispatch, getState) => {

        const url = `api/lifeevent/${lifeevent.id}`;
        const response = await fetch(url, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ lifeevent })
        });
        const resp = await response.json();
        const hasSaveError = resp.messages.filter(x => x.type == 1).length > 0;
        dispatch({ type: saveLifeEventType, lifeevent, hasSaveError });
    },
    deleteLifeEvent: lifeevent => async (dispatch, getState) => {

        const url = `api/lifeevent/${lifeevent.id}`;
        const response = await fetch(url, {
            method: 'DELETE',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ lifeevent })
        });
        const resp = await response.json();
        const hasDeleteError = resp.messages.filter(x => x.type == 1).length > 0;
        dispatch({ type: deleteLifeEventType,lifeevent,hasDeleteError });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestLifeEventsType) {
        return {
            ...state,
            startDateIndex: action.startDateIndex,
            isLoading: true
        };
    }

    if (action.type === receiveLifeEventsType) {
        return {
            ...state,
            startDataIndex: action.startDataIndex,
            lifeevents: action.lifeevents,
            isLoading: false
        };
    }

    if (action.type === requestLifeEventType) {
        return {
            ...state,
            id: action.id,
            isLoading: true
        };
    }
    if (action.type === receiveLifeEventType) {
        return {
            ...state,
            lifeevent: action.lifeevent,
            isLoading: false
        };
    }
    if (action.type === saveLifeEventType) {
        return {
            ...state,
            lifeevent: action.lifeevent,
            hasSaveError:action.hasSaveError
        };
    }
    if (action.type === deleteLifeEventType) {
        return {
            ...state,
            lifeevent: action.lifeevent,
            hasDeleteError: action.hasDeleteError
        };
    }

    return state;
};
