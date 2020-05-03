
const requestPersonsType = 'REQUEST_PERSONS';
const receivePersonsType = 'RECEIVE_PERSONS';
const requestPersonType = 'REQUEST_PERSON';
const receivePersonType = 'RECEIVE_PERSON';
const savePersonType = 'SAVE_PERSON';
const deletePersonType = 'DELETE_PERSON';
const initialState = { persons: [], person: undefined, isLoading: false, startDataIndex:0 };

export const actionCreators = {
    requestPersons: startDataIndex => async (dispatch,getState) => {

        dispatch({ type: requestPersonsType, startDataIndex });
        getState().startIndex = startDataIndex;
        const url = `api/person/?json=${JSON.stringify({ PageNo: startDataIndex,PageSize:10})}`;
        const response = await fetch(url);
        const resp_person = await response.json();
        const persons = resp_person.persons;
        const count = resp_person.count;
        dispatch({ type: receivePersonsType, startDataIndex, persons, count });
    },
    requestPerson: id => async (dispatch, getState) => {

        dispatch({ type: requestPersonType, id });
        const url = `api/person/${id}`;
        const response = await fetch(url);
        const resp_person = await response.json();
        const person = resp_person.person;

        dispatch({ type: receivePersonType, person });
    },
    savePerson: person => async (dispatch, getState) => {
        const url = `api/Person/${person.id}`;
        const response = await fetch(url, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({person})
        });
        const resp = await response.json();
        const hasSaveError = resp.messages.filter(x => x.type == 1).length > 0;
        dispatch({ type: savePersonType, person, hasSaveError});
    },
    deletePerson: person => async (dispatch, getState) => {
        const url = `api/Person/${person.id}`;
        const response = await fetch(url, {
            method: 'DELETE',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        });
        const resp = await response.json();
        const hasDeleteError = resp.messages.filter(x => x.type == 1).length > 0;
        dispatch({ type: deletePersonType, person, hasDeleteError});
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestPersonsType) {
        return {
            ...state,
            startDataIndex: action.startDataIndex,
            isLoading: true
        };
    }

    if (action.type === receivePersonsType) {
        return {
            ...state,
            startDataIndex: action.startDataIndex,
            persons: action.persons,
            count: action.count,
            isLoading: false
        };
    }

    if (action.type === requestPersonType) {
        return {
            ...state,
            id: action.id,
            isLoading: true
        };
    }
    if (action.type === receivePersonType) {
        return {
            ...state,
            person: action.person,
            isLoading: false
        };
    }
    if (action.type === savePersonType) {
        return {
            ...state,
            person: action.person,
            hasSaveError: action.hasSaveError
        };
    }
    if (action.type === deletePersonType) {
        return {
            ...state,
            person: action.person,
            hasDeleteError: action.hasDeleteError
        };
    }
    
    return state;
};
