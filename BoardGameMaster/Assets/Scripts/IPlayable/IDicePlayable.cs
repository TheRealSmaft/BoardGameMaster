using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDicePlayable : IPlayable {

    void ActivatePostDiceRollActions(Player p);
}
