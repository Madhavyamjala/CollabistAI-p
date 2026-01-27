import { useState } from "react";
import { DEFAULT_KNOWLEDGE_BASE_NAME } from "../constants/defaults";

/*OnboardingView
    Purpose
        Handles first-time application setup for Individual users.
    Responsibilities
        Collect user identity details
        Collect AI mode preferences
        Trigger onboarding API
        Redirect user to main app view
    Notes
        Rendered only when onboarding is not completed
    TODO
        Add form validation
        Add loading and error states
        Add folder selection step
*/

export default function OnboardingView({ onComplete }) {
    const [displayName, setDisplayName] = useState("");
    const [email, setEmail] = useState("");
    const [kbName, setKbName] = useState("My Knowledge Base");

    const [local, setLocal] = useState(true);
    const [cloud, setCloud] = useState(false);
    const [ownApi, setOwnApi] = useState(false);

    async function submit() {
        const res = await fetch("/api/onboarding", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                displayName,
                email,
                initialKnowledgeBaseName: kbName,
                allowLocalModels: local,
                allowCompanyCloud: cloud,
                allowOwnApi: ownApi
            })
        });

        if (res.ok) {
            onComplete();
        }
    }

    return (
        <div>
            <h2>Welcome to Collabist</h2>
            <input placeholder="Your name" value={displayName} onChange={e => setDisplayName(e.target.value)} />
            <input placeholder="Email" value={email} onChange={e => setEmail(e.target.value)} />
            <input placeholder="Knowledge Base name" value={kbName} onChange={e => setKbName(e.target.value)} />

            <label>
                <input type="checkbox" checked={local} onChange={e => setLocal(e.target.checked)} />
                Local Models
            </label>

            <label>
                <input type="checkbox" checked={cloud} onChange={e => setCloud(e.target.checked)} />
                Company Cloud
            </label>

            <label>
                <input type="checkbox" checked={ownApi} onChange={e => setOwnApi(e.target.checked)} />
                Own API
            </label>

            <button onClick={submit}>Finish Setup</button>
        </div>
    );
}