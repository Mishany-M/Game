using Interface;
using System.Collections;

public class Enemy5 : Enemys
{
    public override IEnumerator AttacBegun()
    {
        while (distanceToPlayer < RangeAttac + 3)
        {
            anim.SetBool("EnemyAttac", true);
            yield return wait;
            anim.SetBool("EnemyAttac", false);
            yield return wait;
            enterInRangeAttac = false;
        }
    }
}
