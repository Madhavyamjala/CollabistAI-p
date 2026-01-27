import OnboardingView from "./views/OnboardingView";
import useOnboardingStatus from "./hooks/useOnboardingStatus";
import InAppView from "./views/InAppView";

/*App
    Purpose
        Acts as the root component for the Collabist frontend.
    Responsibilities
        Determines whether onboarding or main app should be rendered
    Notes
        Uses backend state as source of truth
    TODO
        Add global error boundary
        Add application shell for main app
*/

function App() {
    const { loading, isOnboarded, refresh } = useOnboardingStatus();

    if (loading) {
        return <div>Loading...</div>;
    }

    if (!isOnboarded) {
        return <OnboardingView onComplete={refresh} />;
    }

    return <InAppView/>;
}

export default App;
