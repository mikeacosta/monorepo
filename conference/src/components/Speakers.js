import SpeakersToolbar from "./SpeakersToolbar";
import SpeakersList from "./SpeakersList";

function Speakers({data, theme, setTheme}) {
  return (
    <>
      <SpeakersToolbar theme={theme} setTheme={setTheme} />
      <SpeakersList data={data} />
    </>
  );
}

export default Speakers;