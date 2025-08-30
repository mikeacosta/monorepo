import { List, ListItem, ListItemText, Typography } from "@mui/material"
import axios from "axios"
import { useEffect, useState } from "react"

function App() {
  const [gimmicks, setGimmicks] = useState<Gimmick[]>([])

  useEffect(() => {
    axios.get<Gimmick[]>("https://localhost:5001/api/gimmicks")
      .then(response => setGimmicks(response.data))
  }, [])

  return (
    <>
      <Typography variant="h3">Reactivate</Typography>
      <List>
        {gimmicks.map(gimmick => (
          <ListItem key={gimmick.id}>
            <ListItemText>{gimmick.title}</ListItemText></ListItem>
        ))}
      </List>
    </>

  )
}

export default App
