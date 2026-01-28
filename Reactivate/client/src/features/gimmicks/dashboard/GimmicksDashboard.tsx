
import { Grid } from "@mui/material"
import GimmicksList from "./GimmicksList"
import GimmickDetails from "../details/GimmickDetails"

type Props = {  
  gimmicks: Gimmick[]
  selectGimmick: (id: string) => void 
  deleteGimmick: (id: string) => void
}

const GimmicksDashboard = ({ gimmicks, selectGimmick, deleteGimmick }: Props) => {
  return (
    <Grid container spacing={3}>
      <Grid size={7}>
        <GimmicksList 
          gimmicks={gimmicks} 
          selectGimmick={selectGimmick}
          deleteGimmick={deleteGimmick}
        />
      </Grid>
      <Grid size={5}>
        {gimmicks[0] && <GimmickDetails gimmick={gimmicks[0]} />}
      </Grid>
    </Grid>
  )
}

export default GimmicksDashboard