import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";

/*main
    Purpose
        Bootstraps the React application.
    Responsibilities
        Mounts the root App component
    TODO
        Add error boundary
        Add global providers
*/

ReactDOM.createRoot(document.getElementById("root")).render(
    <React.StrictMode>
        <App />
    </React.StrictMode>
);

