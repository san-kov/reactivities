import './App.css'
import * as React from "react";
import {useEffect} from "react";
import axios from "axios";

function App() {
    const [activities, setActivities] = React.useState<Activity[]>([]);

    useEffect(() => {
        axios.get<Activity[]>("http://localhost:5112/api/activities")

            .then(res => setActivities(res.data));

        return () => {
        }
    }, [])

    return (
        <>
            <h3>Reactivities</h3>
            <ul>
                {activities.map(activity => <li key={activity.id}>{activity.title}</li>)}
            </ul>
        </>
    )
}

export default App
