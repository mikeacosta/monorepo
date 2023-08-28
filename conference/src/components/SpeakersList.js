import { data } from "../../SpeakerData";
import Speaker from "./Speaker";
import { useState } from "react";

function SpeakersList({showSessions}) {
  const  [speakersData, setSpeakersData] = useState(data);

  return (
    <div className="container speakers-list">
      <div className="row">
        {speakersData.map(function (speaker) {
          return <Speaker 
            key={speaker.id} 
            speaker={speaker}
            showSessions={showSessions}
            onFavoriteToggle={() => {
              console.log(speaker.id)
            }} />;
        })}
      </div>
    </div>
  );
}

export default SpeakersList;