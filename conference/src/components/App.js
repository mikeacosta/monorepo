import { data } from "../../SpeakerData";
import Header from "./Header";
import SpeakersToolbar from "./SpeakersToolbar";
import SpeakersList from "./SpeakersList";
import { useState } from 'react';

function App() {
  const [theme, setTheme] = useState("light");

  return (
    <div className={
      theme === "light" 
        ? "container-fluid light" 
        : "container-fluid dark"
    }>
      <Header theme={theme} />
      <SpeakersToolbar theme={theme} setTheme={setTheme} />
      <SpeakersList data={data} />
    </div>
  );
}

export default App;