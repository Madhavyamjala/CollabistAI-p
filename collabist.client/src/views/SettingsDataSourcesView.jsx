import { useEffect, useState } from "react";

/*SettingsDataSourcesView
    Purpose
        Allows users to approve folders for knowledge access.
    Responsibilities
        Submit approved paths
        Display approved sources
    Notes
        File picking is manual for now
    TODO
        Add native folder picker
        Add revoke support
*/

export default function SettingsDataSourcesView() {
    const [path, setPath] = useState("");
    const [sources, setSources] = useState([]);

    useEffect(() => {
        fetch("/api/data-sources")
            .then(res => res.json())
            .then(setSources);
    }, []);

    function approve() {
        fetch("/api/data-sources", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                path,
                type: "Folder"
            })
        })
            .then(res => res.json())
            .then(ds => setSources(prev => [...prev, ds]));
    }

    return (
        <div>
            <h3>Approved Folders</h3>

            <input
                placeholder="Absolute folder path"
                value={path}
                onChange={e => setPath(e.target.value)}
            />
            <button onClick={approve}>Approve</button>

            <ul>
                {sources.map(s => (
                    <li key={s.id}>{s.path}</li>
                ))}
            </ul>
        </div>
    );
}
