using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    [SerializeField] private GameObject stackSymbolPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private StackControlPanel controlPanel;

    private const int MaxVisibleSymbols = 6;
    private readonly List<string> fullStack = new();
    private readonly List<GameObject> visibleSymbols = new();

    public AutomatonNode automaton;

    public void Setup(AutomatonNode automaton)
    {
        this.automaton = automaton;
        controlPanel.Setup(automaton);

        UpdateVisibility();
        automaton.OnTypeChange += UpdateVisibility;
        automaton.OnStackUpdated += UpdateStackContent;
    }

    public void Push(string symbol)
    {
        AutomatonError error;
        automaton.PushStack(symbol, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            return;
        }

        fullStack.Add(symbol);

        if (visibleSymbols.Count < MaxVisibleSymbols)
        {
            GameObject newSymbol = Instantiate(stackSymbolPrefab, spawnPoint.position, Quaternion.identity, transform);
            SetSymbolOnObject(newSymbol, symbol);
            visibleSymbols.Insert(0, newSymbol);
        }
        else
        {
            // Shift symbols down visually
            for (int i = MaxVisibleSymbols - 1; i > 0; i--)
            {
                CopySymbol(visibleSymbols[i], visibleSymbols[i - 1]);
            }
            SetSymbolOnObject(visibleSymbols[0], symbol);
        }
    }

    public void Pop()
    {
        if (fullStack.Count == 0) return;

        AutomatonError error;
        automaton.PopStack(out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            return;
        }

        fullStack.RemoveAt(fullStack.Count - 1);

        if (visibleSymbols.Count == 0) return;

        if (fullStack.Count < MaxVisibleSymbols)
        {
            // Remove top visual
            GameObject top = visibleSymbols[0];
            visibleSymbols.RemoveAt(0);
            Destroy(top);
        }
        else
        {
            // Shift symbols up visually
            for (int i = 0; i < MaxVisibleSymbols - 1; i++)
            {
                CopySymbol(visibleSymbols[i], visibleSymbols[i + 1]);
            }
            SetSymbolOnObject(visibleSymbols[^1], fullStack[fullStack.Count - MaxVisibleSymbols]);
        }
    }

    private void SetSymbolOnObject(GameObject obj, string symbol)
    {
        StackSymbol symbolScript = obj.GetComponent<StackSymbol>();
        if (symbolScript != null)
        {
            symbolScript.SetSymbol(symbol);
        }
        else
        {
            Debug.LogWarning("StackSymbol component missing on prefab.");
        }
    }

    private void CopySymbol(GameObject to, GameObject from)
    {
        var fromScript = from.GetComponent<StackSymbol>();
        var toScript = to.GetComponent<StackSymbol>();

        if (fromScript != null && toScript != null)
        {
            toScript.SetSymbol(fromScript.GetSymbol());
        }
    }

    private void UpdateVisibility()
    {
        if (automaton.automataType == AutomataType.DPDA || automaton.automataType == AutomataType.NPDA)
        {
            UpdateStackContent();
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void UpdateStackContent()
    {
        AutomatonError error;
        string[] newStack = automaton.GetStack(out error);

        string res = "";
        foreach (string stack in newStack)
        {
            res += stack;
        }
        Debug.Log("Stack content: " + res);

        if (error.code != AutomatonErrorCode.OK)
        {
            return;
        }

        int oldCount = fullStack.Count;
        int newCount = newStack.Length;

        // Step 1: Find the index where the stacks diverge from the end
        int i = 0;
        while (i < oldCount && i < newCount &&
               fullStack[oldCount - 1 - i] == newStack[newCount - 1 - i])
        {
            i++;
        }

        // Step 2: Pop symbols that no longer exist
        int symbolsToRemove = oldCount - i;
        for (int j = 0; j < symbolsToRemove; j++)
        {
            fullStack.RemoveAt(fullStack.Count - 1);

            if (visibleSymbols.Count == 0) return;

            if (fullStack.Count < MaxVisibleSymbols)
            {
                // Remove top visual
                GameObject top = visibleSymbols[0];
                visibleSymbols.RemoveAt(0);
                Destroy(top);
            }
            else
            {
                // Shift symbols up visually
                for (int x = 0; x < MaxVisibleSymbols - 1; x++)
                {
                    CopySymbol(visibleSymbols[x], visibleSymbols[x + 1]);
                }
                SetSymbolOnObject(visibleSymbols[^1], fullStack[fullStack.Count - MaxVisibleSymbols]);
            }
        }

        // Step 3: Push new symbols that were added
        for (int j = i; j < newCount; j++)
        {
            string symbol = newStack[newCount - 1 - j];
            fullStack.Add(symbol);

            if (visibleSymbols.Count < MaxVisibleSymbols)
            {
                GameObject newSymbol = Instantiate(stackSymbolPrefab, spawnPoint.position, Quaternion.identity, transform);
                SetSymbolOnObject(newSymbol, symbol);
                visibleSymbols.Insert(0, newSymbol);
            }
            else
            {
                // Shift symbols down visually
                for (int x = MaxVisibleSymbols - 1; x > 0; x--)
                {
                    CopySymbol(visibleSymbols[x], visibleSymbols[x - 1]);
                }
                SetSymbolOnObject(visibleSymbols[0], symbol);
            }
        }
    }

}