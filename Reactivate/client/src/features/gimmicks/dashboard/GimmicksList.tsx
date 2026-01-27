import { Box } from "@mui/material"
import GimmickCard from "./GimmickCard"

type Props = {
  gimmicks: Gimmick[]
  selectGimmick: (id: string) => void
  deleteGimmick: (id: string) => void
}

const GimmicksList = ({ gimmicks, selectGimmick, deleteGimmick }: Props) => {

  return (
    <Box sx={{ display: 'flex', flexDirection: 'column', gap: 3 }}>
      {gimmicks.map(gimmick => (
        <GimmickCard
          key={gimmick.id}
          gimmick={gimmick}
          selectGimmick={selectGimmick}
          deleteGimmick={deleteGimmick}
        />
      ))}
    </Box>
  )
}

export default GimmicksList