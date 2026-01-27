import { useEffect, useState } from "react";

/*useOnboardingStatus
    Purpose
        Determines whether onboarding has been completed.
    Responsibilities
        Fetch onboarding status from backend
        Expose loading and state flags
    Notes
        Called once during application startup
    TODO
        Add retry and error handling
*/

export default function useOnboardingStatus() {
    const [loading, setLoading] = useState(true);
    const [isOnboarded, setIsOnboarded] = useState(false);

    function refresh() {
        setLoading(true);
        fetch("/api/onboarding/status")
            .then(res => res.json())
            .then(data => {
                setIsOnboarded(data.isOnboarded);
                setLoading(false);
            });
    }

    useEffect(() => {
        // eslint-disable-next-line react-hooks/set-state-in-effect
        refresh();
    }, []);

    return { loading, isOnboarded, refresh };
}
